using System;
using System.Security.Authentication.ExtendedProtection.Configuration;
using System.Windows.Forms;
using Stock_Manage_Client.Classes;
using Stock_Manage_Client.Classes.Networking;

namespace Stock_Manage_Client.Forms
{
    public partial class AddChangeSupplier : Form
    {
        /// <summary>
        /// Contains the supplierId that is used when changing details about a supplier, is not used when adding a new one
        /// </summary>
        private int SupplierId;

        /// <summary>
        /// Initialises the form for adding a supplier
        /// </summary>
        public AddChangeSupplier()
        {
            InitializeComponent();
        }

        public AddChangeSupplier(int supplierId, string name, string address1, string address2, string address3,
            string city, string postcode, string contact, string telephone, string type)
        {
            InitializeComponent();

            SupplierId = supplierId;

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
            var values = string.Join("','",
                new[]
                {
                    txtName.Text, txtAddress1.Text, txtAddress2.Text, txtAddress3.Text, txtCity.Text, txtPostcode.Text,
                    txtContact.Text, txtTelephone.Text, txtType.Text
                });
            Program.SendData(
                "INSERT INTO tbl_suppliers(Name, AddressLine1, AddressLine2, AddressLine3, City, Postcode, Contact, Telephone, type) VALUES ('" +
                values + "');");
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