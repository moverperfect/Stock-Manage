using System;
using System.Data;
using System.Net.Sockets;
using Stock_Manage_Client.Classes.Networking.Packets;

namespace Stock_Manage_Server.Networking
{
    internal static class PacketHandler
    {
        public static void Handle(byte[] packet, Socket clientSocket)
        {
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
            switch (packetType)
            {
                case 2000:
                    var msg = new StdData(packet);
                    Console.WriteLine(msg.Text);
                    break;

                case 2001:
                    var nonQuery = new StdData(packet);
                    connecter = new SqlConnecter("db_inventorymanagement");
                    connecter.NonQuery(nonQuery.Text);
                    Console.WriteLine(nonQuery.Text);
                    // TODO Maybe verify this message?
                    clientSocket.Send(new StdData("Success", Program.MachineId, Program.UserId).Data);
                    break;

                case 2002:
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
                    // TODO Implement this
                    var check = new StdData(packet);
                    connecter = new SqlConnecter("db_inventorymanagement");
                    //var isManagement = connecter.Select("SELECT ");
                    break;
            }
            clientSocket.Close();
        }
    }
}