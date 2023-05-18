using System;
using System.Runtime.Serialization;

namespace TetrisLib
{
    public class TetrominoOutOfBoundsException : Exception
    {
        public TetrominoOutOfBoundsException()
        {
        }

        public TetrominoOutOfBoundsException(string message) : base(message)
        {
        }

        public TetrominoOutOfBoundsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TetrominoOutOfBoundsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
