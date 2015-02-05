﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Stock_Manage_Client.Classes;
using Stock_Manage_Client.Classes.Networking;
using Stock_Manage_Client.Classes.Networking.Packets;

namespace Stock_Manage_Client.Forms
{
    public partial class AddChangeOrder : Form
    {
        /// <summary>
        /// Stores the order id if changing a product
        /// </summary>
        private int _orderId;

        /// <summary>
        /// Stores the table data for products
        /// </summary>
        private Table _productsTable;

        /// <summary>
        /// Stores the supplier id if changing a product
        /// </summary>
        private int _supplierId;

        /// <summary>
        /// Stores the table data for suppliers
        /// </summary>
        private Table _suppliersTable;

        /// <summary>
        /// Stores a temporary list of all of the old quantities of the old order
        /// </summary>
        private List<int> _tempOldQuantities = new List<int>();

        /// <summary>
        /// Initialises a new AddChangeOrder form and refreshes the suppliers list
        /// </summary>
        public AddChangeOrder()
        {
            InitializeComponent();
            RefreshSuppliers();
        }

        /// <summary>
        /// Initialises the form for changing an order, takes in supplier id and order id
        /// </summary>
        /// <param name="supplierId">The supplier id that the order goes to</param>
        /// <param name="orderId">The id of the order</param>
        public AddChangeOrder(int supplierId, int orderId)
        {
            InitializeComponent();
            _supplierId = supplierId;
            _orderId = orderId;
            cmdAddOrder.Text = "Change Order";
            RefreshSuppliers();
        }

        /// <summary>
        /// Refreshes the suppliers table
        /// </summary>
        private void RefreshSuppliers()
        {
            PacketHandler.DataRecieved += RefreshSuppliers_DataRecieved;
            Program.SendData("SELECT * FROM tbl_suppliers ORDER BY PK_SupplierId;");
        }

        /// <summary>
        /// Happens when we recieve the data from the server for all of the suppliers
        /// </summary>
        /// <param name="packet"></param>
        private void RefreshSuppliers_DataRecieved(byte[] packet)
        {
            PacketHandler.DataRecieved -= RefreshSuppliers_DataRecieved;
            _suppliersTable = new Table(packet);
            Invoke(new MethodInvoker(delegate
            {
                // We remove the eventhandle here as the event triggers several times and causes errors
                dgdSuppliers.SelectionChanged -= dgdSuppliers_SelectionChanged;
                dgdSuppliers.DataSource = _suppliersTable.TableData;
                dgdSuppliers.ClearSelection();
                foreach (DataGridViewRow row in dgdSuppliers.Rows)
                {
                    if (row.Cells[0].Value.ToString() == _supplierId.ToString())
                    {
                        row.Selected = true;
                    }
                }
                dgdSuppliers.SelectionChanged += dgdSuppliers_SelectionChanged;
            }));
            Invoke(new MethodInvoker(RefreshProducts));
        }

        /// <summary>
        /// Refreshes the products table with the parsed supplierId
        /// </summary>
        /// <param name="supplierId">Only products with this supplierId will show</param>
        private void RefreshProducts()
        {
            var row = dgdSuppliers.SelectedRows;

            if (row.Count != 0)
            {
                PacketHandler.DataRecieved += RefreshProducts_DataRecieved;

                if (_orderId == 0)
                {
                    Program.SendData(
                        "SELECT PK_ProductId, Barcode, Name, Location, Units_In_Case as 'Units in case', Critical_level as 'Critical Level', Nominal_Level as 'Nomianal Level', Purchase_Price as Cost, Quantity as 'Current Quantity' FROM tbl_Products WHERE FK_SupplierId = '" +
                        row[0].Cells[0].Value + "';");
                }
                else
                {
                    Program.SendData(
                        "SELECT PK_ProductId, Barcode, Name, Location, Units_In_Case as 'Units in case', Critical_level as 'Critical Level', Nominal_Level as 'Nomianal Level', Purchase_Price as Cost, Quantity as 'Current Quantity', coalesce(Product_Quantity,0) as 'Quantity' FROM (SELECT * FROM tbl_orders WHERE FK_OrderId = '" +
                        _orderId +
                        "')t RIGHT JOIN tbl_products ON t.FK_ProductId = tbl_products.PK_ProductId WHERE FK_SupplierId = '" +
                        _supplierId + "';");
                }
            }
        }

