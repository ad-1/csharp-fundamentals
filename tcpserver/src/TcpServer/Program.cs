using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TcpServer
{
    class TcpServer
    {
        public static void Main()
        {

            string input = Console.ReadLine();

            if (input == "0")
            {
                TcpListener server = null;
                try
                {
                    int port = 13000;
                    IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                    server = new TcpListener(localAddr, port);
                    server.Start();
                    byte[] bytes = new byte[256];
                    string data = null;
                    while (true)
                    {
                        Console.Write("Waiting for a connection... ");
                        TcpClient client = server.AcceptTcpClient();
                        Console.WriteLine("Connected!");
                        NetworkStream stream = client.GetStream();
                        int i;
                        while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                        {
                            data = Encoding.ASCII.GetString(bytes, 0, i);
                            Console.WriteLine("Received: {0}", data);
                            data = data.ToUpper();
                            byte[] msg = Encoding.ASCII.GetBytes(data);
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
            else
            {
                Client client = new Client();
                client.Connect("127.0.0.1", "Hello!");
                Console.WriteLine("\nHit enter to continue...");
                Console.Read();
            }


        }
    }
}

