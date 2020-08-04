using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrickWallLineFinder.Models
{
    public class BrickWall
    {
        public List<BricksRow> Rows { get; set; }

        public BrickWall()
        {
            Rows = new List<BricksRow>();
        }
    }
}
