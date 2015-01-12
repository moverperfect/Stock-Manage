using System;
using Stock_Manage_Server.Networking;
using System.Net.Sockets;

namespace Stock_Manage_Client.Classes.Networking
{
    class ClientSocket : CustomSocket
    {
        public ClientSocket() { }

        public override void HandlePacket(Byte[] packet, Socket clientSocket)
        {
            PacketHandler.Handle(packet,clientSocket);
        }
    }
}
