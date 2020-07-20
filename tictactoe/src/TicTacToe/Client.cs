using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Client
{

    public class Client
    {

        private readonly byte[] buffer = new byte[1024];
        private readonly Socket client;

        public Client(string ip, int port)
        {
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(ip), port);
            client.BeginConnect(remoteEP, new AsyncCallback(ConnectCallback), null);
            Send();
        }

        private void ConnectCallback(IAsyncResult ar)
        {
            client.EndConnect(ar);
            Console.WriteLine("Socket connected to {0}", client.RemoteEndPoint.ToString());
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            int receivedDataLength = client.EndReceive(ar);
            byte[] receivedDataBuffer = new byte[receivedDataLength];
            Array.Copy(buffer, receivedDataBuffer, receivedDataLength);
            string receivedMsg = Encoding.ASCII.GetString(receivedDataBuffer);
            Console.WriteLine($"Received msg: {receivedMsg}");
        }

        private void Send()
        {
            while (true)
            {
                string data = Console.ReadLine();
                byte[] byteData = Encoding.ASCII.GetBytes(data);
                client.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), null);
                client.BeginReceive(buffer, 0, buffer.Length, 0, new AsyncCallback(ReceiveCallback), null);
            }
        }

        private void SendCallback(IAsyncResult ar)
        {
            int bytesSent = client.EndSend(ar);
            Console.WriteLine("Sent {0} bytes to server.", bytesSent);
        }

    }

}
