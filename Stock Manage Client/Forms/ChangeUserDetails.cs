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
    public partial class ChangeUserDetails : Form
    {
        public ChangeUserDetails()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialises the form with the specified case
        /// </summary>
        /// <param name="caseNo">1 = change name, 2 = change password, 3 = change system role, 4 = change everything</param>
        /// <param name="userId"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="systemRole"></param>
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

                    break;
            }
        }

        public int UserId { get { return Convert.ToInt32(txtUserId.Text); } }

        public String FirstName { get { return txtFirstName.Text; } }

        public String LastName { get { return txtLastName.Text; } }

        public String Password { get { return txtPassword.Text; } }

        private void cmdChangeUserDetails_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
