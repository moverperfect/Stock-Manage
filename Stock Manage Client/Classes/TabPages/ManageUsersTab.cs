using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms;
using Stock_Manage_Client.Classes.Networking;
using Stock_Manage_Client.Classes.Networking.Packets;
using Stock_Manage_Client.Forms;

namespace Stock_Manage_Client.Classes.TabPages
{
    internal class ManageUsersTab : TabPage
    {
        /// <summary>
        /// Empty constructor to create a new ManageUsersTab, Tab has a table that can display the users and can add,
        /// delete and change any user
        /// </summary>
        public ManageUsersTab()
        {
            // Set all of the tabpage properties
            Location = new Point(4, 22);
            Name = "ManageUsersTab";
            Size = new Size(1071, 816);
            TabIndex = 0;
            Text = "ManageUsers";
            UseVisualStyleBackColor = true;

            // DataGridView of the users
            DgdUsers = new DataGridView
            {
                Anchor = ((AnchorStyles.Top | AnchorStyles.Bottom)
                          | AnchorStyles.Left)
                         | AnchorStyles.Right,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                Location = new Point(3, 3),
                Name = "DgdUsers",
                Size = new Size(1065, 781),
                TabIndex = 0,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                ReadOnly = true,
                MultiSelect = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            };

            // Button for refreshing the list of users
            CmdRefreshList = new Button
            {
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left,
                Location = new Point(3, 790),
                Name = "CmdRefreshList",
                Size = new Size(75, 23),
                TabIndex = 6,
                Text = "Refresh List",
                UseVisualStyleBackColor = true
            };

            // Button for adding a new user, launches NewUserTab
            CmdAddNewUser = new Button
            {
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                AutoEllipsis = true,
                Location = new Point(569, 790),
                Name = "CmdAddNewUser",
                Size = new Size(87, 23),
                TabIndex = 5,
                Text = "Add New User",
                UseVisualStyleBackColor = true
            };

            // Button for changing a users name
            CmdChangeName = new Button
            {
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                AutoEllipsis = true,
                Location = new Point(662, 790),
                Name = "CmdChangeName",
                Size = new Size(85, 23),
                TabIndex = 4,
                Text = "Change name",
                UseVisualStyleBackColor = true
            };

            // Button for changing a users password
            CmdChangePassword = new Button
            {
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                AutoEllipsis = true,
                Location = new Point(753, 790),
                Name = "CmdChangePassword",
                Size = new Size(102, 23),
                TabIndex = 3,
                Text = "Change password",
                UseVisualStyleBackColor = true
            };

            // Button for changing a users system role
            CmdChangeSystemRole = new Button
            {
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                AutoEllipsis = true,
                Location = new Point(861, 790),
                Name = "CmdChangeSystemRole",
                Size = new Size(112, 23),
                TabIndex = 2,
                Text = "Change system role",
                UseVisualStyleBackColor = true
            };

            // Button for deleting a user
            CmdDeleteUser = new Button
            {
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                AutoEllipsis = true,
                Location = new Point(979, 790),
                Name = "CmdDeleteUser",
                Size = new Size(89, 23),
                TabIndex = 1,
                Text = "Delete User",
                UseVisualStyleBackColor = true
            };

            // Event for when the refresh list button is clicked
            CmdRefreshList.Click += CmdRefreshList_Click;

            // Event for when the button is clicked
            CmdAddNewUser.Click += CmdAddNewUser_Click;

            // Event for when the button is clicked, opens a new form
            CmdChangeName.Click += CmdChangeName_Click;

            // Event for when the change password button is clicke, opens a new form
            CmdChangePassword.Click += CmdChangePassword_Click;

            // Event for when delete user is clicked, opens a new form
            CmdDeleteUser.Click += CmdDeleteUser_Click;

            // Event for when change system role is clicked, opens a new form
            CmdChangeSystemRole.Click += CmdChangeSystemRole_Click;

            // Adding all of the controls to the tabpage
            Controls.Add(DgdUsers);
            Controls.Add(CmdRefreshList);
            Controls.Add(CmdAddNewUser);
            Controls.Add(CmdChangeName);
            Controls.Add(CmdChangePassword);
            Controls.Add(CmdChangeSystemRole);
            Controls.Add(CmdDeleteUser);
        }

        private DataGridView DgdUsers { get; set; }
        private Button CmdRefreshList { get; set; }
        private Button CmdAddNewUser { get; set; }
        private Button CmdChangeName { get; set; }
        private Button CmdChangePassword { get; set; }
        private Button CmdChangeSystemRole { get; set; }
        private Button CmdDeleteUser { get; set; }

        private Table DataGridTable { get; set; }

        /// <summary>
        /// Gets the list of users from the server and relays it to RefreshDataHandler
        /// </summary>
        private void CmdRefreshList_Click(object sender, EventArgs e)
        {
            PacketHandler.DataRecieved += RefreshDataHandler;
            Program.SendData("SELECT PK_UserId as 'User Id', First_Name, Second_Name, System_Role FROM tbl_users ORDER BY PK_UserId;");
        }

        /// <summary>
        /// Takes the packet and makes it the datasource of the DataGridView inside this tab(This gets called when data is recieved from client after user has asked for it)
        /// </summary>>
        private void RefreshDataHandler(byte[] packet)
        {
            PacketHandler.DataRecieved -= RefreshDataHandler;
            DataGridTable = new Table(packet);
            Invoke(new MethodInvoker(delegate { DgdUsers.DataSource = DataGridTable.TableData; }));
            Invoke((MethodInvoker) DisableColunmSort);
        }

