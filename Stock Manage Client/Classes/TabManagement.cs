using System.Windows.Forms;

namespace Stock_Manage_Client.Classes
{
    internal static class TabManagement
    {
        /// <summary>
        /// Adds a new tab to the tab control
        /// </summary>
        /// <param name="tabPage">The tab page to be added to the tab control</param>
        /// <param name="tabControl">The tab control that the tab page will be added to</param>
        public static void AddTab(TabPage tabPage, TabControl tabControl)
        {
            if (tabControl.InvokeRequired)
            {
                tabControl.Invoke(new MethodInvoker(delegate
                {
                    tabControl.TabPages.Add(tabPage);
                    tabControl.SelectTab(tabPage);
                    tabPage.Focus();
                }));
            }
            else
            {
                tabControl.TabPages.Add(tabPage);
                tabControl.SelectTab(tabPage);
                tabPage.Focus();
            }
        }

        /// <summary>
        /// Removes the current tab from the input tab control, index can be used to remove a specific indexed tab
        /// </summary>
        /// <param name="tabControl">The tab to remove the tab from</param>
        /// <param name="index">Use "-1" for the currently selected tab</param>
        public static void RemoveTab(TabControl tabControl, int index)
        {
        	if(tabControl.TabCount != 0)
        	{
        		if (index < 0) 
        		{
        			index = tabControl.SelectedIndex;
        		}
        		tabControl.TabPages.RemoveAt(index);
            	if(index != 0)
            	{
            		tabControl.SelectedIndex = index - 1;
            	}
        	}
        }
    }
}