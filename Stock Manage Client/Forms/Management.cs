using System;
using System.Windows.Forms;
using Stock_Manage_Client.Classes;
using Stock_Manage_Client.Classes.TabPages;

namespace Stock_Manage_Client.Forms
{
    /// <summary>
    /// Main form for the management UI
    /// </summary>
    public partial class Management : Form
    {
        /// <summary>
        /// Initialises the form
        /// </summary>
        public Management()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Add new user tab to the tab control
        /// </summary>
        private void btn_newUser_Click(object sender, EventArgs e)
        {
            tc_MainControl.TabPages.Add(new AddNewUserTab());
        }

        /// <summary>
        /// Closes the currently selected tab
        /// </summary>
        private void btn_CloseTab_Click(object sender, EventArgs e)
        {
            TabManagement.RemoveTab(tc_MainControl, -1);
        }

        /// <summary>
        /// Adds a ManageUsers tab to the tab control
        /// </summary>
        private void cmdManageUsers_Click(object sender, EventArgs e)
        {
            tc_MainControl.TabPages.Add(new ManageUsersTab());
        }

        /// <summary>
        /// Adds a ManageProducts tab to the tab control
        /// </summary>
        private void cmdManageProducts_Click(object sender, EventArgs e)
        {
            tc_MainControl.TabPages.Add(new ManageProductsTab());
        }

        /// <summary>
        /// Adds a Manage Suppliers tab to the tab control
        /// </summary>
        private void cmdManageSuppliers_Click(object sender, EventArgs e)
        {
            tc_MainControl.TabPages.Add(new ManageSuppliersTab());
        }

        /// <summary>
        /// Adds a Manage Orders tab to the tab control
        /// </summary>
        private void cmdManageOrders_Click(object sender, EventArgs e)
        {
            tc_MainControl.TabPages.Add(new ManageOrdersTab());
        }
    }
}