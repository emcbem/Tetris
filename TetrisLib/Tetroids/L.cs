using System;

namespace TetrisLib
{
    public class L : AbstractTetroid
    {
        public L() 
        {
            shape = new int[3, 2]
            {
                {1,0 },
                {1,0 },
                {1,1 }
            };
        }
    }
}
