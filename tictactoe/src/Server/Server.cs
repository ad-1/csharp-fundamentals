using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Server
{

    public class Client
    {

        public int id;
        public Socket socket;

        public Client(int id, Socket socket)
        {
            this.id = id;
            this.socket = socket;
        }

    }

    public class Server
    {

        private readonly Socket _serverSocket;
        private readonly List<Client> clients;
        private readonly byte[] buffer = new byte[1024];
        private Game game;

        public Server(string ip, int port)
        {
            clients = new List<Client>();
            Console.WriteLine("setting up server...");
            _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _serverSocket.Bind(new IPEndPoint(IPAddress.Parse(ip), port));
            _serverSocket.Listen(5);
            _serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);            
        }

        public void AcceptCallback(IAsyncResult ar)
        {
            Socket socket = _serverSocket.EndAccept(ar);
            int clientId = clients.Count + 1;
            Client client = new Client(clientId, socket);
            clients.Add(client);
            socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
            Console.WriteLine($"clients connected: {clientId} ");
            if (clientId == 2)
                game = new Game();
            else
                _serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }

        public void ReceiveCallback(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            int receivedDataLength = socket.EndReceive(ar);
            byte[] receivedDataBuffer = new byte[receivedDataLength];
            Array.Copy(buffer, receivedDataBuffer, receivedDataLength);
            string receivedMsg = Encoding.ASCII.GetString(receivedDataBuffer);
            Console.WriteLine($"Rx: {receivedMsg}");
            var sendMsg = game.TakeTurn(0, receivedMsg);
            Console.WriteLine($"Tx: {sendMsg}");
            SendDataToClients(sendMsg, sendMsg.Length);
        }

        public void SendDataToClients(string sendMsg, int sendBufferSize)
        {
            foreach (Client client in clients)
            {
                byte[] sendDataBuffer = new byte[sendBufferSize];
                sendDataBuffer = Encoding.ASCII.GetBytes(sendMsg.ToLower());
                Console.WriteLine($"Tx client {client.id}: {sendMsg}");
                Socket socket = client.socket;
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
