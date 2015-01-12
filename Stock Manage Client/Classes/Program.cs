using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Stock_Manage_Client.Forms;
using Stock_Manage_Server.Networking.Packets;
using Stock_Manage_Client.Classes.Networking;

namespace Stock_Manage_Client.Classes
{
    internal static class Program
    {
        private static readonly ClientSocket ClientSocket = new ClientSocket();
        public static String MachineId;
        // TODO CODE THIS IN
        public static String UserId = "0";
        public static String Type;
        public static String IpAddress = "127.0.0.1";
        public static Table TempReturnTable = new Table();

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
                // Getting the file and checking what form to open
                try
                {
                    var data =
                        File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                                          "/stockmanage/machine.txt");
                    MachineId = data[0];
                    Type = data[1];
                    IpAddress = data[2];

                    switch (Type)
                    {
                        case "manage":
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
                            Application.Run(new Ordering());
                            Environment.Exit(0);
                            break;
                        case "workshop":
                            Console.WriteLine("This computer is set up for workshop");
                            Application.Run(new Workshop());
                            Environment.Exit(0);
                            break;
                    }
                }
                catch
                {
                    // Get the type of machine that this is and stuff(maybe the ip of the server)
                    // Also get the machine id from the server to write to the file
                    Console.WriteLine("File not found");
                    Console.WriteLine("Machine id?");
                    MachineId = Console.ReadLine();
                    Console.WriteLine("Machine type? Manage, Ordering, Workshop");
                    Type = Console.ReadLine().ToLower();
                    Console.WriteLine("What is the IP address of the server?");
                    IpAddress = Console.ReadLine();

                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                                              "/stockmanage/");

                    var typewriter =
                        new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                                         "/stockmanage/machine.txt");
                    typewriter.WriteLine(MachineId);
                    typewriter.WriteLine(Type);
                    typewriter.WriteLine(IpAddress);
                    typewriter.Close();
                }
                if (Console.ReadLine() == "reset")
                {
                    File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                                "/stockmanage/machine.txt");
                }
            }
        }

        public static void Connect()
        {
            ClientSocket.Connect(IpAddress, 8221);
        }

        public static void SendData(String data)
        {
            Connect();
            var message = new StdData(data,Convert.ToUInt16(MachineId),Convert.ToUInt16(UserId));
            ClientSocket.Send(message.Data);
        }

        private static void Authenticate()
        {
            var loginForm = new Form {Width = 500, Height = 150, FormBorderStyle = FormBorderStyle.FixedDialog, Text = "Login", StartPosition = FormStartPosition.CenterScreen};
            Label lbl_UserId = new Label() {Left = 50, Top = 20, Text = "Login"};
        }

        //public static void RefreshData()
        //{
        //    if (window.dataGridView1.InvokeRequired)
        //    {
        //        Management. d = new SetTextCallback(RefreshData());
        //        window.Invoke(d);
        //    }
        //    else
        //    {
        //        window.dataGridView1.DataSource = TempReturnTable.TableData;
        //    }
        //}

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool AllocConsole();

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    }
}