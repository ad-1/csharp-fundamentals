using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class Server
    {

        private readonly Socket _serverSocket;
        private readonly List<Socket> clients;
        private byte[] buffer = new byte[1024];

        public Server(string ip, int port)
        {
            clients = new List<Socket>();
            Console.WriteLine("setting up server...");
            _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _serverSocket.Bind(new IPEndPoint(IPAddress.Parse(ip), port));
            _serverSocket.Listen(5);
            _serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }

        public void AcceptCallback(IAsyncResult ar)
        {
            Console.WriteLine($"client {clients.Count} connected");
            Socket socket = _serverSocket.EndAccept(ar);
            clients.Add(socket);
            socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceivedCallback), socket);
            _serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }

        public void ReceivedCallback(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            int receivedDataLength = socket.EndReceive(ar);
            byte[] receivedDataBuffer = new byte[receivedDataLength];
            Array.Copy(buffer, receivedDataBuffer, receivedDataLength);
            string receivedMsg = Encoding.ASCII.GetString(receivedDataBuffer);
            Console.WriteLine($"RX: {receivedMsg}");
            SendDataToClient(0, receivedMsg.ToUpper(), receivedDataLength);
        }

        public void SendDataToClient(int i, string sendMsg, int sendBufferSize)
        {
            if (clients.Count == 0 || i > clients.Count - 1)
            {
                return;
            }
            byte[] sendDataBuffer = new byte[sendBufferSize];
            sendDataBuffer = Encoding.ASCII.GetBytes(sendMsg);
            Socket socket = clients[i];
            socket.BeginSend(sendDataBuffer, 0, sendBufferSize, SocketFlags.None, new AsyncCallback(SendCallback), socket);
        }


        public void SendCallback(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            socket.EndSend(ar);
        }


    }

}
