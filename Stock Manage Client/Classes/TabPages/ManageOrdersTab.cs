using System;
using System.Drawing;
using System.Windows.Forms;
using Stock_Manage_Client.Classes.Networking;
using Stock_Manage_Client.Classes.Networking.Packets;
using Stock_Manage_Client.Forms;

namespace Stock_Manage_Client.Classes.TabPages
{
    /// <summary>
    /// Allows management/ordering users to manage orders, add/change/delete
    /// </summary>
    internal class ManageOrdersTab : TabPage
    {
        /// <summary>
        /// Empty constructor to create a order tab with no special parameters
        /// </summary>
        public ManageOrdersTab()
        {
            InitializeComponent();
            RefreshList();
        }

        /// <summary>
        /// Creates a orders tab that only shows the orders for the parsed supplierId
        /// </summary>
        /// <param name="supplierId">Show only orders for this supplierId</param>
        public ManageOrdersTab(int supplierId)
        {
            InitializeComponent();
            SupplierId = supplierId;
            RefreshList();
        }

        #region Define accessor variables

        /// <summary>
        /// Datagridview of the orders
        /// </summary>
        private DataGridView DgdOrders { get; set; }

        /// <summary>
        /// Button allowing users to add new orders
        /// </summary>
        private Button CmdAddNewOrder { get; set; }

        /// <summary>
        /// Button allowing users to view products in a selected order
        /// </summary>
        private Button CmdViewProducts { get; set; }

        /// <summary>
        /// Button allowing users to change the details of a selected order
        /// </summary>
        private Button CmdChangeDetails { get; set; }

        /// <summary>
        /// Button allowing users to delete an order from the system
        /// </summary>
        private Button CmdDeleteOrder { get; set; }

        /// <summary>
        /// The datasource for the datagridview
        /// </summary>
        private Table DataGridTable { get; set; }

        /// <summary>
        /// Only used if looking at the orders for a specific supplier
        /// </summary>
        private int SupplierId { get; set; }

        #endregion

        /// <summary>
        /// Defines the tab page
        /// </summary>
        private void InitializeComponent()
        {
            // Set all of the tabpage properties
            Location = new Point(4, 22);
            Name = "ManageOrdersTab";
            Size = new Size(1215, 679);
            TabIndex = 0;
            Text = "Manage Orders Tab";
            UseVisualStyleBackColor = true;

            // Datagridview of all of the orders
            DgdOrders = new DataGridView
            {
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                Anchor =
                    ((AnchorStyles.Top | AnchorStyles.Bottom)
                     | AnchorStyles.Left)
                    | AnchorStyles.Right,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                Location = new Point(3, 3),
                MultiSelect = false,
                Name = "dgdOrders",
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                Size = new Size(1209, 644),
                TabIndex = 11,
                StandardTab = true
            };

            // Button that opens new form so can edit orders
            CmdAddNewOrder = new Button
            {
                Anchor =
                    AnchorStyles.Bottom | AnchorStyles.Left,
                Location = new Point(3, 653),
                Name = "cmdAddNewOrder",
                Size = new Size(94, 23),
                TabIndex = 12,
                Text = "Add New Order",
                UseVisualStyleBackColor = true
            };

            // Button that opens tab that shows the products for this order
            CmdViewProducts = new Button
            {
                Anchor = AnchorStyles.Bottom,
                Location = new Point(539, 653),
                Name = "cmdViewProducts",
                Size = new Size(128, 23),
                TabIndex = 13,
                Text = "View Ordered Products",
                UseVisualStyleBackColor = true
            };

            // Button that allows the user to change the details of an order
            CmdChangeDetails = new Button
            {
                Anchor =
                    AnchorStyles.Bottom | AnchorStyles.Right,
                Location = new Point(1010, 653),
                Name = "cmdChangeDetails",
                Size = new Size(121, 23),
                TabIndex = 14,
                Text = "Change Order Details",
                UseVisualStyleBackColor = true
            };

            // Button that allows the user to delete an order from the database
            CmdDeleteOrder = new Button
            {
                Anchor =
                    AnchorStyles.Bottom | AnchorStyles.Right,
                Location = new Point(1137, 653),
                Name = "cmdDeleteOrder",
                Size = new Size(75, 23),
                TabIndex = 15,
                Text = "Delete Order",
                UseVisualStyleBackColor = true
            };

            // Add clicking event handlers
            CmdAddNewOrder.Click += CmdAddNewOrder_Click;
            CmdViewProducts.Click += CmdViewProducts_Click;
            CmdChangeDetails.Click += CmdChangeDetails_Click;
            CmdDeleteOrder.Click += CmdDeleteOrder_Click;

            // Adding all of the controls
            Controls.Add(DgdOrders);
            Controls.Add(CmdAddNewOrder);
            Controls.Add(CmdViewProducts);
            Controls.Add(CmdChangeDetails);
            Controls.Add(CmdDeleteOrder);
        }

