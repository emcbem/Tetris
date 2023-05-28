namespace TetrisLib
{
    public class Z : AbstractTetroid
    {
        public Z() 
        {
            shape = new int[2, 3]
            {
                {1,1, 0 },
                {0,1, 1 }
            };
        }
    }
}
