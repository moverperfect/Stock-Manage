using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Stock_Manage_Client.Classes.Networking
{
    public class CustomSocket
    {
        private byte[] _buffer;
        private byte[] _packet;
        private Socket _socket;

        public CustomSocket()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Connect(string ipAddress, int port)
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _socket.BeginConnect(new IPEndPoint(IPAddress.Parse(ipAddress), port), ConnectCallback, null);
        }

        public void Bind(int port)
        {
            _socket.Bind(new IPEndPoint(IPAddress.Any, port));
        }

        public void Listen(int backlog)
        {
            _socket.Listen(backlog);
            Console.WriteLine("Listening...");
        }

        public void Accept()
        {
            _socket.BeginAccept(AcceptedCallback, null);
        }

        /// <summary>
        /// </summary>
        /// <param name="result"></param>
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

        private void ReceivedCallBack(IAsyncResult result)
        {
            try
            {
                var clientSocket = result.AsyncState as Socket;
                if (_buffer.Length == 2)
                {
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
                        var noRecieved = clientSocket.EndReceive(result, out se);
                        var temp = new byte[_packet.Length + noRecieved];
                        Array.Copy(_packet, temp, _packet.Length);
                        Array.Copy(_buffer, 0, temp, _packet.Length, noRecieved);
                        _packet = temp;
                        if (_packet.Length != BitConverter.ToInt16(_packet, 0) && noRecieved != 0)
                        {
                            clientSocket.BeginReceive(_buffer, 0, 256, SocketFlags.None, ReceivedCallBack, clientSocket);
                            return;
                        }

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

        public virtual void HandlePacket(byte[] packet, Socket clientSocket)
        {
            PacketHandler.Handle(packet, clientSocket);
        }

        private void ConnectCallback(IAsyncResult result)
        {
            if (_socket.Connected)
            {
                _socket.EndConnect(result);
                Console.WriteLine("Connected to the server!");
                _buffer = new byte[2];

                _socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceivedCallBack, _socket);
            }
        }

        // TODO EDIT THIS WITH NEW PACKET STRUCTURE
        public void Send(String data, int packetNumber)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            while (stopwatch.ElapsedMilliseconds < 20000)
            {
                if (_socket.Connected)
                {
                    var packetData = Encoding.UTF8.GetBytes(data);
                    var packetLength = BitConverter.GetBytes((ushort) (packetData.Length + 4));
                    var packetType = BitConverter.GetBytes((ushort) packetNumber);

                    var packet = new byte[packetData.Length + 4];
                    Array.Copy(packetLength, packet, 2);
                    Array.Copy(packetType, 0, packet, 2, 2);
                    Array.Copy(packetData, 0, packet, 4, packetData.Length);
                    _socket.Send(packet);
                    return;
                }
            }
        }

        public void Send(byte[] data)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
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