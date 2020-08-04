using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrickWallLineFinder.Models
{
    public class BricksRow
    {
        public List<int> Bricks { get; set; }

        public BricksRow()
        {
            Bricks = new List<int>();
        }
    }
}
