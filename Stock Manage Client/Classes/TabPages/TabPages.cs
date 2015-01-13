using System;
using System.Drawing;
using System.Windows.Forms;

namespace Stock_Manage_Client.Classes.TabPages
{
    internal class AddNewUserTab : TabPage
    {
        public AddNewUserTab()
        {
            var cmdExitTab = new Button
            {
                Location = new Point(114, 95),
                Name = "btn_ExitTab",
                Size = new Size(75, 23),
                TabIndex = 7,
                Text = "Exit Tab",
                UseVisualStyleBackColor = true
            };

            var cmdAddUser = new Button
            {
                Location = new Point(9, 95),
                Name = "btn_AddUser",
                Size = new Size(75, 23),
                TabIndex = 6,
                Text = "Add User",
                UseVisualStyleBackColor = true
            };

            var txtPassword = new TextBox
            {
                Location = new Point(89, 63),
                Name = "textBox3",
                PasswordChar = '*',
                Size = new Size(100, 20),
                TabIndex = 5
            };

            var txtLastName = new TextBox
            {
                Location = new Point(89, 37),
                Name = "textBox2",
                Size = new Size(100, 20),
                TabIndex = 4
            };

            var txtFirstName = new TextBox
            {
                Location = new Point(89, 11),
                Name = "textBox1",
                Size = new Size(100, 20),
                TabIndex = 3
            };

            var lblPassword = new Label
            {
                AutoSize = true,
                Location = new Point(6, 66),
                Name = "label3",
                Size = new Size(53, 13),
                TabIndex = 2,
                Text = "Password"
            };

            var lblSecondName = new Label
            {
                AutoSize = true,
                Location = new Point(6, 40),
                Name = "label2",
                Size = new Size(75, 13),
                TabIndex = 1,
                Text = "Second Name"
            };

            var lblFirstName = new Label
            {
                AutoSize = true,
                Location = new Point(6, 11),
                Name = "label1",
                Size = new Size(57, 13),
                TabIndex = 0,
                Text = "First Name"
            };


            cmdAddUser.Click += cmdAddUser_Click;

            Controls.Add(cmdExitTab);
            Controls.Add(cmdAddUser);
            Controls.Add(txtPassword);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Controls.Add(lblPassword);
            Controls.Add(lblSecondName);
            Controls.Add(lblFirstName);
            Location = new Point(4, 22);
            Name = "NewUserTab";
            Padding = new Padding(3);
            TabIndex = 0;
            Text = "Add New User";
            UseVisualStyleBackColor = true;
        }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        private void cmdAddUser_Click(object sender, EventArgs e)
        {
        }
    }
}