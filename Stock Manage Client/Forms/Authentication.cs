using System;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Stock_Manage_Client.Classes;
using Stock_Manage_Client.Classes.Networking;
using Stock_Manage_Client.Classes.Networking.Packets;

namespace Stock_Manage_Client.Forms
{
    public partial class Authentication : Form
    {
        public Authentication()
        {
            InitializeComponent();
        }

        private void txt_UserId_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txt_UserId.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txt_UserId.Text = txt_UserId.Text.Remove(txt_UserId.Text.Length - 1);
            }
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            Program.TempReturnTable = null;

            Program.SendData("SELECT Salt,Password_Hash FROM tbl_Users WHERE PK_UserId=" + txt_UserId.Text + ";");

            PacketHandler.DataRecieved += AuthenticatePassword;
        }

        private void AuthenticatePassword(byte[] packet)
        {
            var table = new Table(packet);
            if (table.TableData.Rows.Count > 0)
            {
                var password = Utilities.HashPassword(txt_Psswrd.Text,
                    table.TableData.Rows[0]["Salt"].ToString(), MD5.Create());
                if (password == table.TableData.Rows[0]["Password_Hash"].ToString())
                {
                    Program.UserId = txt_UserId.Text;
                    PacketHandler.DataRecieved -= AuthenticatePassword;
                    Invoke((MethodInvoker) Close);
                    return;
                }
            }
            MessageBox.Show("Login failed, username or password is incorrect");
        }
    }
}