        /// <summary>
        /// Refresh the datagridview data from the server
        /// </summary>
        private void RefreshList()
        {
            PacketHandler.DataRecieved += RefreshList_DataRecieved;
            var select =
                "SELECT PK_OrderId as 'Order Id', FK_UserId AS 'User Id', tbl_users.First_Name as 'First Name', tbl_users.Second_Name as 'Second Name', FK_SupplierId as 'Supplier Id', tbl_suppliers.Name as 'Supplier Name', CAST(sum(Total_Cost) as DECimal(10,2)) as Order_total, DateOrdered from ( SELECT PK_OrderId, Total_Cost, FK_UserId, FK_SupplierId, DateOrdered From tbl_orders INNER JOIN tbl_purchase_orders on tbl_orders.FK_OrderId = tbl_purchase_orders.PK_OrderId ) t  INNER JOIN tbl_users on t.FK_UserId = tbl_users.PK_UserId INNER JOIN tbl_suppliers on t.FK_SupplierId = tbl_suppliers.PK_SupplierId";
            if (SupplierId != 0)
            {
                Program.SendData(select + " WHERE FK_SupplierId = '" + SupplierId + "' GROUP BY PK_OrderId;");
            }
            else
            {
                Program.SendData(select + " GROUP BY PK_OrderId");
            }
        }

        /// <summary>
        /// When we recieve the data back from the server, set the datagridview to the data
        /// </summary>
        /// <param name="packet">The table data from the server</param>
        private void RefreshList_DataRecieved(byte[] packet)
        {
            PacketHandler.DataRecieved -= RefreshList_DataRecieved;
            DataGridTable = new Table(packet);
            Invoke(new MethodInvoker(delegate { DgdOrders.DataSource = DataGridTable.TableData; }));
        }

        /// <summary>
        /// Opens a new form asking for all of the information required for adding a new order
        /// </summary>
        private void CmdAddNewOrder_Click(object sender, EventArgs e)
        {
            var addOrder = new AddChangeOrder();
            addOrder.ShowDialog();
            RefreshList();
        }

        /// <summary>
        /// Opens a new tab that only shows a detailed view of the products fot the selected order
        /// </summary>
        private void CmdViewProducts_Click(object sender, EventArgs e)
        {
            var row = DgdOrders.SelectedRows;

            if (row.Count > 0)
            {
                ((TabControl) Parent).TabPages.Add(new ManageProductsTab(Convert.ToInt32(row[0].Cells[0].Value), "order"));
                ((TabControl) Parent).SelectedIndex = ((TabControl) Parent).TabCount - 1;
            }
            else
            {
                MessageBox.Show("Please select a row");
            }
        }

        /// <summary>
        /// Opens a new form allowing the user to change the order 
        /// </summary>
        private void CmdChangeDetails_Click(object sender, EventArgs e)
        {
            var row = DgdOrders.SelectedRows;
            if (row.Count > 0)
            {
                var changeOrder = new AddChangeOrder((int) row[0].Cells[4].Value, (int) row[0].Cells[0].Value);
                changeOrder.ShowDialog();
                RefreshList();
            }
            else
            {
                MessageBox.Show("Please select a row");
            }
        }

        /// <summary>
        /// Sends an sql string to the server asking for the deletion of all the orders details
        /// </summary>
        private void CmdDeleteOrder_Click(object sender, EventArgs e)
        {
            var row = DgdOrders.SelectedRows;

            if (row.Count == 0)
            {
                MessageBox.Show("Please select a row");
                return;
            }

            if (MessageBox.Show("Are you sure you would like to delete this order?", "Are you sure?",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var deleteOrder = "DELETE FROM tbl_orders WHERE FK_OrderId = '" + row[0].Cells[0].Value +
                                  "'; DELETE FROM tbl_purchase_orders WHERE PK_OrderId = '" + row[0].Cells[0].Value +
                                  "';";
                PacketHandler.DataRecieved += CmdDeleteOrder_PacketRecieved;

                Program.SendData(deleteOrder);
            }
        }

        /// <summary>
        /// Happens after we have deleted an order, calls for the refresh of the list
        /// </summary>
        /// <param name="packet">Success message back from the server</param>
        private void CmdDeleteOrder_PacketRecieved(byte[] packet)
        {
            PacketHandler.DataRecieved -= CmdDeleteOrder_PacketRecieved;
            Invoke(new MethodInvoker(RefreshList));
        }
    }
}