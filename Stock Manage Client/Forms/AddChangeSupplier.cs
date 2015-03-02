using System;
using System.Windows.Forms;
using Stock_Manage_Client.Classes;
using Stock_Manage_Client.Classes.Networking;

namespace Stock_Manage_Client.Forms
{
    /// <summary>
    /// Allows the adding and changing of a suppliers details
    /// </summary>
    public partial class AddChangeSupplier : Form
    {
        /// <summary>
        /// Contains the supplierId that is used when changing details about a supplier, is not used when adding a new one
        /// </summary>
        private readonly int _supplierId;

        /// <summary>
        /// Initialises the form for adding a supplier
        /// </summary>
        public AddChangeSupplier()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialises the form with for changing a supplier, needs existing supplier information
        /// </summary>
        /// <param name="supplierId">The id of the supplier</param>
        /// <param name="name">The name of the supplier</param>
        /// <param name="address1">Address Line 1 of the supplier</param>
        /// <param name="address2">Address Line 2 of the supplier</param>
        /// <param name="address3">Address Line 3 of the supplier</param>
        /// <param name="city">Supplier city</param>
        /// <param name="postcode">Postcode of the supplier</param>
        /// <param name="contact">Contact of the supplier</param>
        /// <param name="telephone">Telephone of the supplier</param>
        /// <param name="type">Type of the supplier</param>
        public AddChangeSupplier(int supplierId, string name, string address1, string address2, string address3,
            string city, string postcode, string contact, string telephone, string type)
        {
            InitializeComponent();

            _supplierId = supplierId;

            txtName.Text = name;
            txtAddress1.Text = address1;
            txtAddress2.Text = address2;
            txtAddress3.Text = address3;
            txtCity.Text = city;
            txtPostcode.Text = postcode;
            txtContact.Text = contact;
            txtTelephone.Text = telephone;
            txtType.Text = type;

            cmdAddSupplier.Text = "Change Supplier";
        }

        /// <summary>
        /// Sends the new supplier information to the server to add it
        /// </summary>
        private void cmdAddSupplier_Click(object sender, EventArgs e)
        {
            PacketHandler.DataRecieved += cmdAddSupplier_DataRecieved;

            // If we are adding and not changing a supplier then insert and if not then update
            if (_supplierId == 0)
            {
                var values = string.Join("','",
                    new[]
                    {
                        txtName.Text, txtAddress1.Text, txtAddress2.Text, txtAddress3.Text, txtCity.Text,
                        txtPostcode.Text,
                        txtContact.Text, txtTelephone.Text, txtType.Text
                    });
                Program.SendData(
                    "INSERT INTO tbl_suppliers(Name, AddressLine1, AddressLine2, AddressLine3, City, Postcode, Contact, Telephone, type) VALUES ('" +
                    values + "');");
            }
            else
            {
                var update =
                    "UPDATE tbl_suppliers SET Name='" + txtName.Text + "',AddressLine1='" + txtAddress1.Text +
                    "',AddressLine2='" + txtAddress2.Text + "',AddressLine3='" + txtAddress3.Text + "',City='" +
                    txtCity.Text + "',Postcode='" + txtPostcode.Text + "',Contact='" + txtContact.Text + "',Telephone='" +
                    txtTelephone.Text + "',Type='" + txtType.Text + "' WHERE PK_SupplierId = '" + _supplierId + "';";
                Program.SendData(update);
            }
        }

        /// <summary>
        /// Closes the dialog when the server replies back
        /// </summary>
        private void cmdAddSupplier_DataRecieved(byte[] packet)
        {
            PacketHandler.DataRecieved -= cmdAddSupplier_DataRecieved;
            Invoke((MethodInvoker) Close);
        }

        /// <summary>
        /// When user clicks cancel, will close the dialog
        /// </summary>
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}