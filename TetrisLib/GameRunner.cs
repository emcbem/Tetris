using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisLib;

public class GameRunner
{
    public ITetroid heldTetroid { get; set; }
    public Board CurrentBoard { get; set; }
}
