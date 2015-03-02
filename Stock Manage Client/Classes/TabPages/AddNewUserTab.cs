using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Stock_Manage_Client.Classes.Networking;
using Stock_Manage_Client.Classes.Networking.Packets;

namespace Stock_Manage_Client.Classes.TabPages
{
    /// <summary>
    /// A standard new user tab used for management inherits from TabPage
    /// </summary>
    internal class AddNewUserTab : TabPage
    {
        /// <summary>
        /// Empty constructor for the new tab
        /// </summary>
        public AddNewUserTab()
        {
            // Add new user button
            CmdAddUser = new Button
            {
                Location = new Point(9, 130),
                Name = "CmdAddUser",
                Size = new Size(75, 23),
                TabIndex = 5,
                Text = "Add User",
                UseVisualStyleBackColor = true,
            };

            // TextBox for the password
            TxtPassword = new TextBox
            {
                Location = new Point(89, 70),
                Name = "TxtPassword",
                PasswordChar = '*',
                Size = new Size(100, 20),
                TabIndex = 3
            };

            // Textbox for entering last name
            TxtLastName = new TextBox
            {
                Location = new Point(89, 40),
                Name = "TxtLastName",
                Size = new Size(100, 20),
                TabIndex = 2
            };

            // Textbox for entering first name
            TxtFirstName = new TextBox
            {
                Location = new Point(89, 10),
                Name = "TxtFirstName",
                Size = new Size(100, 20),
                TabIndex = 1
            };

            // Label showing where to enter the password
            LblPassword = new Label
            {
                AutoSize = true,
                Location = new Point(6, 70),
                Name = "LblPassword",
                Size = new Size(53, 13),
                TabIndex = 0,
                Text = "Password"
            };

            // Label showing where to enter the second name
            LblSecondName = new Label
            {
                AutoSize = true,
                Location = new Point(6, 40),
                Name = "LblSecondName",
                Size = new Size(75, 13),
                TabIndex = 0,
                Text = "Second Name"
            };

            // Label showing where to enter the first name
            LblFirstName = new Label
            {
                AutoSize = true,
                Location = new Point(6, 10),
                Name = "LblFirstName",
                Size = new Size(57, 13),
                TabIndex = 0,
                Text = "First Name"
            };

            // ComboBox acting as a drop down list showing the system roles that are available
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
                TabIndex = 4,
                Items = {"Management", "Ordering", "Workshop"}
            };

            // Label showing where to enter the system role of the user
            LblSystemRole = new Label
            {
                AutoSize = true,
                Location = new Point(6, 100),
                Name = "LblSystemRole",
                Size = new Size(57, 13),
                TabIndex = 0,
                Text = "System Role"
            };

            // Add event handlers for button and textbox
            CmdAddUser.Click += CmdAddUser_Click;
            TxtPassword.TextChanged += TxtPassword_TextChanged;

            // Adding all of the controls to the tabpage
            Controls.Add(CmdAddUser);
            Controls.Add(TxtPassword);
            Controls.Add(TxtLastName);
            Controls.Add(TxtFirstName);
            Controls.Add(CboSystemRole);
            Controls.Add(LblPassword);
            Controls.Add(LblSecondName);
            Controls.Add(LblFirstName);
            Controls.Add(LblSystemRole);

            // Set the location, name, padding, tabIndex, text[ of the tabpage
            Location = new Point(4, 22);
            Name = "NewUserTab";
            Padding = new Padding(3);
            TabIndex = 0;
            Text = "Add New User";
            UseVisualStyleBackColor = true;
        }

        /// <summary>
        /// Label that shows the user where the first name text box is
        /// </summary>
        private Label LblFirstName { get; set; }

        /// <summary>
        /// Label that shows the user where the second name text box is
        /// </summary>
        private Label LblSecondName { get; set; }

        /// <summary>
        /// Label that shows the user where the password text box is
        /// </summary>
        private Label LblPassword { get; set; }

        /// <summary>
        /// Label that shows the user where the system role box is
        /// </summary>
        private Label LblSystemRole { get; set; }

        /// <summary>
        /// Button that adds the user to the system
        /// </summary>
        private Button CmdAddUser { get; set; }

        /// <summary>
        /// Textbox for entering password into the system
        /// </summary>
        private TextBox TxtPassword { get; set; }

        /// <summary>
        /// Textbox for entering Last name
        /// </summary>
        private TextBox TxtLastName { get; set; }
        
        /// <summary>
        /// Textbox for entering first name
        /// </summary>
        private TextBox TxtFirstName { get; set; }

        /// <summary>
        /// The combobox that allows the user to select the system role of the user
        /// </summary>
        private ComboBox CboSystemRole { get; set; }

        /// <summary>
        /// Happens when the user clicks add new user, generates a salt, hashes the password then sends new user to the database and gets back the new user id
        /// </summary>
        private void CmdAddUser_Click(object sender, EventArgs e)
        {
            // If there is missing information
            if (TxtFirstName.Text == "" || TxtLastName.Text == "" || TxtPassword.Text == "" || CboSystemRole.Text == "")
            {
                MessageBox.Show("Missing information, insert and try again");
                return;
            }

            // Salt and hash the password
            var salt = Utilities.GenerateSaltValue();
            var hash = Utilities.HashPassword(TxtPassword.Text, salt, MD5.Create());

            // Create the two strings, one to insert the user and one to grab the user id
            var addString =
                "INSERT INTO tbl_Users(System_Role, First_Name, Second_Name, Password_Hash, Salt) VALUES ('" +
                CboSystemRole.Text + "','" + TxtFirstName.Text + "','" + TxtLastName.Text + "','" + hash + "','" + salt +
                "');";
            var selectString = "SELECT PK_UserId FROM tbl_Users WHERE Password_Hash = '" + hash + "';";

            // Add AddNewUserResponse to event handler for datareceiving
            PacketHandler.DataRecieved += AddNewUser_DataRecieved;

            // Send the SQL statement to the server with the custom packettype of 2002(SELECT statement)
            Program.SendData(new StdData(addString + selectString, Convert.ToUInt16(Program.MachineId),
                Convert.ToUInt16(Program.UserId), 2002));
        }

        /// <summary>
        /// Happens when data is received after we have sent of new user information]
        /// </summary>
        /// <param name="packet">The packet that we get back from the server</param>
        private void AddNewUser_DataRecieved(byte[] packet)
        {
            try
            {
                // Create table and check if it has rows, if so then display a messagebox of the user id
                var table = new Table(packet);
                if (table.TableData.Rows.Count > 0)
                {
                    MessageBox.Show("New user created with UserId of " +
                                    table.TableData.Rows[0][0]);
                }
                else
                {
                    // Else show a error message
                    MessageBox.Show("Failed to add new user, please try again or contact a system administrator");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                PacketHandler.DataRecieved -= AddNewUser_DataRecieved;
            }
        }

        /// <summary>
        /// Ensures that the user can only enter numbers into the password
        /// </summary>
        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(TxtPassword.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                TxtPassword.Text = TxtPassword.Text.Remove(TxtPassword.Text.Length - 1);
            }
        }
    }
}