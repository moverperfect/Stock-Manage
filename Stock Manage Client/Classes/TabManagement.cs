using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Stock_Manage_Client.Classes
{
    internal static class TabManagement
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tabPage"></param>
        /// <param name="tabControl"></param>
        public static void AddTab(TabPage tabPage, TabControl tabControl)
        {
            
        }

        /// <summary>
        /// Removes the current tab from the input tab control, index can be used to remove a specific indexed tab
        /// </summary>
        /// <param name="tabControl">The tab to remove the tab from</param>
        /// <param name="index">Use "-1" for the currently selected tab</param>
        public static void RemoveTab(TabControl tabControl, int index)
        {
            if (index < 0 && tabControl.TabCount != 0)
            {
               tabControl.TabPages.Remove(tabControl.SelectedTab); 
            }
            else if (index < tabControl.TabCount && tabControl.TabCount != 0)
            {
                tabControl.TabPages.RemoveAt(index);
            }
        }
    }
}
