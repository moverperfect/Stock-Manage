using System;
using System.Net.Sockets;
using Stock_Manage_Client.Classes.Networking;

namespace Stock_Manage_Server.Networking
{
    class ServerSocket : CustomSocket
    {
        public ServerSocket() { }

        public override void HandlePacket(Byte[] packet, Socket clientSocket)
        {
            PacketHandler.Handle(packet,clientSocket);
        }
    }
}
