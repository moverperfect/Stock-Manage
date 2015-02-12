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
    public partial class InputNumberPad : Form
    {
        public int Quantity = 0;

        public InputNumberPad()
        {
            InitializeComponent();
        }

        public void cmdNumber_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            updInput.Text = ((int.Parse(updInput.Text)*10) + int.Parse(btn.Text)).ToString();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            updInput.Text = "0";
        }

        private void cmdAccept_Click(object sender, EventArgs e)
        {
            Quantity = int.Parse(updInput.Text);
            Close();
        }
    }
}
