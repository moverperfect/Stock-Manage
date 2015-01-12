﻿using System;
using System.Net.Sockets;
using Stock_Manage_Client.Classes.Networking.Packets;
using System.Windows.Forms;

namespace Stock_Manage_Client.Classes.Networking
{
    internal static class PacketHandler
    {
        public static void Handle(byte[] packet, Socket clientSocket)
        {
            var packetLength = BitConverter.ToUInt16(packet, 0);
            var packetType = BitConverter.ToUInt16(packet, 2);

            Console.WriteLine("Recieved packet of length: {0} and Type: {1}", packetLength, packetType);

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
                    Program.TempReturnTable = new Table(packet);
                    //Program.RefreshData();
                    break;

                case 2000:
                    var msg = new StdData(packet);
                    if (msg.Text.Contains("ERROR:")) {
                        MessageBox.Show(msg.Text);
                    }
                    Console.WriteLine(msg.Text);
                    break;
            }

            clientSocket.Close();
        }
    }
}