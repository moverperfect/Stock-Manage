using System;
using System.Net.Sockets;
using System.Windows.Forms;
using Stock_Manage_Client.Classes.Networking.Packets;

namespace Stock_Manage_Client.Classes.Networking
{
    internal static class PacketHandler
    {
        // A custom event handler that triggers when a packet comes through this class
        public delegate void DataRecievedEventHandler(byte[] packet);

        public static event DataRecievedEventHandler DataRecieved;

        public static void Handle(byte[] packet, Socket clientSocket)
        {
            var packetLength = BitConverter.ToUInt16(packet, 0);
            var packetType = BitConverter.ToUInt16(packet, 2);

            Console.WriteLine("Recieved packet of length: {0} and Type: {1}", packetLength, packetType);

            // Invoke the DataRecieved event
            if (DataRecieved != null && !(new StdData(packet).Text.Contains("ERROR:")))
            {
                try
                {
                    DataRecieved(packet);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    DataRecieved = null;
                }
                return;
            }

            // Just trying this out for, now ensures that if a load of error messages come in then the user will not have a overload of events triggered when no error message is sent back
            DataRecieved = null;

            // Packet types:
            // 1001 - Table from select statement
            // 2000 - Standard string 
            // 2001 - NonQuery
            // 2002 - Select
            // 2003 - Count
            switch (packetType)
            {
                case 1001:
                    //Byte[] temp = new Byte[packet.Length-4];
                    // TODO CHANGE THIS WHEN ADD PACKET STRUCTURE ASWELL
                    //Array.Copy(packet,4,temp,0,temp.Length);
                    //Program.TempReturnTable = new Table(packet);
                    //Program.RefreshData();
                    break;

                case 2000:
                    var msg = new StdData(packet);
                    if (msg.Text.Contains("ERROR:"))
                    {
                        MessageBox.Show(msg.Text);
                    }
                    Console.WriteLine(msg.Text);
                    break;
            }

            clientSocket.Close();
        }
    }
}