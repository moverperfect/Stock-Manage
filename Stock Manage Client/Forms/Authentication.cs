using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