        /// <summary>
        /// Happens when data is recieved from the server about all of the products, adds a new row that is not readonly for the quantity
        /// </summary>
        /// <param name="packet">Table about the products</param>
        private void RefreshProducts_DataRecieved(byte[] packet)
        {
            PacketHandler.DataRecieved -= RefreshProducts_DataRecieved;
            try
            {
                _productsTable = new Table(packet);
                if (_productsTable.TableData.Columns.Count == 9)
                {
                    // Add a new column to the table for the users to enter into
                    _productsTable.TableData.Columns.Add("Quantity", typeof (Int32));
                    // Set all columns to be readonly
                    foreach (DataColumn column in _productsTable.TableData.Columns)
                    {
                        column.ReadOnly = true;
                    }
                    // Apart from the one the users enter into
                    _productsTable.TableData.Columns[_productsTable.TableData.Columns.Count - 1].ReadOnly = false;
                    // Set the defualt for all rows for the quantity to be 0
                    foreach (DataRow row in _productsTable.TableData.Rows)
                    {
                        row[9] = 0;
                    }
                }
                else
                {
                    // If we are changing an order and not creating a new one then set the temp table
                    foreach (DataRow row in _productsTable.TableData.Rows)
                    {
                        _tempOldQuantities.Add(Convert.ToInt32(row[9].ToString()));
                    }
                }
                // Set the datasource and clear the selection
                Invoke(new MethodInvoker(delegate { dgdProducts.DataSource = _productsTable.TableData; }));
                dgdProducts.ClearSelection();
                Invoke(new MethodInvoker(
                    delegate { dgdProducts_CellEndEdit(new object(), new DataGridViewCellEventArgs(0, 0)); }));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Happens when a new supplier is selected, calls to refresh the list of products
        /// </summary>
        private void dgdSuppliers_SelectionChanged(object sender, EventArgs e)
        {
            RefreshProducts();
        }

        /// <summary>
        /// Happens when the user ends editing a cell, this updates the total cost label to be accurate
        /// </summary>
        private void dgdProducts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            decimal sum = 0;
            foreach (DataGridViewRow row in dgdProducts.Rows)
            {
                if (row.Cells[9].Value.ToString() != "")
                {
                    sum += Convert.ToDecimal(row.Cells[7].Value)*Convert.ToInt32(row.Cells[9].Value);
                }
            }
            lblTotalCost.Text = "Total Cost: £" + sum;
        }

        /// <summary>
        /// Happens when adding a new order, creates the statement and sends it to the server
        /// TODO Comment this
        /// </summary>
        private void cmdAddOrder_Click(object sender, EventArgs e)
        {
            // If the temp is null then we are adding a new order so this code does that
            if (_tempOldQuantities == null)
            {
                // Check if they have selected a supplier, should always be true
                var supplierRow = dgdSuppliers.SelectedRows;
                if (supplierRow.Count == 0)
                {
                    MessageBox.Show("Please select a supplier");
                    return;
                }

                // Create the statements
                var insertOrder = "INSERT INTO tbl_Purchase_Orders (FK_UserId,FK_SupplierId) VALUES ('" +
                                  Program.UserId + "','" + supplierRow[0].Cells[0].Value + "');";
                var getOrderId = "SELECT @ORDERID := LAST_INSERT_ID();";
                var insertProducts =
                    "INSERT INTO tbl_Orders (FK_OrderId,FK_ProductId,Product_Quantity,Total_Cost) VALUES ";
                var count = 0;

                // Create the insert into orders statment with all of the products
                foreach (DataGridViewRow row in dgdProducts.Rows)
                {
                    if (Convert.ToInt32(row.Cells[9].Value) > 0)
                    {
                        insertProducts += "(@ORDERID,'" + row.Cells[0].Value + "','" + row.Cells[9].Value + "','" +
                                          (Convert.ToDecimal(row.Cells[7].Value)*
                                           Convert.ToInt32(row.Cells[9].Value)) + "'),";
                        count++;
                    }
                }
                if (count == 0)
                {
                    MessageBox.Show("Please buy a product before adding an order");
                    return;
                }

                // Take away the , at the end and insert a ;
                insertProducts = insertProducts.TrimEnd(',') + ";";
                PacketHandler.DataRecieved += cmdAddOrder_DataRecieved;

                // Send the entire statement off to the server
                Program.SendData(insertOrder + getOrderId + insertProducts);
            }
            else
            {
                var updateProducts = "";
                if ((int) dgdSuppliers.SelectedRows[0].Cells[0].Value != _supplierId)
                {
                    // TODO Do something if the user changes the supplier id
                    return;
                }
                for (var i = 0; i < _tempOldQuantities.Count; i++)
                {
                    if (_tempOldQuantities[i].ToString() != dgdProducts.Rows[i].Cells[9].Value.ToString())
                    {
                        // TODO Add this in and send and should be complete
                        updateProducts += "UPDATE tbl_orders SET Product_Quantity = '" +
                                          dgdProducts.Rows[i].Cells[9].Value + "', Total_Cost = '" +
                                          (Convert.ToDecimal(dgdProducts.Rows[i].Cells[7].Value)*
                                           Convert.ToInt32(dgdProducts.Rows[i].Cells[9].Value)) +
                                          "' WHERE FK_OrderId = '" + _orderId + "' AND FK_ProductId = '" +
                                          dgdProducts.Rows[i].Cells[0].Value + "';";
                    }
                }
                PacketHandler.DataRecieved += cmdAddOrder_DataRecieved;

                Program.SendData(updateProducts);
            }
        }

        /// <summary>
        /// Closes the form after recieved message back from the server
        /// </summary>
        /// <param name="packet"></param>
        private void cmdAddOrder_DataRecieved(byte[] packet)
        {
            PacketHandler.DataRecieved -= cmdAddOrder_DataRecieved;
            Invoke(new MethodInvoker(Close));
        }
    }
}