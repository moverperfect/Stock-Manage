using System;
using System.Windows.Forms;
using Stock_Manage_Client.Classes.TabPages;

namespace Stock_Manage_Client.Forms
{
    public partial class Management : Form
    {
        public Management()
        {
            InitializeComponent();
        }

        private void Management_Load(object sender, EventArgs e)
        {
        }

        private void btn_newUser_Click(object sender, EventArgs e)
        {
            tc_MainControl.TabPages.Add(new AddNewUserTab());
        }

        private void btn_CloseTab_Click(object sender, EventArgs e)
        {
            tc_MainControl.TabPages.Remove(tc_MainControl.SelectedTab);
        }
    }
}