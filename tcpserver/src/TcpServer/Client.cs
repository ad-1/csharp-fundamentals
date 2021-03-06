﻿using System;
using System.Net.Sockets;

namespace TcpServer
{
    public class Client
    {

        public void Connect(string server, string message)
        {
            try
                {
                    int port = 13000;
                    TcpClient client = new TcpClient(server, port);
                    byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                    NetworkStream stream = client.GetStream();
                    stream.Write(data, 0, data.Length);
                    Console.WriteLine("Sent: {0}", message);
                    data = new byte[256];
                    string responseData = string.Empty;
                    int bytes = stream.Read(data, 0, data.Length);
                    responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                    Console.WriteLine("Received: {0}", responseData);
                    stream.Close();
                    client.Close();
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine("ArgumentNullException: {0}", e);
                }
                catch (SocketException e)
                {
                    Console.WriteLine("SocketException: {0}", e);
                }

                Console.WriteLine("\n Press Enter to continue...");
                Console.Read();
        }
    }
}
