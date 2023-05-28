using System;
using System.Numerics;

namespace TetrisLib
{
    public class I : AbstractTetroid
    {
        public I() 
        {
            shape = new int[4, 1]
            {
                {1},
                {1},
                {1},
                {1}
            };
        }
    }
}
