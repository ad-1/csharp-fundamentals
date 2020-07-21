using System;

namespace Server
{
    public class Game
    {

        private int turnCount;
        private readonly Board board;

        public Game()
        {
            Console.WriteLine("Starting new game...");
            board = new Board(3);
            turnCount = 0;
        }

        public string GetBaord()
        {
            return board.GetBoard();
        }

        public string TakeTurn(int player, string move)
        {
            Team team = (turnCount % 2 == 0) ? Team.Noughts : Team.Crosses;
            if ((player == 0 && team != Team.Noughts) || (player == 1 && team != Team.Crosses))
            {
                return $"It's {team} turn";
            }
            Console.WriteLine($"{team} turn");
            bool moveOK = false;
            int[] rowCol;
            while (!moveOK)
            {
                string[] position = move.Split(",");
                try
                {
                    rowCol = ValidateInput(position);
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                int r = rowCol[0];
                int c = rowCol[1];
                moveOK = board.SquareTaken(r, c, team);
                if (!moveOK)
                    return $"Square {r},{c} is alrady taken";
                else
                    return $"Move {r},{c} successful";
            }
            turnCount++;
            return string.Empty;
        }

        private int[] ValidateInput(string[] position)
        {
            if (position.Length != 2)
                throw new FormatException();
            bool rowConverted = int.TryParse(position[0], out int row);
            bool colConverted = int.TryParse(position[1], out int col);
            if (!(rowConverted && colConverted))
                throw new FormatException();
            int[] rowCol = new int[2] { row, col };
            return rowCol;
        }

        public string GameOver(Team team)
        {
            var winner = board.CheckWinner(team);
            if (winner)
                return $"{team} Won The Game!";
            var draw = board.CheckDraw();
            if (draw)
                return "Game over. Draw!";
            return string.Empty;
        }

    }
}
