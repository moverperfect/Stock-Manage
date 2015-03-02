using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Stock_Manage_Client.Forms
{
    /// <summary>
    /// Allows the user to change a users details
    /// TODO Change this to do sql inhouse
    /// </summary>
    public partial class ChangeUserDetails : Form
    {
        /// <summary>
        /// Initialises the form
        /// </summary>
        public ChangeUserDetails()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialises the form with the specified case
        /// </summary>
        /// <param name="caseNo">1 = change name, 2 = change password, 3 = change system role, 4 = change everything</param>
        /// <param name="userId">The user id of the user</param>
        /// <param name="firstName">The first name of the user</param>
        /// <param name="lastName">The last name of the user</param>
        /// <param name="systemRole">The system role of the user</param>
        public ChangeUserDetails(int caseNo, int userId, string firstName, string lastName, string systemRole)
        {
            InitializeComponent();
            txtUserId.Text = userId.ToString();
            txtUserId.Enabled = false;

            txtFirstName.Text = firstName;
            txtLastName.Text = lastName;
            cboSystemRole.Text = systemRole;
            switch (caseNo)
            {
                case 1:
                    txtPassword.Enabled = false;
                    cboSystemRole.Enabled = false;
                    break;
                case 2:
                    txtFirstName.Enabled = false;
                    txtLastName.Enabled = false;
                    cboSystemRole.Enabled = false;
                    break;
                case 3:
                    txtFirstName.Enabled = false;
                    txtLastName.Enabled = false;
                    txtPassword.Enabled = false;
                    break;
            }
        }

        /// <summary>
        /// User id
        /// </summary>
        public int UserId
        {
            get { return Convert.ToInt32(txtUserId.Text); }
        }

        /// <summary>
        /// First Name
        /// </summary>
        public String FirstName
        {
            get { return txtFirstName.Text; }
        }

        /// <summary>
        /// Last Name
        /// </summary>
        public String LastName
        {
            get { return txtLastName.Text; }
        }

        /// <summary>
        /// Password
        /// </summary>
        public String Password
        {
            get { return txtPassword.Text; }
        }

        /// <summary>
        /// SystemRole
        /// </summary>
        public String SystemRole
        {
            get { return cboSystemRole.Text; }
        }

        /// <summary>
        /// Closes the form
        /// </summary>
        private void cmdChangeUserDetails_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Ensures that only numbers can be entered into the password textbox
        /// </summary>
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtPassword.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtPassword.Text = txtPassword.Text.Remove(txtPassword.Text.Length - 1);
            }
        }
    }
}