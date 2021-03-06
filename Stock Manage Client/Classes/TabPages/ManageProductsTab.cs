﻿using System;
using System.Drawing;
using System.Windows.Forms;
using Stock_Manage_Client.Classes.Networking;
using Stock_Manage_Client.Classes.Networking.Packets;
using Stock_Manage_Client.Forms;

namespace Stock_Manage_Client.Classes.TabPages
{
    /// <summary>
    /// A tab page that can manage products, shows products in datagridview on load
    /// </summary>
    internal class ManageProductsTab : TabPage
    {
        /// <summary>
        /// Empty contructor to create a new manageproductstab
        /// that can manage all elements of products
        /// </summary>
        public ManageProductsTab()
        {
            InitializeComponent();
            RefreshList();
            Program_UserIdChanged(this, EventArgs.Empty);
        }

        /// <summary>
        /// Creates a new tab that has a foreign key attached to it
        /// </summary>
        /// <param name="foriegnKey">The id of the foriegn key</param>
        /// <param name="type">The type of key, "supplier" or "order"</param>
        public ManageProductsTab(int foriegnKey, String type)
        {
            InitializeComponent();
            if (type == "supplier")
            {
                SupplierId = foriegnKey;
            }
            else if (type == "order")
            {
                OrderId = foriegnKey;
                CmdAddNewProduct.Enabled = false;
                CmdChangeProduct.Enabled = false;
                CmdChangeQuantity.Enabled = false;
                CmdDeleteProduct.Enabled = false;
                Text = "Order " + OrderId;
            }
            RefreshList();
        }

        #region Define accessor variables

        /// <summary>
        /// DataGridView of the products
        /// </summary>
        private DataGridView DgdProducts { get; set; }

        /// <summary>
        /// Button that shows a form that asks for details of a new product
        /// </summary>
        private Button CmdAddNewProduct { get; set; }

        /// <summary>
        /// Button that shows a box asking for the new quantity of the selected product
        /// </summary>
        private Button CmdChangeQuantity { get; set; }

        /// <summary>
        /// Button that shows a form that can change the details of a product
        /// </summary>
        private Button CmdChangeProduct { get; set; }

        /// <summary>
        /// Button that deletes the selected product
        /// </summary>
        private Button CmdDeleteProduct { get; set; }

        /// <summary>
        /// The datasource of the DataGridView
        /// </summary>
        private Table DataGridTable { get; set; }

        /// <summary>
        /// Variable used when not all products need to be viewed and only ones of this supplier id
        /// </summary>
        private int SupplierId { get; set; }

        /// <summary>
        /// Variable used when getting the products that are in an order
        /// </summary>
        private int OrderId { get; set; }

        #endregion

        /// <summary>
        /// Defines the tab page
        /// </summary>
        private void InitializeComponent()
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

            // Button that shows a form that asks for details of a new product
            CmdAddNewProduct = new Button
            {
                Anchor =
                    AnchorStyles.Bottom | AnchorStyles.Left,
                Location = new Point(3, 653),
                Name = "cmdAddNewProduct",
                Size = new Size(105, 23),
                TabIndex = 12,
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
                TabIndex = 13,
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
                TabIndex = 14,
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
                TabIndex = 15,
                Text = "Delete a Product",
                UseVisualStyleBackColor = true
            };

            CmdAddNewProduct.Click += CmdAddNewProduct_Click;
            CmdChangeQuantity.Click += CmdChangeQuantity_Click;
            CmdChangeProduct.Click += CmdChangeProduct_Click;
            CmdDeleteProduct.Click += CmdDeleteProduct_Click;

            DgdProducts.DataSourceChanged += DgdProducts_DataSourceChanged;

            Program.UserIdChanged += Program_UserIdChanged;

            // Adding all of the controls to the tabpage
            Controls.Add(DgdProducts);
            Controls.Add(CmdAddNewProduct);
            Controls.Add(CmdChangeQuantity);
            Controls.Add(CmdChangeProduct);
            Controls.Add(CmdDeleteProduct);
        }

