using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Stock_Manage_Client.Classes;
using Stock_Manage_Client.Classes.Networking;
using Stock_Manage_Client.Classes.Networking.Packets;

namespace Stock_Manage_Client.Forms
{
    public partial class AddChangeProduct : Form
    {
        private DataTable _dataGridTable = new DataTable();

        /// <summary>
        /// Initializes the form and updates the suppliers datagridview
        /// </summary>
        public AddChangeProduct()
        {
            InitializeComponent();
            UpdateSuppliers(null);
        }

        /// <summary>
        /// Updates the datagridview
        /// </summary>
        /// <param name="packet">Either null or the packet that has the data in it</param>
        private void UpdateSuppliers(byte[] packet)
        {
            if (packet == null)
            {
                PacketHandler.DataRecieved += UpdateSuppliers;
                Program.SendData("SELECT PK_SupplierId as 'Supplier Id', Name FROM tbl_suppliers;");
            }
            else
            {
                PacketHandler.DataRecieved -= UpdateSuppliers;
                _dataGridTable = new Table(packet).TableData;
                Invoke(new MethodInvoker(delegate { dgdSuppliers.DataSource = _dataGridTable; }));
            }
        }

        /// <summary>
        /// Happens when addproduct is clicked, opens a new form asking for all of the data and then sends it all to the server
        /// </summary>
        private void cmdAddProduct_Click(object sender, EventArgs e)
        {
            var row = dgdSuppliers.SelectedRows;
            if (row.Count == 0)
            {
                MessageBox.Show("Please select a supplier");
                return;
            }
            PacketHandler.DataRecieved += cmdAddProduct_DataRecieved;
            var values = string.Join("','",
                new[]
                {
                    txtBarcode.Text, txtName.Text, txtDescription.Text, txtLocation.Text, txtQuantity.Text,
                    txtPurchasePrice.Text, txtUnitsInCase.Text, row[0].Cells[0].Value, txtCriticalLevel.Text,
                    txtNominalLevel.Text
                });
            Program.SendData(
                "INSERT INTO tbl_products(Barcode,Name,Description,Location,Quantity,Purchase_Price,Units_In_Case,FK_SupplierId,Critical_Level,Nominal_Level) VALUES('" +
                values + "');");
        }

        /// <summary>
        /// Closes the form when we get a success message back from the server
        /// </summary>
        private void cmdAddProduct_DataRecieved(byte[] packet)
        {
            PacketHandler.DataRecieved -= cmdAddProduct_DataRecieved;
            Close();
        }

        /// <summary>
        /// Happens when user clicks cancel, closes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region Data Validation for all of the number input textboxes

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

        #endregion
    }
}