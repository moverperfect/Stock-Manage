using System;
using System.Drawing;
using System.Windows.Forms;

namespace Stock_Manage_Client.Classes.TabPages
{
    internal class ManageUsersTab : TabPage
    {
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
                TabIndex = 0
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

        private void CmdAddNewUser_Click(object sender, EventArgs e)
        {
            ((TabControl) Parent).TabPages.Add(new AddNewUserTab());
            ((TabControl) Parent).SelectedIndex = ((TabControl) Parent).TabCount - 1;
        }

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