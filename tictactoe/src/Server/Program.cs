using System;

namespace Server
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.Title = "Game Server";
            new Server("127.0.0.1", 13000);
            Console.ReadLine();
        }
    }
}
