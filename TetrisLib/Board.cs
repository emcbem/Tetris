using System;

namespace TetrisLib
{
    public class Board
    {
        int[,] grid = new int[20,10];

        #region Operators
        public static Board operator +(Board board, ITetroid tetroid)
        {
            if(tetroid.Shape.GetLength(0) + tetroid.YPos > board.grid.GetLength(0) || 
                tetroid.Shape.GetLength(1) + tetroid.XPos > board.grid.GetLength(1))
            {
                throw new TetrominoOutOfBoundsException();
            }
            for (int i = 0; i < tetroid.Shape.GetLength(0); i++)
            {
                for(int j = 0; j < tetroid.Shape.GetLength(1); j++)
                {
                    if ((board.grid[i + tetroid.YPos, j + tetroid.XPos] + tetroid.Shape[i, j]) > 1)
                    {
                        throw new TetrominoIntersectionException();
                    }
                }
            }
            for (int i = 0; i < tetroid.Shape.GetLength(0); i++)
            {
                for (int j = 0; j < tetroid.Shape.GetLength(1); j++)
                {
                    board.grid[i + tetroid.YPos, j + tetroid.XPos] += tetroid.Shape[i,j];
                }
            }
            return board;
        }

        public static Board operator -(Board board, ITetroid tetroid)
        {
            if (tetroid.Shape.GetLength(0) + tetroid.YPos > board.grid.GetLength(0) ||
                tetroid.Shape.GetLength(1) + tetroid.XPos > board.grid.GetLength(1))
            {
                throw new TetrominoOutOfBoundsException();
            }
            for (int i = 0; i < tetroid.Shape.GetLength(0); i++)
            {
                for (int j = 0; j < tetroid.Shape.GetLength(1); j++)
                {
                    if ((board.grid[i + tetroid.YPos, j + tetroid.XPos] - tetroid.Shape[i, j]) < 0)
                    {
                        throw new Exception("This isn't good");
                    }
                }
            }
            for (int i = 0; i < tetroid.Shape.GetLength(0); i++)
            {
                for (int j = 0; j < tetroid.Shape.GetLength(1); j++)
                {
                    board.grid[i + tetroid.YPos, j + tetroid.XPos] -= tetroid.Shape[i, j];
                }
            }
            return board;
        }
        #endregion 


        public override string ToString()
        {
            string log = "";
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    log += grid[i, j];
                }
                if (i < grid.GetLength(0) - 1) log += "\r\n";
            }
            return log.PadRight(1);
        }
    }
}
