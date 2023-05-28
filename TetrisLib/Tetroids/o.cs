using System;
using System.Security.Cryptography.X509Certificates;

namespace TetrisLib
{
    public class o : AbstractTetroid
    {
        public o() 
        {
            shape = new int[2, 2]
            {
                { 1,1},
                {1,1 }
            };
        }
    }
}
