using System;
using Stock_Manage_Client.Classes.Networking.Packets;
using Timer = System.Timers.Timer;

namespace Stock_Manage_Client.Classes.Networking
{
    /// <summary>
    /// A notification tick, used for checking for notifications from the server
    /// </summary>
    internal class NotificationTick
    {
        /// <summary>
        /// Initialise the tick for every 10 seconds
        /// </summary>
        internal NotificationTick()
        {
            Tick = new Timer();
            Tick.Elapsed += Request_Notification;
            Tick.Interval = 10000;
            Tick.Start();
        }

        /// <summary>
        /// The tick timer that triggers the events
        /// </summary>
        private Timer Tick { get; set; }

        /// <summary>
        /// Sends a notification check to the server
        /// </summary>
        private void Request_Notification(object sender, System.Timers.ElapsedEventArgs e)
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
            if (BitConverter.ToUInt16(packet, 2) == 2004)
            {
                
            }
        }
    }
}