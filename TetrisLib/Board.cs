using System;
using System.Collections.Generic;
using System.Linq;

namespace TetrisLib
{
	public class Board
	{
		public int[,] grid = new int[20, 10];

		public static event Action<int> PieceHitWall;

		#region Operators
		public static Board operator +(Board board, ITetroid tetroid)
		{
			if (tetroid.Shape.GetLength(0) + tetroid.YPos >= board.grid.GetLength(0) ||
				tetroid.Shape.GetLength(1) + tetroid.XPos > board.grid.GetLength(1))
			{
				PieceHitWall?.Invoke(1);
				//throw new TetrominoOutOfBoundsException();
			}
			for (int i = 0; i < tetroid.Shape.GetLength(0); i++)
			{
				for (int j = 0; j < tetroid.Shape.GetLength(1); j++)
				{
					if ((board.grid[i + tetroid.YPos, j + tetroid.XPos] + tetroid.Shape[i, j]) > 1)
					{
						tetroid.MoveBack();
						PieceHitWall?.Invoke(1);
						//throw new TetrominoIntersectionException();
					}
				}
			}
			for (int i = 0; i < tetroid.Shape.GetLength(0); i++)
			{
				for (int j = 0; j < tetroid.Shape.GetLength(1); j++)
				{
					board.grid[i + tetroid.YPos, j + tetroid.XPos] += tetroid.Shape[i, j];
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
					if ((board.grid[i + tetroid.YPos, j + tetroid.XPos] != 0))
					{
						board.grid[i + tetroid.YPos, j + tetroid.XPos] -= tetroid.Shape[i, j];
					}
				}
			}
			//for (int i = 0; i < tetroid.Shape.GetLength(0); i++)
			//{
			//    for (int j = 0; j < tetroid.Shape.GetLength(1); j++)
			//    {
			//        board.grid[i + tetroid.YPos, j + tetroid.XPos] -= tetroid.Shape[i, j];
			//    }
			//}
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

		public int FindFilledLine()
		{
			for (int i = 0; i < grid.GetLength(0); i++)
			{
				for (int j = 0; j < grid.GetLength(1); j++)
				{
					if (grid[i, j] != 1)
					{
						break;
					}
					if (j == grid.GetLength(1) - 1)
					{
						return i;
					}
				}
			}
			return -1;
		}

		public void RemoveLine(int line)
		{
			for (int i = 0; i < grid.GetLength(1); i++)
			{
				grid[line, i] = 0;
			}
			MoveLinesAboveDown(line);
		}

		public void MoveLinesAboveDown(int line)
		{
			if(line < 0)
			{
				return;
			}
			if(line == 0)
			{
				for (int j = 0; j < grid.GetLength(1); j++)
				{
					grid[line, j] = 0;
				}
				return;
			}

			for (int j = 0; j < grid.GetLength(1); j++)
			{
				grid[line, j] = grid[line - 1, j];
			}
			MoveLinesAboveDown(--line);
			
		}

		public void RemoveAllLines()
		{
			while(FindFilledLine() >= 0)
			{
				RemoveLine(FindFilledLine());
			}
		}

	}
}
