using System;
using System.Numerics;

namespace TetrisLib
{
    public class T : ITetroid
    {
        private Vector2 _position;

        private int[,] shape = new int[3, 3]
        {
            {1,1,1},
            {0,1,0},
            {0,0,0}
        };
        public float XPos { get => _position.X; }

        public int[,] Shape => shape;

        public void MoveDown()
        {
            throw new NotImplementedException();
        }

        public void MoveLeft()
        {
            if(_position.X != 0)
            {
                _position.X--;
            }
        }

        public void MoveRight()
        {
            _position.X++;
        }


        public void RotateRight()
        {
            int numColumnsInRow = shape.GetLength(0);
            //transpose
            for(int i = 0; i < numColumnsInRow; i++)
            {
                for(int j = 0; j<i; j++)
                {
                    int temp = shape[i,j];
                    shape[i,j] = shape[j,i];
                    shape[j,i] = temp;
                }
            }

            //flip rows.
            for(int j = 0; j < shape.GetLength(1); j++)
            {
                for(int i = 0; i < numColumnsInRow/2; i++)
                {
                    int temp = shape[j,i];
                    shape[j, i] = shape[j, numColumnsInRow - 1 - i];
                    shape[j, numColumnsInRow - 1 - i] = temp;
                }
            }
        }

        public override string ToString()
        {
            string log = "";
            for(int i = 0; i < shape.GetLength(0); i++)
            {
                for(int j = 0; j < shape.GetLength(1); j++)
                {
                    log += shape[i, j];
                }
                if(i < shape.GetLength(0)-1)log += "\r\n";
            }
            return log.PadRight(1);
        }
    }
}
