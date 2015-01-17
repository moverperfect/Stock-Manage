using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Stock_Manage_Client.Forms
{
    public partial class AddChangeProduct : Form
    {
        public AddChangeProduct()
        {
            InitializeComponent();
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtQuantity.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtQuantity.Text = txtQuantity.Text.Remove(txtQuantity.Text.Length - 1);
            }
        }

        private void txtUnitsInCase_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtUnitsInCase.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtUnitsInCase.Text = txtUnitsInCase.Text.Remove(txtUnitsInCase.Text.Length - 1);
            }
        }

        private void txtCriticalLevel_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtCriticalLevel.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtCriticalLevel.Text = txtCriticalLevel.Text.Remove(txtCriticalLevel.Text.Length - 1);
            }
        }

        private void txtNominalLevel_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtNominalLevel.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtNominalLevel.Text = txtNominalLevel.Text.Remove(txtNominalLevel.Text.Length - 1);
            }
        }
    }
}