        /// <summary>
        /// Disable sorting of all columns, may not be needed
        /// </summary>
        private void DisableColunmSort()
        {
            foreach (DataGridViewColumn column in DgdUsers.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        /// <summary>
        /// Gets called when AddNewUser is clicked, it opens a new tab that can add a new user and focus's that tab
        /// </summary>
        private void CmdAddNewUser_Click(object sender, EventArgs e)
        {
            ((TabControl) Parent).TabPages.Add(new AddNewUserTab());
            ((TabControl) Parent).SelectedIndex = ((TabControl) Parent).TabCount - 1;
        }

        /// <summary>
        /// Gets called when user wants to change the name of another user, opens form and sends new data to server and also refreshes the list
        /// </summary>
        private void CmdChangeName_Click(object sender, EventArgs e)
        {
            var row = DgdUsers.SelectedRows;

            if (row.Count != 0)
            {
                var detailsForm = new ChangeUserDetails(1, Convert.ToInt32(row[0].Cells[0].Value.ToString()),
                    row[0].Cells[1].Value.ToString(),
                    row[0].Cells[2].Value.ToString(), row[0].Cells[3].Value.ToString());
                detailsForm.ShowDialog();
                PacketHandler.DataRecieved += CmdChangeName_RecievePacket;
                Program.SendData("UPDATE tbl_users SET First_Name = '" + detailsForm.FirstName + "', Second_Name = '" + detailsForm.LastName + "' WHERE PK_UserId = '" + detailsForm.UserId + "';");
            }
            else
            {
                MessageBox.Show("Please select a row");
            }
        }

        /// <summary>
        /// If we get a message back after changing the name then refresh the DataGrid
        /// </summary>
        /// <param name="packet">A pretty much useless variable</param>
        private void CmdChangeName_RecievePacket(byte[] packet)
        {
            PacketHandler.DataRecieved -= CmdChangeName_RecievePacket;
            Invoke((MethodInvoker)CmdRefreshList.PerformClick);
        }

        /// <summary>
        /// Asks for a new password then salts and hashes and then sends to the server
        /// </summary>
        private void CmdChangePassword_Click(object sender, EventArgs e)
        {
            var row = DgdUsers.SelectedRows;

            if (row.Count != 0)
            {
                var detailsForm = new ChangeUserDetails(2, Convert.ToInt32(row[0].Cells[0].Value.ToString()),
                    row[0].Cells[1].Value.ToString(),
                    row[0].Cells[2].Value.ToString(), row[0].Cells[3].Value.ToString());
                detailsForm.ShowDialog();
                // TODO Change this to inside the dialog form as will be much easier to do
                if (detailsForm.Password == "") return;
                var salt = Utilities.GenerateSaltValue();
                var hash = Utilities.HashPassword(detailsForm.Password, salt, MD5.Create());
                Program.SendData("UPDATE tbl_users SET Salt = '" + salt + "', Password_Hash = '" + hash + "' WHERE PK_UserId = '" + detailsForm.UserId + "';");
            }
            else
            {
                MessageBox.Show("Please select a row");
            }
        }

        /// <summary>
        /// Gets the user id of the selected user and sends to the server to delete
        /// </summary>
        private void CmdDeleteUser_Click(object sender, EventArgs e)
        {
            var row = DgdUsers.SelectedRows;

            if (row.Count != 0)
            {
                PacketHandler.DataRecieved += CmdDeleteUser_PacketRecieved;
                Program.SendData("DELETE FROM tbl_users WHERE PK_UserId = '" + row[0].Cells[0].Value + "';");
            }
            else
            {
                MessageBox.Show("Please select a row");
            }
        }

        /// <summary>
        /// Refreshes the datagridview after we have recieved a success message from the server
        /// </summary>
        /// <param name="packet"></param>
        private void CmdDeleteUser_PacketRecieved(byte[] packet)
        {
            PacketHandler.DataRecieved -= CmdDeleteUser_PacketRecieved;
            Invoke((MethodInvoker)CmdRefreshList.PerformClick);
        }

        /// <summary>
        /// Opens a new form asking for what the users system role is
        /// </summary>
        private void CmdChangeSystemRole_Click(object sender, EventArgs e)
        {
            var row = DgdUsers.SelectedRows;

            if (row.Count != 0)
            {
                var detailsForm = new ChangeUserDetails(3, Convert.ToInt32(row[0].Cells[0].Value.ToString()),
                    row[0].Cells[1].Value.ToString(),
                    row[0].Cells[2].Value.ToString(), row[0].Cells[3].Value.ToString());
                detailsForm.ShowDialog();
                PacketHandler.DataRecieved += CmdChangeSystemRole_PacketRecieved; 
                Program.SendData("UPDATE tbl_users SET System_Role = '" +
                                 detailsForm.SystemRole + "' WHERE PK_UserId = '" + detailsForm.UserId + "';");
            }
            else
            {
                MessageBox.Show("Please select a row");
            }
        }

        /// <summary>
        /// Happens when success message comes in, refreshes the list
        /// </summary>
        /// <param name="packet"></param>
        private void CmdChangeSystemRole_PacketRecieved(byte[] packet)
        {
            PacketHandler.DataRecieved -= CmdChangeSystemRole_PacketRecieved;
            Invoke((MethodInvoker)CmdRefreshList.PerformClick);
        }
    }
}