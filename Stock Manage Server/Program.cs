using System;
using Stock_Manage_Server.Networking;

namespace Stock_Manage_Server
{
    internal class Program
    {
        public static ServerSocket Serversocket = new ServerSocket();

        public static ushort MachineId = 0;

        public static ushort UserId = 0;

        private static void Main(string[] args)
        {
            // Open the server and listen to connections
            Serversocket.Bind(8221);
            Serversocket.Listen(500);
            Serversocket.Accept();

            Console.ReadLine();
        }
    }
}