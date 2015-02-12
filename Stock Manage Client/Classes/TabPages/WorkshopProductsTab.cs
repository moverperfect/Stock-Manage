﻿using System;
using System.Drawing;
using System.Windows.Forms;
using Stock_Manage_Client.Classes.Networking;
using Stock_Manage_Client.Classes.Networking.Packets;
using Stock_Manage_Client.Forms;

namespace Stock_Manage_Client.Classes.TabPages
{
    internal class WorkshopProductsTab : TabPage
    {
        /// <summary>
        /// Empty constructer that initializes the tab page
        /// </summary>
        public WorkshopProductsTab()
        {
            // Set all of the tabpage properties
            Location = new Point(4, 22);
            Name = "WorkshopProductsTab";
            Size = new Size(1215, 679);
            TabIndex = 0;
            Text = "WorkshopProductsTab";
            UseVisualStyleBackColor = true;

            // DataGridView showing all of the products
            DgdProducts = new DataGridView
            {
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                Anchor = ((AnchorStyles.Top | AnchorStyles.Bottom)
                          | AnchorStyles.Left)
                         | AnchorStyles.Right,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                Location = new Point(4, 4),
                MultiSelect = false,
                Name = "DgdProducts",
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                Size = new Size(1208, 571),
                TabIndex = 0
            };

            // Button that allows the user to use a custom amount of the product
            CmdUseCustom = new Button
            {
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left,
                Location = new Point(4, 581),
                Name = "CmdUseCustom",
                Size = new Size(95, 95),
                TabIndex = 1,
                Text = "Use Custom Amount",
                UseVisualStyleBackColor = true
            };

            // Button that allows the user to use 10 products
            CmdUseTen = new Button
            {
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left,
                Location = new Point(105, 581),
                Name = "CmdUseTen",
                Size = new Size(95, 95),
                TabIndex = 2,
                Text = "Use 10",
                UseVisualStyleBackColor = true
            };

            // Button that allows the user to use 5 products
            CmdUseFive = new Button
            {
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left,
                Location = new Point(206, 581),
                Name = "CmdUseFive",
                Size = new Size(95, 95),
                TabIndex = 3,
                Text = "Use 5",
                UseVisualStyleBackColor = true
            };

            // Button that allows the user to use one product
            CmdUseOne = new Button
            {
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left,
                Location = new Point(307, 581),
                Name = "CmdUseOne",
                Size = new Size(95, 95),
                TabIndex = 4,
                Text = "Use 1",
                UseVisualStyleBackColor = true
            };

            // Button that allows the user to put back one product
            CmdAddOne = new Button
            {
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                Location = new Point(814, 581),
                Name = "CmdAddOne",
                Size = new Size(95, 95),
                TabIndex = 5,
                Text = "Put Back 1",
                UseVisualStyleBackColor = true
            };

            // Button that allows the suer to put back 5 products
            CmdAddFive = new Button
            {
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                Location = new Point(915, 581),
                Name = "CmdAddFive",
                Size = new Size(95, 95),
                TabIndex = 6,
                Text = "Put Back 5",
                UseVisualStyleBackColor = true
            };

            // Button that allows the user to put back 10 products
            CmdAddTen = new Button
            {
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                Location = new Point(1016, 581),
                Name = "CmdAddTen",
                Size = new Size(95, 95),
                TabIndex = 7,
                Text = "Put Back 10",
                UseVisualStyleBackColor = true
            };

            // Button that allows the user to put back a custom amount of product
            CmdAddCustom = new Button
            {
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                Location = new Point(1117, 581),
                Name = "CmdAddCustom",
                Size = new Size(95, 95),
                TabIndex = 8,
                Text = "Put Back Custom",
                UseVisualStyleBackColor = true
            };

            Program.UserIdChanged += Program_UserIdChanged;

            CmdAddCustom.Click += CmdAddQuantity_Click;
            CmdAddTen.Click += CmdAddQuantity_Click;
            CmdAddFive.Click += CmdAddQuantity_Click;
            CmdAddOne.Click += CmdAddQuantity_Click;
            CmdUseOne.Click += CmdAddQuantity_Click;
            CmdUseFive.Click += CmdAddQuantity_Click;
            CmdUseTen.Click += CmdAddQuantity_Click;
            CmdUseCustom.Click += CmdAddQuantity_Click;

            // Add all of the controls to the tabpage
            Controls.Add(CmdAddCustom);
            Controls.Add(CmdAddTen);
            Controls.Add(CmdAddFive);
            Controls.Add(CmdAddOne);
            Controls.Add(CmdUseOne);
            Controls.Add(CmdUseFive);
            Controls.Add(CmdUseTen);
            Controls.Add(CmdUseCustom);
            Controls.Add(DgdProducts);

            Program_UserIdChanged(this, EventArgs.Empty);

            RefreshList();
        }

        #region Define accessor variables

