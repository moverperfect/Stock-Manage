using System;
using System.Collections.Generic;
using System.Data;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using Stock_Manage_Client.Classes.Networking.Packets;

namespace Stock_Manage_Server.Networking
{
    /// <summary>
    /// Handles all incoming packets into the server after fully recieving them
    /// </summary>
    internal static class PacketHandler
    {
        internal static List<ProductNotification> LowProducts = new List<ProductNotification>();

        internal static List<ProductNotification> VerifyOrders = new List<ProductNotification>(); 

        /// <summary>
        /// Handles all incoming packets into the server after fully recieving them
        /// </summary>
        /// <param name="packet">The packet that was recieved</param>
        /// <param name="clientSocket">The socket, used for sending back data to the client</param>
        public static void Handle(byte[] packet, Socket clientSocket)
        {
            // Get the packet length and type
            var packetLength = BitConverter.ToUInt16(packet, 0);
            var packetType = BitConverter.ToUInt16(packet, 2);

            Console.WriteLine("Recieved packet of length: {0} and Type: {1}", packetLength, packetType);

            SqlConnecter connecter;

            // Packet types:
            // 1001 - Table from select statement
            // 2000 - Standard string 
            // 2001 - NonQuery
            // 2002 - Select
            // 2003 - Count
            // 2004 - Notification check
            // 2005 - Low product notification
            // 2006 - Verify Order Notification
            switch (packetType)
            {
                case 2000:
                    // Standard message, never used
                    var msg = new StdData(packet);
                    Console.WriteLine(msg.Text);
                    break;

                case 2001:
                    // Executes a non query to the sql server
                    var nonQuery = new StdData(packet);
                    connecter = new SqlConnecter("db_inventorymanagement");
                    connecter.NonQuery(nonQuery.Text);
                    Console.WriteLine(nonQuery.Text);
                    // TODO Maybe verify this message?
                    clientSocket.Send(new StdData("Success", Program.MachineId, Program.UserId).Data);
                    break;

                case 2002:
                    // Sends a select statement to the sql server then sends back to the client what the sql server replied with
                    var select = new StdData(packet);
                    connecter = new SqlConnecter("db_inventorymanagement");
                    Console.WriteLine(select.Text);
                    var response = connecter.Select(select.Text);
                    if (response is DataTable)
                    {
                        var dt = new Table((DataTable) (response), Program.MachineId, Program.UserId);
                        clientSocket.Send(dt.Data);
                    }
                    else
                    {
                        var error = new StdData(response.ToString(), Program.MachineId, Program.UserId);
                        clientSocket.Send(error.Data);
                    }
                    break;

                case 2004:
                    // TODO Refactor this to be in a seperate class and even combine the product and order to one single function
                    var check = new StdData(packet);
                    connecter = new SqlConnecter("db_inventorymanagement");
                    var isManagement =
                        (DataTable)
                            connecter.Select("SELECT * FROM tbl_users WHERE PK_Userid = " + check.UserId +
                                             " AND System_Role = 'Management';");

                    // If the user is in management
                    if (isManagement.Rows.Count == 1)
                    {
                        var lowProducts =
                            (DataTable)
                                connecter.Select(
                                    "SELECT * FROM db_inventorymanagement.tbl_products WHERE Quantity < Nominal_level;");

                        var index = -1;

                        // Find the index of the current user
                        for (int i = 0; i < LowProducts.Count; i++)
                        {
                            if (check.UserId == LowProducts[i].UserId)
                            {
                                index = i;
                                break;
                            }
                        }
                        
                        // Copy the products
                        var sendProducts = lowProducts;

                        // If the user is has no previous notifications
                        if (index != -1)
                        {
                            for (int i = 0; i < lowProducts.Rows.Count; i++)
                            {
                                if (LowProducts[index].ProductId.Contains((int) lowProducts.Rows[i][0]))
                                {
                                    sendProducts.Rows.Remove(lowProducts.Rows[i]);
                                }
                            }
                        }
                        else if (sendProducts.Rows.Count != 0)
                        {
                            // Add the user to add the notifications
                            LowProducts.Add(new ProductNotification());
                            LowProducts[LowProducts.Count - 1].UserId = check.UserId;
                            index = LowProducts.Count - 1;
                        }

                        // Add the products to the previous notifications
                        for (int i = 0; i < sendProducts.Rows.Count; i++)
                        {
                            LowProducts[index].ProductId.Add((int)sendProducts.Rows[i][0]);
                        }

                        // If there are still products to send back to the client then send
                        if (sendProducts.Rows.Count != 0)
                        {
                            // Send the products back to the client
                            var table = new Table(sendProducts, Program.MachineId, Program.UserId, 2005);
                            clientSocket.Send(table.Data);
                            break;
                        }

                        // Grab the orders that need to be verified
                        var approveOrders =
                            (DataTable)
                                connecter.Select(
                                    "SELECT PK_OrderId as 'Order Id', FK_UserId AS 'User Id', tbl_users.First_Name as 'First Name', tbl_users.Second_Name as 'Second Name', FK_SupplierId as 'Supplier Id', tbl_suppliers.Name as 'Supplier Name', CAST(sum(Total_Cost) as DECimal(10,2)) as Order_total, DateOrdered from ( SELECT PK_OrderId, Total_Cost, FK_UserId, FK_SupplierId, DateOrdered, FK_VerifierId From tbl_orders INNER JOIN tbl_purchase_orders on tbl_orders.FK_OrderId = tbl_purchase_orders.PK_OrderId ) t  INNER JOIN tbl_users on t.FK_UserId = tbl_users.PK_UserId INNER JOIN tbl_suppliers on t.FK_SupplierId = tbl_suppliers.PK_SupplierId WHERE FK_VerifierId is Null OR FK_VerifierId = 0;");

                        if (approveOrders.Rows.Count == 0 ||
                            approveOrders.Rows[0][0] is System.DBNull)
                        {
                            break;
                        }

                        index = -1;

                        // Find the index of the current user
                        for (int i = 0; i < VerifyOrders.Count; i++)
                        {
                            if (check.UserId == VerifyOrders[i].UserId)
                            {
                                index = i;
                                break;
                            }
                        }

                        // Copy the orders
                        var sendOrders = approveOrders;

                        // If the user is has no previous notifications
                        if (index != -1)
                        {
                            for (int i = 0; i < approveOrders.Rows.Count; i++)
                            {
                                if (VerifyOrders[index].ProductId.Contains((int)approveOrders.Rows[i][0]))
                                {
                                    sendOrders.Rows.Remove(approveOrders.Rows[i]);
                                }
                            }
                        }
                        else if (sendOrders.Rows.Count != 0)
                        {
                            // Add the user to add the notifications
                            VerifyOrders.Add(new ProductNotification());
                            VerifyOrders[VerifyOrders.Count - 1].UserId = check.UserId;
                            index = VerifyOrders.Count - 1;
                        }

                        // Add the products to the previous notifications
                        for (int i = 0; i < sendOrders.Rows.Count; i++)
                        {
                            VerifyOrders[index].ProductId.Add((int)sendOrders.Rows[i][0]);
                        }

                        // If there are still products to send back to the client then send
                        if (sendOrders.Rows.Count != 0)
                        {
                            // Send the orders back to the client
                            var table = new Table(sendOrders, Program.MachineId, Program.UserId, 2006);
                            clientSocket.Send(table.Data);
                            break;
                        }
                    }
                    clientSocket.Send(new StdData("", Program.MachineId, Program.UserId, 2004).Data);
                    break;
            }
            clientSocket.Close();
        }
    }

    /// <summary>
    /// Product notification object used for storing the products that have previously been notified to the users
    /// </summary>
    internal class ProductNotification
    {
        /// <summary>
        /// Empty constructor
        /// </summary>
        internal ProductNotification()
        {
            ProductId = new List<int>();
        }

        /// <summary>
        /// The id of the user
        /// </summary>
        internal int UserId { get; set; }

        /// <summary>
        /// The products that the user has already been notified about
        /// </summary>
        internal List<int> ProductId { get; set; }
    }
}