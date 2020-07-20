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
        private readonly byte[] buffer = new byte[1024];

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
            Socket socket = _serverSocket.EndAccept(ar);
            clients.Add(socket);
            socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
            _serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
            Console.WriteLine($"clients connected: {clients.Count} ");
        }

        public void ReceiveCallback(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            int receivedDataLength = socket.EndReceive(ar);
            byte[] receivedDataBuffer = new byte[receivedDataLength];
            Array.Copy(buffer, receivedDataBuffer, receivedDataLength);
            string receivedMsg = Encoding.ASCII.GetString(receivedDataBuffer);
            Console.WriteLine($"Received msg: {receivedMsg}");
            SendDataToClients(receivedMsg, receivedDataLength);
        }

        public void SendDataToClients(string sendMsg, int sendBufferSize)
        {
            foreach (Socket socket in clients)
            {
                byte[] sendDataBuffer = new byte[sendBufferSize];
                sendDataBuffer = Encoding.ASCII.GetBytes(sendMsg.ToLower());
                Console.WriteLine($"Sending msg: {sendMsg.ToLower()}");
                socket.BeginSend(sendDataBuffer, 0, sendBufferSize, SocketFlags.None, new AsyncCallback(SendCallback), socket);
                socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
            }
        }

        public void SendCallback(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            socket.EndSend(ar);
        }

    }

}
