using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Stock_Manage_Client.Classes;
using System.Diagnostics;

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
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_UserId.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txt_UserId.Text = txt_UserId.Text.Remove(txt_UserId.Text.Length - 1);
            }
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            Program.TempReturnTable = null;
            Program.SendData("SELECT * FROM tbl_users WHERE UserName='" + this.txt_UserId.Text + "' AND password='" + txt_Psswrd.Text + "';");
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            while (stopwatch.ElapsedMilliseconds < 3000)
            {
                try
                {
                    if (Program.TempReturnTable.TableData.Rows.Count > 0)
                    {
                        Program.UserId = txt_UserId.Text;
                        this.Close();
                        return;
                    }
                }
                catch(Exception ex){}
            }

            if (Program.TempReturnTable != null)
            {
                MessageBox.Show("Login failed, username or password is incorrect");
            }
        }
    }
}
