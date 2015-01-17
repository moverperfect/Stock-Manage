using System.Drawing;
using System.Windows.Forms;
using Stock_Manage_Client.Classes.Networking.Packets;

namespace Stock_Manage_Client.Classes.TabPages
{
    internal class ManageProductsTab : TabPage
    {
        /// <summary>
        ///     Empty contructor to create a new manageproductstab
        ///     that can manage all elements of products
        /// </summary>
        public ManageProductsTab()
        {
            // Set all of the tabpage properties
            Location = new Point(4, 22);
            Name = "ManageProductsTab";
            Size = new Size(1215, 679);
            TabIndex = 0;
            Text = "Manage Products";
            UseVisualStyleBackColor = true;

            // DataGridView of the users
            DgdProducts = new DataGridView
            {
                Anchor =
                    ((AnchorStyles.Top | AnchorStyles.Bottom)
                     | AnchorStyles.Left)
                    | AnchorStyles.Right,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                Location = new Point(3, 3),
                Name = "dgdProducts",
                Size = new Size(1209, 644),
                TabIndex = 0
            };

            // Button that shows a form that asks for details of a new product
            CmdAddNewProduct = new Button
            {
                Anchor =
                    AnchorStyles.Bottom | AnchorStyles.Left,
                Location = new Point(3, 653),
                Name = "cmdAddNewProduct",
                Size = new Size(105, 23),
                TabIndex = 1,
                Text = "Add a new product",
                UseVisualStyleBackColor = true
            };

            // Button that shows a box asking for the new quantity of the selected product
            CmdChangeQuantity = new Button
            {
                Anchor =
                    AnchorStyles.Bottom | AnchorStyles.Right,
                Location = new Point(877, 653),
                Name = "cmdChangeQuantity",
                Size = new Size(96, 23),
                TabIndex = 4,
                Text = "Change Quantity",
                UseVisualStyleBackColor = true
            };

            // Button that shows a form that can change the details of a product
            CmdChangeProduct = new Button
            {
                Anchor =
                    AnchorStyles.Bottom | AnchorStyles.Right,
                Location = new Point(979, 653),
                Name = "cmdChangeProduct",
                Size = new Size(129, 23),
                TabIndex = 3,
                Text = "Change Product Details",
                UseVisualStyleBackColor = true
            };

            // Button that deletes the selected product
            CmdDeleteProduct = new Button
            {
                Anchor =
                    AnchorStyles.Bottom | AnchorStyles.Right,
                Location = new Point(1114, 653),
                Name = "cmdDeleteProduct",
                Size = new Size(98, 23),
                TabIndex = 2,
                Text = "Delete a Product",
                UseVisualStyleBackColor = true
            };

            // Adding all of the controls to the tabpage
            Controls.Add(DgdProducts);
            Controls.Add(CmdAddNewProduct);
            Controls.Add(CmdChangeQuantity);
            Controls.Add(CmdChangeProduct);
            Controls.Add(CmdDeleteProduct);
        }

        /// <summary>
        ///     DataGridView of the users
        /// </summary>
        private DataGridView DgdProducts { get; set; }

        /// <summary>
        ///     Button that shows a form that asks for details of a new product
        /// </summary>
        private Button CmdAddNewProduct { get; set; }

        /// <summary>
        ///     Button that shows a box asking for the new quantity of the selected product
        /// </summary>
        private Button CmdChangeQuantity { get; set; }

        /// <summary>
        ///     Button that shows a form that can change the details of a product
        /// </summary>
        private Button CmdChangeProduct { get; set; }

        /// <summary>
        ///     Button that deletes the selected product
        /// </summary>
        private Button CmdDeleteProduct { get; set; }

        /// <summary>
        ///     The datasource of the DataGridView
        /// </summary>
        private Table DataGridTable { get; set; }
    }
}