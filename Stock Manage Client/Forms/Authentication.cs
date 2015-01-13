using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Stock_Manage_Client.Classes;

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

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            while (stopwatch.ElapsedMilliseconds < 3000)
            {
                try
                {
                    if (Program.TempReturnTable.TableData.Rows.Count > 0)
                    {
                        var password = Utilities.HashPassword(txt_Psswrd.Text,
                            Program.TempReturnTable.TableData.Rows[0]["Salt"].ToString(), MD5.Create());
                        if (password == Program.TempReturnTable.TableData.Rows[0]["Password_Hash"].ToString())
                        {
                            Program.UserId = txt_UserId.Text;
                            Close();
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }

            if (Program.TempReturnTable != null)
            {
                MessageBox.Show("Login failed, username or password is incorrect");
            }
            else
            {
                MessageBox.Show("Timeout to the server, please try again");
            }
        }
    }
}