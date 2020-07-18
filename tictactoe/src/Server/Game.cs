using System;

namespace Server
{
    public class Game
    {

        private int turnCount;
        private readonly Board board;
        private readonly Server server;

        public Game(string ip, int port)
        {
            Console.Title = "Server";
            server = new Server(ip, port);
            board = new Board(3);
            turnCount = 0;
            Play();
        }

        public void Play()
        {
            Console.WriteLine("Playing new game...");
            string currentBoard = board.GetBoard();
            for (int i = 0; i < 3; i++)
            {
                server.SendDataToClient(i, currentBoard, currentBoard.Length);
            }
            while (true)
            {
                int player = WhosTurnIsIt();
                Team team = (player == 0) ? Team.Noughts : Team.Crosses;
                Console.WriteLine($"{player} turn");
                TakeTurn(player);
                currentBoard = board.GetBoard();
                server.SendDataToClient(player, currentBoard, currentBoard.Length);
                var winner = board.CheckWinner(team);
                if (winner)
                {
                    GameOver(Status.Won, team);
                    break;
                }
                var draw = board.CheckDraw();
                if (draw)
                {
                    GameOver(Status.Draw, team);
                    break;
                }
            }
        }

        public void GameOver(Status status, Team team)
        {
            switch (status)
            {
                case Status.Won:
                    Console.WriteLine("\n\n==================================");
                    Console.WriteLine($"{team} Won The Game!");
                    Console.WriteLine("==================================\n\n");
                    break;
                case Status.Draw:
                    Console.WriteLine("Game over. Draw!");
                    break;
                case Status.Playing:
                    break;
            }
        }

        public int WhosTurnIsIt()
        {
            return turnCount % 2;
        }

        public void TakeTurn(int player)
        {
            bool moveOK = false;
            int[] rowCol;
            while (!moveOK)
            {
                string input = Console.ReadLine();
                string[] position = input.Split(",");
                try
                {
                    rowCol = ValidateInput(position);
                    int r = rowCol[0];
                    int c = rowCol[1];
                    Team team = (player == 0) ? Team.Noughts : Team.Crosses;
                    moveOK = board.SquareTaken(r, c, team);
                    if (!moveOK)
                    {
                        Console.WriteLine($"Square {r},{c} is alrady taken");
                    }
                    else
                    {
                        string msg = $"{r},{c}";
                        server.SendDataToClient(player, msg, msg.Length);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Choose a square. eg. 2,1");
                }
            }
            turnCount++;
        }

        private int[] ValidateInput(string[] position)
        {
            if (position.Length != 2)
            {
                throw new FormatException();
            }
            bool rowConverted = int.TryParse(position[0], out int row);
            bool colConverted = int.TryParse(position[1], out int col);
            if (!(rowConverted && colConverted))
            {
                throw new FormatException();
            }
            int[] rowCol = new int[2] { row, col };
            return rowCol;
        }

    }
}
