using Stock_Manage_Client.Classes;
using Stock_Manage_Client.Classes.Networking;
using Stock_Manage_Client.Classes.Networking.Packets;
using System;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Stock_Manage_Client.Forms
{
    /// <summary>
    /// A standard new user window used for management
    /// </summary>
    public partial class AddNewUser : Form
    {
        public AddNewUser()
        {
            InitializeComponent();
        }

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
            PacketHandler.DataRecieved -= AddNewUser_DataRecieved;
            try
            {
                // Create table and check if it has rows, if so then display a messagebox of the user id
                var table = new Table(packet);
                if (table.TableData.Rows.Count > 0)
                {
                    MessageBox.Show("New user created with UserId of " +
                                    table.TableData.Rows[0][0]);
                    Invoke(new MethodInvoker(Close));
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
