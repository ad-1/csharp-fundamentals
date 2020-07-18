using System;
using System.Text;
using System.Net;
using System.Threading;
using System.Net.Sockets;

namespace Client
{

    public class Client
    {

        private readonly Socket socket;

        public Client(string ip, int port)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Connect(ip, port);
        }

        private void Connect(string ip, int port)
        {
            int attemps = 1;
            while (!socket.Connected && attemps < 10)
            {
                try
                {
                    socket.Connect(new IPEndPoint(IPAddress.Parse(ip), port));
                }
                catch (SocketException ex)
                {
                    Console.Clear();
                    Console.WriteLine($"Connecting... {attemps} Attempts: {ex.Message}");
                }
                Console.Clear();
                attemps++;
            }
            ListenToDataFromServer();
            SendDataToServer();
        }

        private void SendDataToServer()
        {
            while (true)
            {
                string input = Console.ReadLine();
                byte[] buffer = Encoding.ASCII.GetBytes(input);
                socket.Send(buffer);
            }
        }

        private void ListenToDataFromServer()
        {
            while (true)
            {
                byte[] receivedBuffer = new byte[1024];
                int received = socket.Receive(receivedBuffer);
                byte[] data = new byte[received];
                Array.Copy(receivedBuffer, data, received);
                string receivedMsg = Encoding.ASCII.GetString(data);
                Console.WriteLine(receivedMsg);
            }
        }

    }

}
