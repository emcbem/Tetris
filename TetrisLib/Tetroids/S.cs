namespace TetrisLib
{
    public class S : AbstractTetroid
    {
        public S()
        {
            shape = new int[2, 3]
            {
                {0,1, 1 },
                {1,1, 0 }
            };
        }
    }
}
