using System;
using System.Runtime.Serialization;

namespace TetrisLib
{
    public class TetrominoIntersectionException : Exception
    {
        public TetrominoIntersectionException()
        {
        }

        public TetrominoIntersectionException(string message) : base(message)
        {
        }

        public TetrominoIntersectionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TetrominoIntersectionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
