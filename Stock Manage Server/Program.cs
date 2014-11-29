using System;
using Stock_Manage_Server.Networking;

namespace Stock_Manage_Server
{
    internal class Program
    {
        public static CustomSocket ServerSocket = new CustomSocket();

        public static ushort MachineId = 0;

        public static ushort UserId = 0;

        private static void Main(string[] args)
        {
            // Open the server and listen to connections
            ServerSocket.Bind(8221);
            ServerSocket.Listen(500);
            ServerSocket.Accept();

            Console.ReadLine();
        }
    }
}