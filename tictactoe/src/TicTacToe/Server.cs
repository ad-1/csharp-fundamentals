using System;
using System.Net;
using System.Net.Sockets;

namespace TicTacToe
{
    public class Server
    {

        private readonly TcpListener server;
        private readonly int port;

        public Server(string ip, int _port)
        {
            this.port = _port;
            server = new TcpListener(IPAddress.Parse(ip), port);
        }

        public void Start()
        {
            Console.WriteLine($"Starting server...\nLocal end point: {server.LocalEndpoint}");
            server.Start();
            try
            {
                // Buffer for reading data
                byte[] bytes = new byte[256];

                while (true)
                {
                    Console.Write("Waiting for a connection... ");

                    // Perform a blocking call to accept requests.
                    TcpClient client = server.AcceptTcpClient(); // server.AcceptSocket()
                    Console.WriteLine("Client connected!");

                    // Get a stream object for reading and writing
                    NetworkStream stream = client.GetStream();

                    int i;

                    // Loop to receive all the data sent by the client.
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        string data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine("Received: {0}", data);

                        // Process the data sent by the client.
                        data = data.ToUpper();

                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                        // Send back a response.
                        stream.Write(msg, 0, msg.Length);
                        Console.WriteLine("Sent: {0}", data);
                    }

                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                server.Stop();
            }

            Console.WriteLine("\nHit enter to continue...");
            Console.Read();
        }
    }

}
