using System.Drawing;
using System.Windows.Forms;
using Stock_Manage_Client.Classes.Networking;
using Stock_Manage_Client.Classes.Networking.Packets;
using Stock_Manage_Client.Forms;

namespace Stock_Manage_Client.Classes.TabPages
{
    internal class ManageSuppliersTab : TabPage
    {
        /// <summary>
        /// Empty constructor to create a new tab that can manage
        /// all of the suppliers
        /// </summary>
        public ManageSuppliersTab()
        {
            Location = new Point(4, 22);
            Name = "ManageSuppliersTab";
            Size = new Size(1215, 679);
            TabIndex = 0;
            Text = "Manage Suppliers";
            UseVisualStyleBackColor = true;

            // Initialise the datagrid that shows the suppliers information
            DgdSuppliers = new DataGridView
            {
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                Anchor = ((AnchorStyles.Top | AnchorStyles.Bottom)
                          | AnchorStyles.Left)
                         | AnchorStyles.Right,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                Location = new Point(3, 3),
                MultiSelect = false,
                Name = "dgdSuppliers",
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                Size = new Size(1209, 644),
                TabIndex = 0
            };

            // Initialise the button to add a new supplier
            CmdAddSupplier = new Button
            {
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left,
                Location = new Point(3, 653),
                Name = "cmdAddSupplier",
                Size = new Size(75, 23),
                TabIndex = 1,
                Text = "Add Supplier",
                UseVisualStyleBackColor = true
            };

            // Initialise the button to view the products used by the selected supplier
            CmdViewProducts = new Button
            {
                Anchor = AnchorStyles.Bottom,
                Location = new Point(471, 653),
                Name = "cmdViewProducts",
                Size = new Size(126, 23),
                TabIndex = 2,
                Text = "View Supplier Products",
                UseVisualStyleBackColor = true
            };

            // Initialise the button to view orders with the selected supplier
            CmdViewOrders = new Button
            {
                Anchor = AnchorStyles.Bottom,
                Location = new Point(603, 653),
                Name = "cmdViewOrders",
                Size = new Size(117, 23),
                TabIndex = 3,
                Text = "View Supplier Orders",
                UseVisualStyleBackColor = true
            };

            // Initialise the button to change the details of a supplier
            CmdChangeDetails = new Button
            {
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                Location = new Point(988, 653),
                Name = "cmdChangeDetails",
                Size = new Size(130, 23),
                TabIndex = 4,
                Text = "Change Supplier Details",
                UseVisualStyleBackColor = true
            };

            // Initialise the button to delete a selected supplier
            CmdDeleteSupplier = new Button
            {
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                Location = new Point(1124, 653),
                Name = "cmdDeleteSupplier",
                Size = new Size(88, 23),
                TabIndex = 5,
                Text = "Delete Supplier",
                UseVisualStyleBackColor = true
            };

            CmdAddSupplier.Click += CmdAddSupplier_Click;
            CmdViewProducts.Click += CmdViewProducts_Click;
            CmdViewOrders.Click += CmdViewOrders_Click;
            CmdChangeDetails.Click += CmdChangeDetails_Click;
            CmdDeleteSupplier.Click += CmdDeleteSupplier_Click;

            // Add all of the controls to the tab page
            Controls.Add(DgdSuppliers);
            Controls.Add(CmdAddSupplier);
            Controls.Add(CmdViewProducts);
            Controls.Add(CmdViewOrders);
            Controls.Add(CmdChangeDetails);
            Controls.Add(CmdDeleteSupplier);
            RefreshList();
        }

        #region Define accessor variables

        /// <summary>
        /// DataGridView of the suppliers
        /// </summary>
        private DataGridView DgdSuppliers { get; set; }

        /// <summary>
        /// Button used to add a new supplier, launches a new form that asks for the details
        /// </summary>
        private Button CmdAddSupplier { get; set; }

        /// <summary>
        /// Button used to view the products that the selected supplier offers, launches a new tab that shows this
        /// </summary>
        private Button CmdViewProducts { get; set; }

        /// <summary>
        /// Button used to view the orders that the selected supplier offers, launches a new tab that shows this
        /// </summary>
        private Button CmdViewOrders { get; set; }

        /// <summary>
        /// Button used to change the details of any supplier, uses the same form as adding a supplier
        /// </summary>
        private Button CmdChangeDetails { get; set; }

        /// <summary>
        /// Button used to delete a supplier, first asks for a confirmation before deleting
        /// </summary>
        private Button CmdDeleteSupplier { get; set; }

        /// <summary>
        /// The data source for the actual DataGridView
        /// </summary>
        private Table DataGridTable { get; set; }

        #endregion

        /// <summary>
        /// Refreshed the DataGridView by accessing the server database
        /// </summary>
        private void RefreshList()
        {
            PacketHandler.DataRecieved += RefreshList_DataRecieved;
            Program.SendData("SELECT * FROM tbl_suppliers ORDER BY PK_SupplierId;");
        }

        /// <summary>
        /// Function called when data is recieved back from the server, sets the DataGridView to the packet
        /// </summary>
        /// <param name="packet">Data that is used as the table for the GridView</param>
        private void RefreshList_DataRecieved(byte[] packet)
        {
            PacketHandler.DataRecieved -= RefreshList_DataRecieved;
            DataGridTable = new Table(packet);
            Invoke(new MethodInvoker(delegate { DgdSuppliers.DataSource = DataGridTable.TableData; }));
        }

        /// <summary>
        /// Opens a addSupplier dialog box for all of the new information for a supplier
        /// </summary>
        private void CmdAddSupplier_Click(object sender, System.EventArgs e)
        {
            var addSupplier = new AddChangeSupplier();
            addSupplier.ShowDialog();
            RefreshList();
        }

        private void CmdViewProducts_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void CmdViewOrders_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void CmdChangeDetails_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void CmdDeleteSupplier_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
