
using System.Runtime.CompilerServices;

namespace TetrisLib
{
    public interface ITetroid
    {
        public int[,] Shape { get; }
        public void MoveRight();
        public void MoveLeft();
        public void MoveDown() ;

        public void RotateRight();
        
        public void RotateLeft();

        public float XPos { get; }
    }
}
