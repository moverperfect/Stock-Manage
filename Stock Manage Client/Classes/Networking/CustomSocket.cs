using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Stock_Manage_Client.Classes.Networking
{
    /// <summary>
    /// A custom built socket to handle any incoming data or connections
    /// </summary>
    public class CustomSocket
    {
        /// <summary>
        /// Acts as the buffer byte array storing 256 bytes at every CallBack
        /// </summary>
        private byte[] _buffer;

        /// <summary>
        /// Acts the collective packet that contains the whole byte array when all is recieved
        /// </summary>
        private byte[] _packet;

        /// <summary>
        /// The socket which communicates with the server/client
        /// </summary>
        private Socket _socket;

        /// <summary>
        /// Initialises the socket with protocol tcp
        /// </summary>
        public CustomSocket()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        /// <summary>
        /// Connects to the parsed ip address and port number
        /// </summary>
        /// <param name="ipAddress">The ip address to connect to</param>
        /// <param name="port">The port number to access</param>
        public void Connect(string ipAddress, int port)
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _socket.BeginConnect(new IPEndPoint(IPAddress.Parse(ipAddress), port), ConnectCallback, null);
        }

        /// <summary>
        /// Bind the socket to a port number
        /// </summary>
        /// <param name="port">Port number to bind the socket to</param>
        public void Bind(int port)
        {
            _socket.Bind(new IPEndPoint(IPAddress.Any, port));
        }

        /// <summary>
        /// Listens for connections after binding
        /// </summary>
        /// <param name="backlog">The backlog number of connections</param>
        public void Listen(int backlog)
        {
            _socket.Listen(backlog);
            Console.WriteLine("Listening...");
        }

        /// <summary>
        /// Begin Accepting connections
        /// </summary>
        public void Accept()
        {
            _socket.BeginAccept(AcceptedCallback, null);
        }

        /// <summary>
        /// When accepted start recieving
        /// </summary>
        /// <param name="result">The current status of the asynchronus operation</param>
        private void AcceptedCallback(IAsyncResult result)
        {
            //Console.WriteLine("Recieved Call from " + _socket.RemoteEndPoint);
            var clientSocket = _socket.EndAccept(result);
            if (clientSocket != null)
            {
                _packet = null;
                _buffer = new byte[2];

                clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceivedCallBack, clientSocket);
                Accept();
            }
        }

        /// <summary>
        /// Handle the incoming bytes into the packet
        /// </summary>
        /// <param name="result">The current status of the asynchronus operation</param>
        private void ReceivedCallBack(IAsyncResult result)
        {
            try
            {
                var clientSocket = result.AsyncState as Socket;

                // If we are just receiving the length of the packet
                if (_buffer.Length == 2)
                {
                    // Read more after the length
                    _packet = _buffer;
                    _buffer = new byte[256];
                    if (clientSocket != null && _buffer.Length != 0)
                        clientSocket.BeginReceive(_buffer, 0, 256, SocketFlags.None, ReceivedCallBack,
                            clientSocket);
                }
                else
                {
                    //Array.Copy(BitConverter.GetBytes(_buffer.Length), _buffer, 2);
                    if (clientSocket != null)
                    {
                        SocketError se;

                        // Increase the number of bytes we have recieved so far
                        var noReceived = clientSocket.EndReceive(result, out se);

                        // Add the stuff we have just received to the whole packet
                        var temp = new byte[_packet.Length + noReceived];
                        Array.Copy(_packet, temp, _packet.Length);
                        Array.Copy(_buffer, 0, temp, _packet.Length, noReceived);
                        _packet = temp;

                        // If we have not finished receiving the data then call this function again recieving another 256 bytes
                        if (_packet.Length != BitConverter.ToInt16(_packet, 0) && noReceived != 0)
                        {
                            clientSocket.BeginReceive(_buffer, 0, 256, SocketFlags.None, ReceivedCallBack, clientSocket);
                            return;
                        }

                        // If we are a success then handle the packet
                        if (se == SocketError.Success)
                        {
                            HandlePacket(_packet, clientSocket);
                        }
                        clientSocket.Close();
                    }
                    _buffer = new byte[2];
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Calles the packethandler to handle the incoming packet
        /// </summary>
        /// <param name="packet">The packet being handled</param>
        /// <param name="clientSocket">The socket to send back data if needed</param>
        public virtual void HandlePacket(byte[] packet, Socket clientSocket)
        {
            PacketHandler.Handle(packet, clientSocket);
        }

        /// <summary>
        /// Happens when requested connection is accepted
        /// </summary>
        /// <param name="result">The current status of the asynchronus operation</param>
        private void ConnectCallback(IAsyncResult result)
        {
            if (_socket.Connected)
            {
                // If we are connected then end the connection request
                // TODO NOTE A event handler could be used here to send the data after we have connected but this was not
                // realised at the time of design maybe
                _socket.EndConnect(result);
                Console.WriteLine("Connected to the server!");
                _buffer = new byte[2];

                // Start receiving in case the connected server needs to send data back
                _socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceivedCallBack, _socket);
            }
        }

        /// <summary>
        /// If the server is connected within 3 seconds, sends the data, if not MessageBox
        /// </summary>
        /// <param name="data">The byte array to be sent to the server</param>
        internal void Send(byte[] data)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            // While less than 3 seconds have passed try to send the data
            while (stopwatch.ElapsedMilliseconds < 3000)
            {
                if (_socket.Connected)
                {
                    _socket.Send(data);
                    return;
                }
            }
            // If still not connected after 3 seconds then display error message
            if (!_socket.Connected)
            {
                MessageBox.Show("Unable to connect to server");
            }
        }
    }
}