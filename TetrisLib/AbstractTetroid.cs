﻿using System.Linq;
using System.Numerics;

namespace TetrisLib
{
    public class AbstractTetroid : ITetroid
    {
        private Vector2 _position;
        private
        protected int[,] shape;
        private RevertMovement revertMove;
        public int[,] Shape => shape;

        public int XPos => (int)_position.X;
        public int YPos => (int)_position.Y;

        public void MoveDown()
        {
            _position.Y++;
            revertMove = () => _position.Y--;
        }

        public void MoveLeft()
        {
            if (_position.X != 0)
            {
                _position.X--;
                revertMove = MoveRight;
            }
        }

        public void MoveRight()
        {
            if( _position.X + shape.GetLength(1) < 10) 
            {
                _position.X++;
                revertMove = MoveLeft;
            }

        }

        public void MoveBack()
        {
            revertMove.Invoke();
        }


        public void RotateRight()
        {
            DoTranspose();

            //flip rows.
            for (int i = 0; i < shape.GetLength(0); i++)
            {
                for (int j = 0; j < shape.GetLength(1) / 2; j++)
                {
                    int temp = shape[i, j];
                    shape[i, j] = shape[i, shape.GetLength(1) - j - 1];
                    shape[i, shape.GetLength(1) - j - 1] = temp;
                }
            }
        }

        public void RotateLeft()
        {
            DoTranspose();

            //flip columns.
            int numRowsinColumns = shape.GetLength(0);
            for (int j = 0; j < numRowsinColumns / 2; j++)
            {
                for (int i = 0; i < shape.GetLength(1); i++)
                {
                    int temp = shape[j, i];
                    shape[j, i] = shape[numRowsinColumns - 1 - j, i];
                    shape[numRowsinColumns - 1 - j, i] = temp;
                }
            }
        }

        private void DoTranspose()
        {
            int yLength = shape.GetLength(0);
            int xLength = shape.GetLength(1);
            int[,] rotatedShape = new int[xLength, yLength];

            //transpose
            for (int i = 0; i < xLength; i++)
            {
                for (int j = 0; j < yLength; j++)
                {
                    rotatedShape[i, j] = shape[j, i];
                }
            }
            shape = rotatedShape;
        }

        public override string ToString()
        {
            string log = "";
            for (int i = 0; i < shape.GetLength(0); i++)
            {
                for (int j = 0; j < shape.GetLength(1); j++)
                {
                    log += shape[i, j];
                }
                if (i < shape.GetLength(0) - 1) log += "\r\n";
            }
            return log.PadRight(1);
        }
    }

    internal delegate void RevertMovement();
}