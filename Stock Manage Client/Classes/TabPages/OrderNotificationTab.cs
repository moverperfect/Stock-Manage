using System;
using System.Drawing;
using System.Windows.Forms;
using Stock_Manage_Client.Classes.Networking;
using Stock_Manage_Client.Classes.Networking.Packets;

namespace Stock_Manage_Client.Classes.TabPages
{
    /// <summary>
    /// Gives a notification to the management user to approve an order
    /// </summary>
    internal class OrderNotificationTab : TabPage
    {
        /// <summary>
        /// Create the tab for the order notification
        /// </summary>
        /// <param name="tmpTable">The table with the order details</param>
        public OrderNotificationTab(Table tmpTable)
        {
            InitializeComponent();
            DataGridTable = tmpTable;
            DgdOrders.DataSource = DataGridTable.TableData;
        }

        #region Define accessor variables

        /// <summary>
        /// DataGridView of the order notifications
        /// </summary>
        private DataGridView DgdOrders { get; set; }

        /// <summary>
        /// Button allowing users to view the details of the orders
        /// </summary>
        private Button CmdOrderDetails { get; set; }

        /// <summary>
        /// Button allowing users to verify orders
        /// </summary>
        private Button CmdVerify { get; set; }

        /// <summary>
        /// Button to delte the selected order
        /// </summary>
        private Button CmdDelete { get; set; }

        /// <summary>
        /// The datasource for the datagridview
        /// </summary>
        private Table DataGridTable { get; set; }

        #endregion

        /// <summary>
        /// Defines the tab page
        /// </summary>
        private void InitializeComponent()
        {
            // Set all of the tabpage properties
            Location = new Point(4, 22);
            Name = "OrderNotificationTab";
            Size = new Size(1215, 679);
            TabIndex = 0;
            Text = "Unverified Orders";
            UseVisualStyleBackColor = true;

            // Datagridview of all of the order notifications
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

            // Button allowing users to view the details of the orders
            CmdOrderDetails = new Button
            {
                Anchor =
                    AnchorStyles.Bottom | AnchorStyles.Left,
                Location = new Point(3, 653),
                Name = "cmdOrderDetails",
                Size = new Size(94, 23),
                TabIndex = 12,
                Text = "Order Details",
                UseVisualStyleBackColor = true
            };

            // Button allowing users to verify orders
            CmdVerify = new Button
            {
                Anchor = AnchorStyles.Bottom,
                Location = new Point(539, 653),
                Name = "cmdVerify",
                Size = new Size(128, 23),
                TabIndex = 13,
                Text = "Verify",
                UseVisualStyleBackColor = true
            };

            // Button to delte the selected order
            CmdDelete = new Button
            {
                Anchor =
                    AnchorStyles.Bottom | AnchorStyles.Right,
                Location = new Point(1084, 653),
                Name = "cmdDelete",
                Size = new Size(128, 23),
                TabIndex = 15,
                Text = "Delete/Cancel",
                UseVisualStyleBackColor = true
            };

            // Add clicking event handlers
            CmdOrderDetails.Click += CmdOrderDetails_Click;
            CmdVerify.Click += CmdVerify_Click;
            CmdDelete.Click += CmdDelete_Click;

            // Adding all of the controls
            Controls.Add(DgdOrders);
            Controls.Add(CmdOrderDetails);
            Controls.Add(CmdVerify);
            Controls.Add(CmdDelete);
        }

        /// <summary>
        /// Shows the products that are inside the product
        /// </summary>
        private void CmdOrderDetails_Click(object sender, System.EventArgs e)
        {
            if (DgdOrders.SelectedRows.Count > 0)
            {
                TabManagement.AddTab(new ManageProductsTab(Convert.ToInt32(DgdOrders.SelectedRows[0].Cells[0].Value), "order"), (TabControl)Parent);
            }
        }

        /// <summary>
        /// Verifies the order to be sent off
        /// </summary>
        private void CmdVerify_Click(object sender, System.EventArgs e)
        {
            var row = DgdOrders.Rows[0];
            if (DgdOrders.SelectedRows.Count > 0)
            {
                row = DgdOrders.SelectedRows[0];
            }
            if (DgdOrders.SelectedRows.Count > 0 || DgdOrders.Rows.Count == 1)
            {
                var verifyOrder = "UPDATE tbl_purchase_orders SET FK_VerifierId = '" + Program.UserId +
                                  "' WHERE PK_OrderId = '" + row.Cells[0].Value + "';";
                PacketHandler.DataRecieved += RemoveRow_PacketRecieved;

                Program.SendData(verifyOrder);
            }
        }

        /// <summary>
        /// Deletes the selected order
        /// </summary>
        private void CmdDelete_Click(object sender, System.EventArgs e)
        {
            var row = DgdOrders.Rows[0];
            if (DgdOrders.SelectedRows.Count > 0)
            {
                row = DgdOrders.SelectedRows[0];
            }
            if (DgdOrders.SelectedRows.Count > 0 || DgdOrders.Rows.Count == 1)
            {
                if (MessageBox.Show("Are you sure you would like to delete this order?", "Are you sure?",
    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var deleteOrder = "DELETE FROM tbl_orders WHERE FK_OrderId = '" + row.Cells[0].Value +
                                      "'; DELETE FROM tbl_purchase_orders WHERE PK_OrderId = '" + row.Cells[0].Value +
                                      "';";
                    PacketHandler.DataRecieved += RemoveRow_PacketRecieved;

                    Program.SendData(deleteOrder);
                }
            }
        }

        /// <summary>
        /// Removes the currently selected row or the last row
        /// </summary>
        /// <param name="packet">Success message back from the server</param>
        private void RemoveRow_PacketRecieved(byte[] packet)
        {
            if (BitConverter.ToUInt16(packet, 2) == 2000)
            {
                PacketHandler.DataRecieved -= RemoveRow_PacketRecieved;
                if (DgdOrders.SelectedRows.Count > 0)
                {
                    DgdOrders.Rows.Remove(DgdOrders.SelectedRows[0]);
                }
                else
                {
                    DgdOrders.Rows.Remove(DgdOrders.Rows[0]);
                }

                if (DgdOrders.Rows.Count == 0)
                {
                    TabManagement.RemoveTab(Parent as TabControl, (Parent as TabControl).TabPages.IndexOf(this));
                }
            }
        }
    }
}
