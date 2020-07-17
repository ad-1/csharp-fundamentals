using System;

namespace TicTacToe
{
    public class Board
    {
        readonly int size;
        public Square[][] board;


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
            this.board = b;
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    board[i][j] = new Square();
                }
            }
        }

        public void PrintBoard()
        {
            Console.WriteLine();
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    Console.Write($"{board[i][j].Value} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
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

        public bool CheckWinner(Team player)
        {

            int scoreCount;
            for (int i = 0; i < board.Length; i++)
            {
                scoreCount = 0;
                for (int j = 0; i < board.Length; i++)
                {
                    if (board[i][j].owner == player)
                    {
                        scoreCount++;
                    }
                }
                if (scoreCount == 3)
                    return true;
            }

            // check diag

            scoreCount = 0;

            for (int i = 0; i < board.Length; i++)
            {
                if (board[i][size - 1 - i].owner == player)
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
