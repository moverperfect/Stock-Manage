using System;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Stock_Manage_Client.Classes;
using Stock_Manage_Client.Classes.Networking;
using Stock_Manage_Client.Classes.Networking.Packets;

namespace Stock_Manage_Client.Forms
{
    /// <summary>
    /// A form that allows users to authenticate themselves and log into the system
    /// </summary>
    internal partial class Authentication : Form
    {
        /// <summary>
        /// The permission level that the form requires
        /// </summary>
        private readonly int _userLevel;

        /// <summary>
        /// Initialises the form with a specified permission level
        /// </summary>
        /// <param name="userLevel">The permission level that is required</param>
        public Authentication(string userLevel)
        {
            InitializeComponent();

            // Set the permission level that has been requested
            switch (userLevel)
            {
                case "o":
                    _userLevel = 2;
                    break;

                case "m":
                    _userLevel = 3;
                    break;

                default:
                    _userLevel = 1;
                    break;
            }
        }

        /// <summary>
        /// Initialises the form with a specified user id already entered
        /// </summary>
        /// <param name="userId">The user id that will already be in the textbox</param>
        public Authentication(int userId)
        {
            InitializeComponent();
            txt_UserId.Text = userId.ToString();
            txt_UserId.Enabled = false;
        }

        /// <summary>
        /// Happens when the user id text box is changed, makes sure that only numbers enter the textbox
        /// </summary>
        private void txt_UserId_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txt_UserId.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txt_UserId.Text = txt_UserId.Text.Remove(txt_UserId.Text.Length - 1);
            }
        }

        /// <summary>
        /// Happens when the password text box is changed, makes sure that only numbers enter the textbox
        /// </summary>
        private void txt_Psswrd_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txt_Psswrd.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txt_Psswrd.Text = txt_Psswrd.Text.Remove(txt_Psswrd.Text.Length - 1);
            }
        }

        /// <summary>
        /// Happens when the login button is clicked, sends a sql string to the server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Login_Click(object sender, EventArgs e)
        {
            Program.SendData("SELECT Salt,Password_Hash,System_Role FROM tbl_Users WHERE PK_UserId=" + txt_UserId.Text +
                             ";");

            PacketHandler.DataRecieved += AuthenticatePassword;
        }

        /// <summary>
        /// When we recieve the data about the requested user, authenticate the user
        /// </summary>
        /// <param name="packet">Table data containing nessecary information about the requested user</param>
        private void AuthenticatePassword(byte[] packet)
        {
            PacketHandler.DataRecieved -= AuthenticatePassword;
            var table = new Table(packet);

            // If the user was found
            if (table.TableData.Rows.Count > 0)
            {
                // Get and set the user's permission level
                int newUserLevel;
                switch (table.TableData.Rows[0]["System_Role"].ToString())
                {
                    case "Management":
                        newUserLevel = 3;
                        break;

                    case "Ordering":
                        newUserLevel = 2;
                        break;

                    default:
                        newUserLevel = 1;
                        break;
                }

                // Make sure the user is a high enough permission level
                if (newUserLevel < _userLevel)
                {
                    MessageBox.Show("Error: Permissions not high enough, unable to log into the system");
                    return;
                }

                // Make sure the passwords match and then close the form
                var password = Utilities.HashPassword(txt_Psswrd.Text,
                    table.TableData.Rows[0]["Salt"].ToString(), MD5.Create());
                if (password == table.TableData.Rows[0]["Password_Hash"].ToString())
                {
                    Program.UserId = txt_UserId.Text;
                    Program.OnUserIdChanged(this, EventArgs.Empty);
                    Invoke((MethodInvoker) Close);
                    return;
                }
            }
            MessageBox.Show("Login failed, username or password is incorrect");
        }
    }
}