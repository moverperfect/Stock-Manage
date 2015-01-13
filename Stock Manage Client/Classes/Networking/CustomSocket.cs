using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Stock_Manage_Client.Classes.Networking
{
    public class CustomSocket
    {
        private byte[] _buffer;
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
                    _buffer = new byte[BitConverter.ToInt16(_buffer, 0)];
                    if (clientSocket != null && _buffer.Length != 0)
                        clientSocket.BeginReceive(_buffer, 2, _buffer.Length - 2, SocketFlags.None, ReceivedCallBack,
                            clientSocket);
                }
                else
                {
                    Array.Copy(BitConverter.GetBytes(_buffer.Length), _buffer, 2);
                    if (clientSocket != null)
                    {
                        SocketError se;
                        var bufferSize = clientSocket.EndReceive(result, out se) + 2;
                        if (se == SocketError.Success)
                        {
                            var packet = new byte[bufferSize];
                            Array.Copy(_buffer, packet, packet.Length);

                            HandlePacket(packet, clientSocket);
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
        }
    }
}