using System;
using System.Text;

namespace Server
{
    public class Board
    {
        readonly int size;
        private Square[][] board;


        public Board(int size)
        {
            this.size = size;
            InitializeBoard();
        }

        public void InitializeBoard()
        {
            Square[][] b = {
                new Square[size],
                new Square[size],
                new Square[size]
            };
            board = b;
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    board[i][j] = new Square();
                }
            }
        }

        public string GetBoard()
        {
            StringBuilder sb = new StringBuilder("");
            Console.WriteLine();
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    sb.Append($"{board[i][j].Value} ");
                }
                sb.Append($"\n");
            }
            sb.Append($"\n");
            return sb.ToString();
        }

        public bool SquareTaken(int row, int col, Team owner)
        {
            var square = board[row][col];
            if (square.owner == Team.Unassigned)
            {
                board[row][col].AssignOwner(owner);
                return true;
            }
            return false;
        }

        public Status GetStatus(Team team)
        {
            if (CheckDraw())
                return Status.Draw;
            if (CheckWinner(team))
                return Status.Won;
            return Status.Playing;
        }

        public bool CheckDraw()
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    if (board[i][j].owner == Team.Unassigned)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool CheckWinner(Team team)
        {
            int scoreCount;
            for (int i = 0; i < board.Length; i++)
            {
                scoreCount = 0;
                for (int j = 0; i < board.Length; i++)
                {
                    if (board[i][j].owner == team)
                    {
                        scoreCount++;
                    }
                }
                if (scoreCount == 3)
                    return true;
            }

            scoreCount = 0;
            for (int i = 0; i < board.Length; i++)
            {
                if (board[i][size - 1 - i].owner == team)
                {
                    scoreCount++;
                }
            }
            if (scoreCount == 3)
                return true;

            return false;
        }

    }
}
