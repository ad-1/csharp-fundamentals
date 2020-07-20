using System;

namespace Server
{
    public class Game
    {

        private int turnCount;
        
        private readonly Board board;

        public Game()
        {
            board = new Board(3);
            turnCount = 0;
        }

        public void GameOver(Status status, Team team)
        {
            switch (status)
            {
                case Status.Won:
                    Console.WriteLine($"{team} Won The Game!");
                    break;
                case Status.Draw:
                    Console.WriteLine("Game over. Draw!");
                    break;
                case Status.Playing:
                    break;
            }
        }

        public void TakeTurn(int player, string move)
        {
            Team team = (turnCount % 2 == 0) ? Team.Noughts : Team.Crosses;
            if ((player == 0 && team != Team.Noughts) || (player == 1 && team != Team.Crosses))
            {
                return;
            }
            Console.WriteLine($"{team} turn");
            bool moveOK = false;
            int[] rowCol;
            while (!moveOK)
            {
                try
                {
                    string[] position = move.Split(",");
                    rowCol = ValidateInput(position);
                    int r = rowCol[0];
                    int c = rowCol[1];
                    moveOK = board.SquareTaken(r, c, team);
                    string msg;
                    if (!moveOK)
                    {
                        msg = $"Square {r},{c} is alrady taken";
                        //server.SendDataToClient(player, msg, msg.Length);
                        Console.WriteLine();
                    }
                    else
                    {
                        msg = $"Move {r},{c} successful";
                       // server.SendDataToClient(player, msg, msg.Length);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Choose a square. eg. 2,1");
                }
            }
            string currentBoard = board.GetBoard();
            //server.SendDataToClient(player, currentBoard, currentBoard.Length);
            var winner = board.CheckWinner(team);
            if (winner)
            {
                GameOver(Status.Won, team);
                return;
            }
            var draw = board.CheckDraw();
            if (draw)
            {
                GameOver(Status.Draw, team);
                return;
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