        /// <summary>
        /// Shows a list of the products to the user
        /// </summary>
        private DataGridView DgdProducts { get; set; }

        /// <summary>
        /// Allows the user to add a custom amount of product back
        /// </summary>
        private Button CmdAddCustom { get; set; }

        /// <summary>
        /// Allows the user to add 10 items back to the selected product
        /// </summary>
        private Button CmdAddTen { get; set; }

        /// <summary>
        /// Allows the user to add 5 items back to the selected product
        /// </summary>
        private Button CmdAddFive { get; set; }

        /// <summary>
        /// Allows the user to add one item back to the selected product
        /// </summary>
        private Button CmdAddOne { get; set; }

        /// <summary>
        /// Allows the user to use one of the selected product
        /// </summary>
        private Button CmdUseOne { get; set; }
        
        /// <summary>
        /// Allows the user to use 5 of the selected product
        /// </summary>
        private Button CmdUseFive { get; set; }

        /// <summary>
        /// Allows the user to use 10 of the selected product
        /// </summary>
        private Button CmdUseTen { get; set; }

        /// <summary>
        /// Allows the user to use a custom amount of the selected product
        /// </summary>
        private Button CmdUseCustom { get; set; }

        /// <summary>
        /// Holds the data for the datagridview of the products
        /// </summary>
        private Table DataGridTable { get; set; }

        #endregion

        /// <summary>
        /// Refreshed the products in the datagirdview
        /// </summary>
        private void RefreshList()
        {
            PacketHandler.DataRecieved += RefreshList_DataRecieved;
            Program.SendData("SELECT * FROM tbl_products ORDER BY PK_ProductId;");
        }

        /// <summary>
        /// When we recieve the table back from the server, set as the datasource
        /// </summary>
        /// <param name="packet"></param>
        private void RefreshList_DataRecieved(byte[] packet)
        {
            PacketHandler.DataRecieved -= RefreshList_DataRecieved;
            DataGridTable = new Table(packet);
            Invoke(new MethodInvoker(delegate { DgdProducts.DataSource = DataGridTable.TableData; }));
        }

        /// <summary>
        /// Happens when the user id is changed, depending on the id, will change whether the buttons are enabled or not
        /// </summary>
        private void Program_UserIdChanged(object sender, EventArgs e)
        {
            if (Created)
            {
                Invoke(new MethodInvoker(() => ChangeButtonsEnabled(Program.UserId != "0")));
            }
            else
            {
                ChangeButtonsEnabled(Program.UserId != "0");
            }
        }

        /// <summary>
        /// Changes all of the tabs buttons to the inputted boolean
        /// </summary>
        /// <param name="enabled">Bool expressing the enabled variable of the buttons in the tab</param>
        private void ChangeButtonsEnabled(bool enabled)
        {
            CmdAddCustom.Enabled = enabled;
            CmdAddTen.Enabled = enabled;
            CmdAddFive.Enabled = enabled;
            CmdAddOne.Enabled = enabled;
            CmdUseCustom.Enabled = enabled;
            CmdUseTen.Enabled = enabled;
            CmdUseFive.Enabled = enabled;
            CmdUseOne.Enabled = enabled;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmdAddQuantity_Click(object sender, EventArgs e)
        {
            var row = DgdProducts.SelectedRows;

            if (row.Count !=  0)
            {
                var btn = sender as Button;

                var quantity = 0;

                switch (btn.Name)
                {
                    case "CmdAddCustom":
                        var addInputForm = new InputNumberPad();
                        addInputForm.ShowDialog();
                        quantity = addInputForm.Quantity;
                        break;

                    case "CmdAddTen":
                        quantity = 10;
                        break;

                    case "CmdAddFive":
                        quantity = 5;
                        break;

                    case "CmdAddOne":
                        quantity = 1;
                        break;

                    case "CmdUseCustom":
                        var useInputForm = new InputNumberPad();
                        useInputForm.ShowDialog();
                        quantity = -useInputForm.Quantity;
                        break;

                    case "CmdUseTen":
                        quantity = -10;
                        break;

                    case "CmdUseFive":
                        quantity = -5;
                        break;

                    case "CmdUseOne":
                        quantity = -1;
                        break;
                }

                quantity = int.Parse(row[0].Cells[5].Value.ToString()) + quantity;

                var sqlUpdate = "UPDATE tbl_products SET Quantity = '" + quantity + "' WHERE PK_ProductId = '" +
                                row[0].Cells[0].Value + "';";

                PacketHandler.DataRecieved += CmdAddQuantity_DataRecieved;
                Program.SendData(sqlUpdate);
            }
        }

        private void CmdAddQuantity_DataRecieved(byte[] packet)
        {
            PacketHandler.DataRecieved -= CmdAddQuantity_DataRecieved;
            Invoke(new MethodInvoker(RefreshList));
        }
    }
}