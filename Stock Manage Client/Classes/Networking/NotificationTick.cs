using System;
using System.Windows.Forms;
using Stock_Manage_Client.Classes.Networking.Packets;
using Stock_Manage_Client.Classes.TabPages;
using Stock_Manage_Client.Forms;
using Timer = System.Timers.Timer;

namespace Stock_Manage_Client.Classes.Networking
{
    internal delegate void AddTab(TabPage inTabPage);

    /// <summary>
    /// A notification tick, used for checking for notifications from the server
    /// </summary>
    internal class NotificationTick
    {
        /// <summary>
        /// Initialise the tick for every 10 seconds
        /// </summary>
        internal NotificationTick(AddTab function)
        {
            AddaTab = function;

            //Tick = new Timer();
            //Tick.Elapsed += Request_Notification;
            //Tick.Interval = 30000;
            //Tick.Start();
            Request_Notification(null, null);
        }

        /// <summary>
        /// The tick timer that triggers the events
        /// </summary>
        private Timer Tick { get; set; }

        private AddTab AddaTab { get; set; }

        /// <summary>
        /// Sends a notification check to the server
        /// </summary>
        public void Request_Notification(object sender, System.Timers.ElapsedEventArgs e)
        {
            PacketHandler.DataRecieved += Notification_Reply;
            Program.SendData(new StdData("Notification Check", Program.MachineId, Program.UserId, 2004));
        }

        /// <summary>
        /// Deal with any things that need to be notified
        /// </summary>
        /// <param name="packet">The thing that needs to be notified to the user</param>
        private void Notification_Reply(byte[] packet)
        {
            var packetType = BitConverter.ToUInt16(packet, 2);

            // Packet types
            // 2004 - No notification back from the server
            // 2005 - Low product notification back from the server
            // 2006 - Verify order notification
            switch (packetType)
            {
                case 2004:
                    PacketHandler.DataRecieved -= Notification_Reply;
                    break;

                case 2005:
                    PacketHandler.DataRecieved -= Notification_Reply;
                    AddaTab(new ProductNotificationTab(new Table(packet)));
                    break;

                case 2006:
                    PacketHandler.DataRecieved -= Notification_Reply;
                    //var orderTable = new Table(packet);
                    //var orderForm = new OrderNotification(orderTable);
                    //orderForm.ShowDialog();
                    break;
            }

        }
    }
}