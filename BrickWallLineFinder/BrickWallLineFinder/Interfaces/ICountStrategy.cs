using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrickWallLineFinder.Models;

namespace BrickWallLineFinder.Interfaces
{
    interface ICountStrategy
    {
        public int GetOptimizedLine(BrickWall wall);
    }
}
