using System;
using System.Numerics;
using System.Linq;

namespace TetrisLib
{
    public class T : AbstractTetroid
    {
        public T() 
        {
            shape = new int[2, 3]
            {
                {1,1,1},
                {0,1,0}
            };
        }
    }
}
