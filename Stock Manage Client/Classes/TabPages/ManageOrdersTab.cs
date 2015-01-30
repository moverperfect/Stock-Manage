using System.Drawing;
using System.Windows.Forms;

namespace Stock_Manage_Client.Classes.TabPages
{
    internal class ManageOrdersTab : TabPage
    {
        /// <summary>
        /// Empty constructor to create a order tab with no special parameters
        /// </summary>
        public ManageOrdersTab()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates a orders tab that only shows the orders for the parsed supplierId
        /// </summary>
        /// <param name="supplierId">Show only orders for this supplierId</param>
        public ManageOrdersTab(int supplierId)
        {
        }

        #region Define accessor variables

        /// <summary>
        /// Datagridview of the orders
        /// </summary>
        private DataGridView dgdOrders { get; set; }

        /// <summary>
        /// Button allowing users to add new orders
        /// </summary>
        private Button cmdAddNewOrder { get; set; }

        /// <summary>
        /// Button allowing users to view products in a selected order
        /// </summary>
        private Button cmdViewProducts { get; set; }

        /// <summary>
        /// Button allowing users to change the details of a selected order
        /// </summary>
        private Button cmdChangeDetails { get; set; }

        /// <summary>
        /// Button allowing users to delete an order from the system
        /// </summary>
        private Button cmdDeleteOrder { get; set; }

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
            dgdOrders = new DataGridView
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
                TabIndex = 0
            };

            // Button that opens new form so can edit orders
            cmdAddNewOrder = new Button
            {
                Anchor =
                    AnchorStyles.Bottom | AnchorStyles.Left,
                Location = new Point(3, 653),
                Name = "cmdAddNewOrder",
                Size = new Size(94, 23),
                TabIndex = 1,
                Text = "Add New Order",
                UseVisualStyleBackColor = true
            };

            // Button that opens tab that shows the products for this order
            cmdViewProducts = new Button
            {
                Anchor = AnchorStyles.Bottom,
                Location = new Point(539, 653),
                Name = "cmdViewProducts",
                Size = new Size(128, 23),
                TabIndex = 2,
                Text = "View Ordered Products",
                UseVisualStyleBackColor = true
            };

            // Button that allows the user to change the details of an order
            cmdChangeDetails = new Button
            {
                Anchor =
                    AnchorStyles.Bottom | AnchorStyles.Right,
                Location = new Point(1010, 653),
                Name = "cmdChangeDetails",
                Size = new Size(121, 23),
                TabIndex = 3,
                Text = "Change Order Details",
                UseVisualStyleBackColor = true
            };

            // Button that allows the user to delete an order from the database
            cmdDeleteOrder = new Button
            {
                Anchor =
                    AnchorStyles.Bottom | AnchorStyles.Right,
                Location = new Point(1137, 653),
                Name = "cmdDeleteOrder",
                Size = new Size(75, 23),
                TabIndex = 4,
                Text = "Delete Order",
                UseVisualStyleBackColor = true
            };

            // Adding all of the controls
            Controls.Add(dgdOrders);
            Controls.Add(cmdAddNewOrder);
            Controls.Add(cmdViewProducts);
            Controls.Add(cmdChangeDetails);
            Controls.Add(cmdDeleteOrder);
        }
    }
}