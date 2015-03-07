using System;
using Stock_Manage_Server.Networking;

namespace Stock_Manage_Server
{
    /// <summary>
    /// Main entry point into the server
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The socket used to communicate with the client machines
        /// </summary>
        public static ServerSocket Serversocket = new ServerSocket();

        /// <summary>
        /// The machine id of the machine, mainly used when creating packets
        /// </summary>
        public static ushort MachineId = 0;

        /// <summary>
        /// The user id of the machine, mainly used when creating packets
        /// </summary>
        public static ushort UserId = 0;

        /// <summary>
        /// Main entry point into the program, starts listening for connections
        /// </summary>
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