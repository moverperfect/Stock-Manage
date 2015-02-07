using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Stock_Manage_Client.Classes.Networking;
using Stock_Manage_Client.Classes.Networking.Packets;
using Stock_Manage_Client.Forms;

namespace Stock_Manage_Client.Classes
{
    internal static class Program
    {
        private static readonly CustomSocket ClientSocket = new CustomSocket();
        public static String MachineId;
        // TODO CODE THIS IN
        public static String UserId = "0";
        public static String Type;
        public static String IpAddress = "127.0.0.1";

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AllocConsole();

            while (true)
            {
                try
                {
                    GetFileData();
                    if (Type == "debug")
                    {
                        Console.WriteLine("Debug mode: please enter the mode you would like!");
                        Console.WriteLine("1. Management");
                        Console.WriteLine("2. Ordering");
                        Console.WriteLine("3. Workshop");
                        Type = Console.ReadLine().ToLower();
                    }
                    switch (Type)
                    {
                        case "management":
                            Console.WriteLine("This computer is set up for management");
                            Application.Run(new Authentication());
                            if (UserId != "0")
                            {
                                Application.Run(new Management());
                            }
                            Environment.Exit(0);
                            break;
                        case "ordering":
                            Console.WriteLine("This computer is set up for ordering");
                            Application.Run(new Authentication());
                            if (UserId != "0")
                            {
                                Application.Run(new Ordering());
                            }
                            Environment.Exit(0);
                            break;
                        case "workshop":
                            Console.WriteLine("This computer is set up for workshop");
                            Application.Run(new Workshop());
                            Environment.Exit(0);
                            break;
                        default:
                            SetFileData();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// Connects the socket to the server
        /// </summary>
        public static void Connect()
        {
            ClientSocket.Connect(IpAddress, 8221);
        }

        /// <summary>
        /// Sends a string value to the server
        /// </summary>
        /// <param name="data">String message to be sent to the server</param>
        public static void SendData(String data)
        {
            Connect();
            var message = new StdData(data, Convert.ToUInt16(MachineId), Convert.ToUInt16(UserId));
            ClientSocket.Send(message.Data);
        }

        /// <summary>
        /// Sends a StdData datatype to the server
        /// </summary>
        /// <param name="message">The StdData datatype to be sent</param>
        public static void SendData(StdData message)
        {
            Connect();
            ClientSocket.Send(message.Data);
        }

        /// <summary>
        /// Gets the file data from the AppData folder
        /// </summary>
        public static void GetFileData()
        {
            try
            {
                var data =
                    File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                                      "/stockmanage/machine.txt");
                MachineId = data[0];
                Type = data[1];
                IpAddress = data[2];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Sets the filedata file that is inside AppData
        /// </summary>
        public static void SetFileData()
        {
            Console.WriteLine("Machine id?");
            MachineId = Console.ReadLine();
            Console.WriteLine("Machine type? Management, Ordering, Workshop");
            Type = Console.ReadLine().ToLower();
            Console.WriteLine("What is the IP address of the server?");
            IpAddress = Console.ReadLine();

            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                                      "/stockmanage/");

            var typewriter =
                new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                                 "/stockmanage/machine.txt");
            try
            {
                typewriter.WriteLine(MachineId);
                typewriter.WriteLine(Type);
                typewriter.WriteLine(IpAddress);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                typewriter.Close();
            }
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool AllocConsole();

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    }
}