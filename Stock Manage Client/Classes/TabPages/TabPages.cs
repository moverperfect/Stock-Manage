using System;
using System.Diagnostics;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Stock_Manage_Client.Classes.Networking;
using Stock_Manage_Client.Classes.Networking.Packets;

namespace Stock_Manage_Client.Classes.TabPages
{
    internal class AddNewUserTab : TabPage
    {
        public AddNewUserTab()
        {
            CmdAddUser = new Button
            {
                Location = new Point(9, 130),
                Name = "CmdAddUser",
                Size = new Size(75, 23),
                TabIndex = 6,
                Text = "Add User",
                UseVisualStyleBackColor = true,
            };

            CmdAddUser.Click += CmdAddUser_Click;

            TxtPassword = new TextBox
            {
                Location = new Point(89, 70),
                Name = "TxtPassword",
                PasswordChar = '*',
                Size = new Size(100, 20),
                TabIndex = 5
            };

            TxtLastName = new TextBox
            {
                Location = new Point(89, 40),
                Name = "TxtLastName",
                Size = new Size(100, 20),
                TabIndex = 4
            };

            TxtFirstName = new TextBox
            {
                Location = new Point(89, 10),
                Name = "TxtFirstName",
                Size = new Size(100, 20),
                TabIndex = 3
            };


            LblPassword = new Label
            {
                AutoSize = true,
                Location = new Point(6, 70),
                Name = "LblPassword",
                Size = new Size(53, 13),
                TabIndex = 2,
                Text = "Password"
            };

            LblSecondName = new Label
            {
                AutoSize = true,
                Location = new Point(6, 40),
                Name = "LblSecondName",
                Size = new Size(75, 13),
                TabIndex = 1,
                Text = "Second Name"
            };

            LblFirstName = new Label
            {
                AutoSize = true,
                Location = new Point(6, 10),
                Name = "LblFirstName",
                Size = new Size(57, 13),
                TabIndex = 0,
                Text = "First Name"
            };

            CboSystemRole = new ComboBox
            {
                AutoCompleteMode = AutoCompleteMode.SuggestAppend,
                AutoCompleteSource = AutoCompleteSource.ListItems,
                BackColor = SystemColors.Window,
                DropDownStyle = ComboBoxStyle.DropDownList,
                FormattingEnabled = true,
                Location = new Point(89, 100),
                Name = "CboSystemRole",
                Size = new Size(100, 20),
                TabIndex = 29,
                Items = { "Management", "Ordering", "Workshop"}
            };

            LblSystemRole = new Label
            {
                AutoSize = true,
                Location = new Point(6, 100),
                Name = "LblSystemRole",
                Size = new Size(57, 13),
                TabIndex = 0,
                Text = "System Role"
            };

            Controls.Add(CmdAddUser);
            Controls.Add(TxtPassword);
            Controls.Add(TxtLastName);
            Controls.Add(TxtFirstName);
            Controls.Add(CboSystemRole);
            Controls.Add(LblPassword);
            Controls.Add(LblSecondName);
            Controls.Add(LblFirstName);
            Controls.Add(LblSystemRole);
            Location = new Point(4, 22);
            Name = "NewUserTab";
            Padding = new Padding(3);
            TabIndex = 0;
            Text = "Add New User";
            UseVisualStyleBackColor = true;
        }

        private Label LblFirstName { get; set; }
        private Label LblSecondName { get; set; }
        private Label LblPassword { get; set; }
        private Label LblSystemRole { get; set; }
        private Button CmdAddUser { get; set; }
        private TextBox TxtPassword { get; set; }
        private TextBox TxtLastName { get; set; }
        private TextBox TxtFirstName { get; set; }
        private ComboBox CboSystemRole { get; set; }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        private void CmdAddUser_Click(object sender, EventArgs e)
        {
            Program.TempReturnTable = null;
            var salt = Utilities.GenerateSaltValue();
            var hash = Utilities.HashPassword(TxtPassword.Text, salt, MD5.Create());
            var addString =
                "INSERT INTO tbl_Users(System_Role, First_Name, Second_Name, Password_Hash, Salt) VALUES ('"+CboSystemRole.Text+"','"+TxtFirstName.Text+"','"+TxtLastName.Text+"','"+hash+"','"+salt+"');";
            var selectString = "SELECT PK_UserId FROM tbl_Users WHERE Password_Hash = '" + hash + "';";
            PacketHandler.DataRecieved += AddNewUserResponse;
            Program.SendData(new StdData(addString + selectString, Convert.ToUInt16(Program.MachineId), Convert.ToUInt16(Program.UserId), 2002));
        }

        private void AddNewUserResponse(byte[] packet)
        {
            try
            {
                var table = new Table(packet);
                if (table.TableData.Rows.Count > 0)
                {
                    MessageBox.Show("New user created with UserId of " +
                                    table.TableData.Rows[0][0].ToString());
                }
                else
                {
                    MessageBox.Show("Failed to add new user, please try again or contact a system administrator");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}