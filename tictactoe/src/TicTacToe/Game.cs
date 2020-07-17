using System;

namespace TicTacToe
{
    public class Game
    {
        readonly Player player1;
        //readonly Player player2;
        public Board board;
        private int turnCount;

        public Game(int boardSize)
        {
            player1 = new Player(1, Team.Noughts);
            //player2 = new Player(2, Team.Crosses);
            board = new Board(boardSize);
            turnCount = 0;
            Play();
        }

        public void Play()
        {
            Console.WriteLine("Playing new game...");
            board.PrintBoard();
            while (true)
            {
                Player player = WhosTurnIsIt();
                Console.WriteLine($"{player} turn");
                TakeTurn(player);
                board.PrintBoard();
                var winner = board.CheckWinner(player.team);
                if (winner)
                {
                    GameOver(Status.Won, player.team);
                    break;
                }
                var draw = board.CheckDraw();
                if (draw)
                {
                    GameOver(Status.Draw, player.team);
                    break;
                }
            }
        }

        public void GameOver(Status status, Team winner)
        {
            switch (status)
            {
                case Status.Won:
                    Console.WriteLine("\n\n==================================");
                    Console.WriteLine($"{winner} Won The Game!");
                    Console.WriteLine("==================================\n\n");
                    break;
                case Status.Draw:
                    Console.WriteLine("Game over. Draw!");
                    break;
                case Status.Playing:
                    break;
            }
        }

        public Player WhosTurnIsIt()
        {
            return player1; // (turnCount % 2 == 0) ? player1 : player2;
        }

        public void TakeTurn(Player player)
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
                    moveOK = board.SquareTaken(r, c, player.team);
                    if (!moveOK)
                    {
                        Console.WriteLine($"Square {r},{c} is alrady taken");
                    }
                    else
                    {
                        player.PlayerMoved(r, c);
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
            int row, col;
            bool rowConverted = int.TryParse(position[0], out row);
            bool colConverted = int.TryParse(position[1], out col);
            if (!(rowConverted && colConverted))
            {
                throw new FormatException();
            }
            int[] rowCol = new int[2] { row, col };
            return rowCol;
        }

    }
}
