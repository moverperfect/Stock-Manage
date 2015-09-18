using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Stock_Manage_Client.Classes;
using Stock_Manage_Client.Classes.Networking;
using Stock_Manage_Client.Classes.Networking.Packets;

namespace Stock_Manage_Client.Forms
{
    /// <summary>
    /// Form to allow the adding and changing of a product
    /// </summary>
    public partial class AddChangeProduct : Form
    {
        /// <summary>
        /// Contains the product id, is only used when changing a products details
        /// </summary>
        private readonly int _productId;

        /// <summary>
        /// Contains the supplierId that is used to determine the supplier for changing a products details
        /// </summary>
        private readonly int _supplierId;

        /// <summary>
        /// Datagridtable that contains the information for the suppliers for the datagridview
        /// </summary>
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
        /// Initializes the form and updates the suppliers datagridview and sets all of the text boxes to their correct value
        /// </summary>
        /// <param name="productId">The product id</param>
        /// <param name="barcode">The product barcode</param>
        /// <param name="name">The products name</param>
        /// <param name="description">The products descripton</param>
        /// <param name="location">The products location</param>
        /// <param name="quantity">The quantity of the product</param>
        /// <param name="purchasePrice">The purchase price of the product</param>
        /// <param name="unitsInCase">The number of units in a case of the product</param>
        /// <param name="supplierId">The Suppier id for the product</param>
        /// <param name="criticalValue">The critical value for the product</param>
        /// <param name="nominalLevel">The nominal value for the product</param>
        public AddChangeProduct(int productId, string barcode, string name, string description, string location,
            int quantity, string purchasePrice, string unitsInCase, int supplierId, int criticalValue, int nominalLevel)
        {
            InitializeComponent();

            _supplierId = supplierId;
            _productId = productId;

            UpdateSuppliers(null);

            txtName.Text = name;
            txtBarcode.Text = barcode;
            txtDescription.Text = description;
            txtLocation.Text = location;
            txtQuantity.Text = quantity.ToString();
            txtPurchasePrice.Text = purchasePrice;
            txtUnitsInCase.Text = unitsInCase;
            txtCriticalLevel.Text = criticalValue.ToString();
            txtNominalLevel.Text = nominalLevel.ToString();

            // Funny thing, there is not enough space for product in this sentance so it only shows change
            cmdAddProduct.Text = "Change Product";
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

                // If we are changing a product and not just adding a new one
                if (_supplierId != 0)
                {
                    for (var i = 0; i < dgdSuppliers.Rows.Count; i++)
                    {
                        if (dgdSuppliers.Rows[i].Cells[0].Value.ToString() == _supplierId.ToString())
                        {
                            dgdSuppliers.Rows[i].Selected = true;
                        }
                    }
                }
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

            // If we are adding a product and not changing one
            if (_supplierId == 0)
            {
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
            else
            {
                // Else update the product details
                var update =
                    "UPDATE tbl_products SET Barcode='" + txtBarcode.Text + "',Name='" + txtName.Text +
                    "',Description='" +
                    txtDescription.Text + "',Location='" + txtLocation.Text + "',Quantity='" + txtQuantity.Text +
                    "',Purchase_Price='" + txtPurchasePrice.Text + "',Units_In_Case='" + txtUnitsInCase.Text +
                    "',FK_SupplierId='" + row[0].Cells[0].Value + "',Critical_Level='" + txtCriticalLevel.Text +
                    "',Nominal_Level='" + txtNominalLevel.Text + "' WHERE PK_ProductId='" + _productId + "';";
                Program.SendData(update);
            }
        }

        /// <summary>
        /// Closes the form when we get a success message back from the server
        /// </summary>
        private void cmdAddProduct_DataRecieved(byte[] packet)
        {
            PacketHandler.DataRecieved -= cmdAddProduct_DataRecieved;
            Invoke((MethodInvoker) Close);
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

        /// <summary>
        /// Data validation on all of the textboxes in the form that require it
        /// </summary>
        /// <param name="sender">The textbox that needs the validation</param>
        /// <param name="e">Unused</param>
        private void ValidateText(object sender, EventArgs e)
        {
            if (Regex.IsMatch(((TextBox)sender).Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                ((TextBox)sender).Text = ((TextBox)sender).Text.Remove(((TextBox)sender).Text.Length - 1);
            }
        }

        #endregion
    }
}