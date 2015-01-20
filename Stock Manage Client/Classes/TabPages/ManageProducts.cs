using System.Drawing;
using System.Windows.Forms;
using Stock_Manage_Client.Classes.Networking;
using Stock_Manage_Client.Classes.Networking.Packets;
using Stock_Manage_Client.Forms;
using System;

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

            CmdAddNewProduct.Click += CmdAddNewProduct_Click;
            CmdChangeQuantity.Click += CmdChangeQuantity_Click;

            // Adding all of the controls to the tabpage
            Controls.Add(DgdProducts);
            Controls.Add(CmdAddNewProduct);
            Controls.Add(CmdChangeQuantity);
            Controls.Add(CmdChangeProduct);
            Controls.Add(CmdDeleteProduct);
            RefreshList();
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

        /// <summary>
        /// Refreshes the datagridview by accessing the server database
        /// </summary>
        private void RefreshList()
        {
            PacketHandler.DataRecieved += RefreshList_DataRecieved;
            Program.SendData("SELECT * FROM tbl_products;");
        }

        /// <summary>
        /// Function called when success message recieved from the server
        /// </summary>
        /// <param name="packet"></param>
        private void RefreshList_DataRecieved(byte[] packet)
        {
            PacketHandler.DataRecieved -= RefreshList_DataRecieved;
            DataGridTable = new Table(packet);
            Invoke(new MethodInvoker(delegate { DgdProducts.DataSource = DataGridTable.TableData; }));
        }

        /// <summary>
        /// Opens addproduct dialog box for all of the information for the product
        /// </summary>
        private void CmdAddNewProduct_Click(object sender, System.EventArgs e)
        {
            var addProduct = new AddChangeProduct();
            addProduct.ShowDialog();
        }

        /// <summary>
        /// Opens a changeQuantity dialog with the product id and the current quantity passed into the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmdChangeQuantity_Click(object sender, System.EventArgs e)
        {
            var row = DgdProducts.SelectedRows;
            if (row.Count > 0)
            {
                var changeQuantity = new ChangeQuantity(Convert.ToInt32(row[0].Cells[0].Value), Convert.ToInt32(row[0].Cells[5].Value));
                changeQuantity.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a row");
            }
            RefreshList();
        }

    }
}