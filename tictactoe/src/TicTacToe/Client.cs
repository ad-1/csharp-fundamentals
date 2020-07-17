using System;
using System.Net.Sockets;

namespace TicTacToe
{
    public class Client
    {

        public int id;
        private readonly TcpClient client;
        private readonly NetworkStream stream;


        public Client(int id, string server, int port)
        {
            this.id = id;
            client = new TcpClient(server, port);
            stream = client.GetStream();
        }

        public void SendMessage(string message)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

            stream.Write(data, 0, data.Length);
            Console.WriteLine("Sent: {0}", message);

            data = new byte[256];
            int bytes = stream.Read(data, 0, data.Length);
            string responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            Console.WriteLine("Received: {0}", responseData);
        }

        private void CloseConnection()
        {
            stream.Close();
            client.Close();
        }

    }

}
