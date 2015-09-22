using System;
using System.Drawing;
using System.Windows.Forms;
using Stock_Manage_Client.Classes.Networking.Packets;
using Stock_Manage_Client.Forms;

namespace Stock_Manage_Client.Classes.TabPages
{
    /// <summary>
    /// Gives a notification to the user about the products that are low
    /// </summary>
    internal class ProductNotificationTab : TabPage
    {
        /// <summary>
        /// Create the tab with the product notifications
        /// </summary>
        /// <param name="tmpTable">The product notifications to be displayed</param>
        public ProductNotificationTab(Table tmpTable)
        {
            InitializeComponent();
            DataGridTable = tmpTable;
            DgdProducts.DataSource = DataGridTable.TableData;
        }

        #region Define accessor variables

        /// <summary>
        /// Datagrifview of the product notifications
        /// </summary>
        private DataGridView DgdProducts { get; set; }

        /// <summary>
        /// Button allowing users to create a new order for the selected product
        /// </summary>
        private Button CmdCreateOrder { get; set; }

        /// <summary>
        /// Button allowing users to dismiss the current notifications
        /// </summary>
        private Button CmdDismiss { get; set; }

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
            Name = "ProductNotificationTab";
            Size = new Size(1215, 679);
            TabIndex = 0;
            Text = "Low Product Notifications";
            UseVisualStyleBackColor = true;

            // Datagridview of all of the product notifications
            DgdProducts = new DataGridView
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
                Name = "dgdProducts",
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                Size = new Size(1209, 644),
                TabIndex = 11,
                StandardTab = true
            };

            // Button that allows the user to create an order for the selected product
            CmdCreateOrder = new Button
            {
                Anchor =
                    AnchorStyles.Bottom | AnchorStyles.Left,
                Location = new Point(3, 653),
                Name = "cmdCreateOrder",
                Size = new Size(94, 23),
                TabIndex = 12,
                Text = "Create Order",
                UseVisualStyleBackColor = true
            };

            // Button that allows the user to dismiss the notifications 
            CmdDismiss = new Button
            {
                Anchor =
                    AnchorStyles.Bottom | AnchorStyles.Right,
                Location = new Point(1137, 653),
                Name = "cmdDismiss",
                Size = new Size(75, 23),
                TabIndex = 13,
                Text = "Dismiss",
                UseVisualStyleBackColor = true
            };

            // Add clicking event handlers
            CmdCreateOrder.Click += CmdCreateOrder_Click;
            CmdDismiss.Click += CmdDismiss_Click;

            // Adding all of the controls
            Controls.Add(DgdProducts);
            Controls.Add(CmdCreateOrder);
            Controls.Add(CmdDismiss);
            
        }

        /// <summary>
        /// Opens a new form to create a new order for the selected product
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmdCreateOrder_Click(object sender, EventArgs e)
        {
            var addOrder = new AddChangeOrder((int) DgdProducts.SelectedRows[0].Cells[8].Value);
            addOrder.ShowDialog();
            DgdProducts.Rows.Remove(DgdProducts.SelectedRows[0]);
        }

        /// <summary>
        /// Removes the selected product notification
        /// </summary>
        private void CmdDismiss_Click(object sender, EventArgs e)
        {
            if (DgdProducts.Rows.Count == 1)
            {
                TabManagement.RemoveTab(Parent as TabControl, -1);
            }

            if (DgdProducts.SelectedRows.Count != 0)
            {
                DgdProducts.Rows.Remove(DgdProducts.SelectedRows[0]);
            }
        }
    }
}