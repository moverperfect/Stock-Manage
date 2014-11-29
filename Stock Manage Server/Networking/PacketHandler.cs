﻿using System;
using System.Net.Sockets;
using Stock_Manage_Server.Networking.Packets;

namespace Stock_Manage_Server.Networking
{
    internal static class PacketHandler
    {
        public static void Handle(byte[] packet, Socket clientSocket)
        {
            var packetLength = BitConverter.ToUInt16(packet, 0);
            var packetType = BitConverter.ToUInt16(packet, 2);

            Console.WriteLine("Recieved packet of length: {0} and Type: {1}", packetLength, packetType);

            SqlConnecter connecter;

            // Packet types:
            // 1001 - Table from select statement
            // 2000 - Standard string 
            // 2001 - NonQuery
            // 2002 - Select
            // 2003 - Count
            switch (packetType)
            {
                case 2000:
                    var msg = new StdData(packet);
                    Console.WriteLine(msg.Text);
                    break;

                case 2001:
                    var nonQuery = new StdData(packet);
                    connecter = new SqlConnecter("db_inventorymanagement");
                    connecter.NonQuery(nonQuery.Text);
                    Console.WriteLine(nonQuery.Text);
                    break;

                case 2002:
                    var select = new StdData(packet);
                    connecter = new SqlConnecter("db_inventorymanagement");
                    var dt = new Table(connecter.Select(select.Text),Program.MachineId,Program.UserId);
                    clientSocket.Send(dt.Data);
                    break;
            }
            clientSocket.Close();
        }
    }
}