using System;
using System.Data;
using System.Drawing;
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
                MultiSelect = false
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

            CmdRefreshList.Click += CmdRefreshList_Click;

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

            // Event for when the button is clicked
            CmdAddNewUser.Click += CmdAddNewUser_Click;

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

            // Event for when the button is clicked, opens a new form
            CmdChangeName.Click += CmdChangeName_Click;

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

            // Anchoring just doesn't work, so yay for workarounds
            SizeChanged += ManageUsers_SizeChanged;

            // Adding all of the controls to the tabpage
            Controls.Add(DgdUsers);
            Controls.Add(CmdRefreshList);
            Controls.Add(CmdAddNewUser);
            Controls.Add(CmdChangeName);
            Controls.Add(CmdChangePassword);
            Controls.Add(CmdChangeSystemRole);
            Controls.Add(CmdDeleteUser);

            // Set all of the tabpage properties
            Location = new Point(4, 22);
            Name = "ManageUsersTab";
            Size = new Size(1071, 816);
            TabIndex = 0;
            Text = "ManageUsers";
            UseVisualStyleBackColor = true;
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
            Program.SendData("SELECT PK_UserId as 'User Id', First_Name, Second_Name, System_Role FROM tbl_users;");
        }

        /// <summary>
        /// Takes the packet and makes it the datasource of the DataGridView inside this tab(This gets called when data is recieved from client after user has asked for it)
        /// </summary>>
        private void RefreshDataHandler(byte[] packet)
        {
            DataGridTable = new Table(packet);
            Invoke(new MethodInvoker(delegate { DgdUsers.DataSource = DataGridTable.TableData; }));
            Invoke((MethodInvoker) DisableColunmSort);
            PacketHandler.DataRecieved -= RefreshDataHandler;
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmdAddNewUser_Click(object sender, EventArgs e)
        {
            ((TabControl) Parent).TabPages.Add(new AddNewUserTab());
            ((TabControl) Parent).SelectedIndex = ((TabControl) Parent).TabCount - 1;
        }

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

        private void CmdChangeName_RecievePacket(byte[] packet)
        {
            PacketHandler.DataRecieved -= CmdChangeName_RecievePacket;
            CmdRefreshList_Click(new object(),new EventArgs());
            //Invoke(new MethodInvoker(CmdRefreshList_Click(new object(), new EventArgs())));
        }

        /// <summary>
        /// Resizes all of the elements to fit inside the tab page because anchoring just doesn't want to work
        /// </summary>
        private void ManageUsers_SizeChanged(object sender, EventArgs e)
        {
            DgdUsers.Size = new Size(Size.Width - 6, Size.Height - 35);
            CmdRefreshList.Location = new Point(3, Size.Height - 26);
            CmdAddNewUser.Location = new Point(Size.Width - 502, Size.Height - 26);
            CmdChangeName.Location = new Point(Size.Width - 409, Size.Height - 26);
            CmdChangePassword.Location = new Point(Size.Width - 318, Size.Height - 26);
            CmdChangeSystemRole.Location = new Point(Size.Width - 210, Size.Height - 26);
            CmdDeleteUser.Location = new Point(Size.Width - 92, Size.Height - 26);
        }
    }
}