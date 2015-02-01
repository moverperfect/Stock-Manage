using System;
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
        /// Stores the table data for suppliers
        /// </summary>
        private Table _suppliersTable;

        /// <summary>
        /// Stores the table data for products
        /// </summary>
        private Table _productsTable;

        /// <summary>
        /// Initialises a new AddChangeOrder form and refreshes the suppliers list
        /// </summary>
        public AddChangeOrder()
        {
            InitializeComponent();
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
            Invoke(new MethodInvoker(delegate { dgdSuppliers.DataSource = _suppliersTable.TableData; }));
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
                Program.SendData("SELECT PK_ProductId, Barcode, Name, Location, Units_In_Case as 'Units in case', Critical_level as 'Critical Level', Nominal_Level as 'Nomianal Level', Purchase_Price as Cost, Quantity as 'Current Quantity' FROM tbl_Products WHERE FK_SupplierId = '" + row[0].Cells[0].Value + "';");
            }
        }

        /// <summary>
        /// Happens when data is recieved from the server about all of the products, adds a new row that is not readonly for the quantity
        /// </summary>
        /// <param name="packet">Table about the products</param>
        private void RefreshProducts_DataRecieved(byte[] packet)
        {
            PacketHandler.DataRecieved -= RefreshProducts_DataRecieved;
            _productsTable = new Table(packet);
            _productsTable.TableData.Columns.Add("Quantity", typeof(Int32));
            foreach (DataColumn column in _productsTable.TableData.Columns)
            {
                column.ReadOnly = true;
            }
            _productsTable.TableData.Columns[_productsTable.TableData.Columns.Count - 1].ReadOnly = false;
            foreach (DataRow row in _productsTable.TableData.Rows)
            {
                row[9] = 0;
            }
            Invoke(new MethodInvoker(delegate { dgdProducts.DataSource = _productsTable.TableData; }));
            dgdProducts.ClearSelection();
        }

        /// <summary>
        /// Happens when a new supplier is selected, calls to refresh the list of products
        /// </summary>
        private void dgdSuppliers_SelectionChanged(object sender, System.EventArgs e)
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
            var supplierRow = dgdSuppliers.SelectedRows;
            if (supplierRow.Count == 0)
            {
                MessageBox.Show("Please select a supplier");
                return;
            }
            var insertOrder = "INSERT INTO tbl_Purchase_Orders (FK_UserId,FK_SupplierId) VALUES ('" +
                              Program.UserId + "','" + supplierRow[0].Cells[0].Value + "');";
            var getOrderId = "SELECT @ORDERID := LAST_INSERT_ID();";
            var insertProducts = "INSERT INTO tbl_Orders (FK_OrderId,FK_ProductId,Product_Quantity,Total_Cost) VALUES ";
            var count = 0;
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
            insertProducts = insertProducts.TrimEnd(',') + ";";
            PacketHandler.DataRecieved += cmdAddOrder_DataRecieved;
            Program.SendData(insertOrder + getOrderId + insertProducts);
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
