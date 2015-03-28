using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Stock_Manage_Client.Classes.Networking;
using Stock_Manage_Client.Classes.Networking.Packets;
using Stock_Manage_Client.Forms;
using System.Net;

namespace Stock_Manage_Client.Classes
{
    /// <summary>
    /// Main entry point to the program
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Custom socket used to communicate with the server
        /// </summary>
        private static readonly CustomSocket ClientSocket = new CustomSocket();

        /// <summary>
        /// The machine id of the machine
        /// </summary>
        public static ushort MachineId;

        /// <summary>
        /// The user id of the user that is logged in
        /// </summary>
        public static ushort UserId = 0;

        /// <summary>
        /// The type of machine, Management, Workshop or ordering
        /// </summary>
        public static String Type;

        /// <summary>
        /// The ip address of the server to communicate with
        /// </summary>
        public static IPAddress IpAddress = IPAddress.Parse("127.0.0.1");

        /// <summary>
        /// Event handler that triggers when the user id changes
        /// </summary>
        public static event EventHandler UserIdChanged;

        /// <summary>
        /// A list of the machine types available
        /// </summary>
        public static List<String> MachineTypes = new List<string>();

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            // Enable the visualstyles and open a new console window
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AllocConsole();

            while (true)
            {
                try
                {
                    // Get the data from the configuration file
                    GetFileData();

                    // If we are in debug mode then ask for the type of machine to lauch into
                    if (Type == "debug")
                    {
                        Console.WriteLine("Debug mode: please enter the mode you would like!");
                        Console.WriteLine("1. Management");
                        Console.WriteLine("2. Ordering");
                        Console.WriteLine("3. Workshop");
                        Type = Console.ReadLine().ToLower();
                    }

                    // Open the relevant window based on the type of machine that this is
                    switch (Type)
                    {
                        case "management":
                            Console.WriteLine("This computer is set up for management");
                            // Authenticate the user and if the user id after authentication 
                            // is not 0 then open the management window otherwise exit the program
                            Application.Run(new Authentication("m"));
                            if (UserId != 0)
                            {
                                Application.Run(new Management());
                            }
                            Environment.Exit(0);
                            break;
                        case "ordering":
                            Console.WriteLine("This computer is set up for ordering");
                            // Authenticate the user and if the user id after authentication 
                            // is not 0 then open the ordering window otherwise exit the program
                            Application.Run(new Authentication("o"));
                            if (UserId != 0)
                            {
                                Application.Run(new Ordering());
                            }
                            Environment.Exit(0);
                            break;
                        case "workshop":
                            Console.WriteLine("This computer is set up for workshop");
                            // Authenticate the user and if the user id after authentication 
                            // is not 0 then open the workshop window otherwise exit the program
                            Application.Run(new Workshop());
                            Environment.Exit(0);
                            break;
                        default:
                            // If we have no type then get and write the file data
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

                // Try to parse the machine id
                if (!ushort.TryParse(data[0], out MachineId))
                {
                    MessageBox.Show("Machine Id Configuration unable to be read, please enter configuration data again");
                    SetFileData();
                }

                // Parse the type of machine that this is
                Type = data[1];
                
                // Parse the ipaddress of the machine
                if (!IPAddress.TryParse(data[2], out IpAddress))
                {
                    MessageBox.Show("Unable to parse the ipaddress configuration data, please enter configuration data again");
                    SetFileData();
                }
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
            // Ask for the machine id and parse it
            Console.WriteLine("Machine id?");
            while (!ushort.TryParse(Console.ReadLine(), out MachineId))
            {
                MessageBox.Show("Invalid Machine id, please enter a number");
            }

            // TODO Do validation on this input
            Console.WriteLine("Machine type? Management, Ordering, Workshop");
            Type = Console.ReadLine().ToLower();

            // Parse the ip address
            Console.WriteLine("What is the IP address of the server?");
            while (!IPAddress.TryParse(Console.ReadLine(), out IpAddress))
            {
                MessageBox.Show("Invalid IPaddress, please try again");
            }

            // Create the directory if it does not exist and write the data to the file
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

        /// <summary>
        /// Happens when the user id gets changed, calls the eventhandler
        /// </summary>
        public static void OnUserIdChanged(object sender, EventArgs e)
        {
            var handler = UserIdChanged;
            if (handler != null) handler(null, EventArgs.Empty);
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool AllocConsole();

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    }
}