        /// <summary>
        /// Refreshes the datagridview by accessing the server database
        /// </summary>
        private void RefreshList()
        {
            PacketHandler.DataRecieved += RefreshList_DataRecieved;
            if (SupplierId != 0)
            {
                Program.SendData("SELECT * FROM tbl_products WHERE FK_SupplierId = '" + SupplierId +
                                 "' ORDER BY PK_ProductId;");
            }
            else if (OrderId != 0)
            {
                Program.SendData(
                    "SELECT PK_ProductId as 'Product Id', Barcode, Name, Description, Location, Purchase_Price as 'Purchase Price', Critical_Level as 'Critical Level', Nominal_Level as 'Nominal Level', Quantity as 'Quantity in Stock', Product_Quantity as 'Quantity Bought', Total_Cost as 'Total Cost' FROM tbl_products INNER JOIN tbl_orders ON tbl_Products.PK_ProductId = tbl_orders.FK_ProductId WHERE FK_OrderId = '" +
                    OrderId + "';");
            }
            else
            {
                Program.SendData("SELECT * FROM tbl_products ORDER BY PK_ProductId;");
            }
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
        private void CmdAddNewProduct_Click(object sender, EventArgs e)
        {
            var addProduct = new AddChangeProduct();
            addProduct.ShowDialog();
            RefreshList();
        }

        /// <summary>
        /// Opens a changeQuantity dialog with the product id and the current quantity passed into the form
        /// </summary>
        private void CmdChangeQuantity_Click(object sender, EventArgs e)
        {
            var row = DgdProducts.SelectedRows;
            if (row.Count > 0)
            {
                var changeQuantity = new ChangeQuantity(Convert.ToInt32(row[0].Cells[0].Value),
                    Convert.ToInt32(row[0].Cells[5].Value));
                changeQuantity.ShowDialog();
                RefreshList();
            }
            else
            {
                MessageBox.Show("Please select a row");
            }
        }

        /// <summary>
        /// Happens when the change product button is clicked, launches a new AddChangeProduct form with the values pre loaded into the form
        /// </summary>
        private void CmdChangeProduct_Click(object sender, EventArgs e)
        {
            var row = DgdProducts.SelectedRows;
            if (row.Count > 0)
            {
                var changeProduct = new AddChangeProduct((int) row[0].Cells[0].Value, row[0].Cells[1].Value.ToString(),
                    row[0].Cells[2].Value.ToString(), row[0].Cells[3].Value.ToString(), row[0].Cells[4].Value.ToString(),
                    (int) row[0].Cells[5].Value, row[0].Cells[6].Value.ToString(), row[0].Cells[7].Value.ToString(),
                    (int) row[0].Cells[8].Value, (int) row[0].Cells[9].Value, (int) row[0].Cells[10].Value);
                changeProduct.ShowDialog();
                RefreshList();
            }
            else
            {
                MessageBox.Show("Please select a row");
            }
        }

        /// <summary>
        /// Called when delete product button is clicked, sends a delete sql statement to the server to delete the selected
        /// </summary>
        private void CmdDeleteProduct_Click(object sender, EventArgs e)
        {
            var row = DgdProducts.SelectedRows;
            if (row.Count > 0)
            {
                if (MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    PacketHandler.DataRecieved += CmdDeleteProduct_DataRecieved;
                    Program.SendData("DELETE FROM tbl_products WHERE PK_productId = '" + row[0].Cells[0].Value + "';");
                }
            }
            else
            {
                MessageBox.Show("Please select a row");
            }
        }

        /// <summary>
        /// Is called when data is recieved after deleting an item
        /// </summary>
        /// <param name="packet"></param>
        private void CmdDeleteProduct_DataRecieved(byte[] packet)
        {
            PacketHandler.DataRecieved -= CmdDeleteProduct_DataRecieved;
            RefreshList();
        }

        /// <summary>
        /// When the data in the view changes, check for the quantity to change to colour of the products
        /// </summary>
        private void DgdProducts_DataSourceChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DgdProducts.Rows)
            {
                if (Convert.ToInt32(row.Cells[5].Value) <= Convert.ToInt32(row.Cells[9].Value))
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
                else if (Convert.ToInt32(row.Cells[9].Value) < Convert.ToInt32(row.Cells[5].Value) &&
                         Convert.ToInt32(row.Cells[5].Value) < Convert.ToInt32(row.Cells[10].Value))
                {
                    row.DefaultCellStyle.BackColor = Color.Orange;
                }
            }
            DgdProducts.ClearSelection();
        }

        private void Program_UserIdChanged(object sender, EventArgs e)
        {
            if (Created)
            {
                Invoke(new MethodInvoker(delegate
                {
                    if (Program.UserId == 0)
                    {
                        CmdAddNewProduct.Enabled = false;
                        CmdChangeQuantity.Enabled = false;
                        CmdChangeProduct.Enabled = false;
                        CmdDeleteProduct.Enabled = false;
                    }
                    else
                    {
                        CmdAddNewProduct.Enabled = true;
                        CmdChangeQuantity.Enabled = true;
                        CmdChangeProduct.Enabled = true;
                        CmdDeleteProduct.Enabled = true;
                    }
                }));
            }
            else
            {
                if (Program.UserId == 0)
                {
                    CmdAddNewProduct.Enabled = false;
                    CmdChangeQuantity.Enabled = false;
                    CmdChangeProduct.Enabled = false;
                    CmdDeleteProduct.Enabled = false;
                }
                else
                {
                    CmdAddNewProduct.Enabled = true;
                    CmdChangeQuantity.Enabled = true;
                    CmdChangeProduct.Enabled = true;
                    CmdDeleteProduct.Enabled = true;
                }
            }
        }
    }
}