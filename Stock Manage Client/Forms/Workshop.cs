using System;
using System.Windows.Forms;
using Stock_Manage_Client.Classes;
using Stock_Manage_Client.Classes.Networking;
using Stock_Manage_Client.Classes.Networking.Packets;
using Stock_Manage_Client.Classes.TabPages;

namespace Stock_Manage_Client.Forms
{
    /// <summary>
    /// Main form presented to the workshop users
    /// </summary>
    public partial class Workshop : Form
    {
        /// <summary>
        /// Datasource for the datagridview
        /// </summary>
        public Table DataGridTable;

        /// <summary>
        /// Initialises the form and refreshes the datagridview
        /// </summary>
        public Workshop()
        {
            InitializeComponent();
            Program.UserIdChanged += Program_UserIdChanged;
            RefreshUsers();
        }

        /// <summary>
        /// Refreshes the users inside the datagridview
        /// </summary>
        public void RefreshUsers()
        {
            PacketHandler.DataRecieved += RefreshUsers_DataRecieved;
            Program.SendData(
                "SELECT `PK_UserId` as 'User Id', `First_Name` as 'First Name', `Second_Name` as 'Second Name' FROM `tbl_users` ORDER BY FIELD(`System_Role`,'Workshop','Ordering','Management'), First_Name;");
        }

        /// <summary>
        /// Sets the datagridview to the data recieved back from the server
        /// </summary>
        /// <param name="packet">The table of users back from the server</param>
        private void RefreshUsers_DataRecieved(byte[] packet)
        {
            PacketHandler.DataRecieved -= RefreshUsers_DataRecieved;
            DataGridTable = new Table(packet);
            Invoke(new MethodInvoker(delegate { dgdUsers.DataSource = DataGridTable.TableData; }));
        }

        /// <summary>
        /// When a user is clicked in the read only table, start up authentication form with their user id
        /// </summary>
        private void dgdUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgdUsers.SelectedRows;

            if (row.Count != 0)
            {
                var authenticate = new Authentication((int) row[0].Cells[0].Value);
                authenticate.ShowDialog();
            }
        }

        /// <summary>
        /// Close the currently selected tab page
        /// </summary>
        private void btn_CloseTab_Click(object sender, EventArgs e)
        {
            TabManagement.RemoveTab(tc_MainControl, -1);
        }

        /// <summary>
        /// Open a WorkshopProducts tab inside the tab control
        /// </summary>
        private void cmdManageProducts_Click(object sender, EventArgs e)
        {
            tc_MainControl.TabPages.Add(new WorkshopProductsTab());
        }

        /// <summary>
        /// Logs out the user from the system
        /// </summary>
        private void cmdLogOut_Click(object sender, EventArgs e)
        {
            Program.UserId = 0;
            Program.OnUserIdChanged(this, EventArgs.Empty);
        }

        /// <summary>
        /// When the user id is changed, change Log Out button enabled variable
        /// </summary>
        public void Program_UserIdChanged(object sender, EventArgs e)
        {
            Invoke(new MethodInvoker(delegate
            {
                if (Program.UserId == 0)
                {
                    cmdLogOut.Enabled = false;
                }
                else
                {
                    cmdLogOut.Enabled = true;
                }
            }));
        }
    }
}