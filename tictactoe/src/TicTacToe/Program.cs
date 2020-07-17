using System;

namespace TicTacToe
{

    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Server = 0; Game = 1");
            var mode = Console.ReadLine();
            if (mode == "0")
            {
                Server server = new Server("127.0.0.1", 13000);
                server.Start();
            }
            else
            {
                Game game = new Game(boardSize: 3);
            }
        }

    }
}
