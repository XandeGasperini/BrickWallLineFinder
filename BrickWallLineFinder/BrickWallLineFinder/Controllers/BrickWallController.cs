using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrickWallLineFinder.Models;
using BrickWallLineFinder.Helpers;

namespace BrickWallLineFinder.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrickWallController
    {
        [HttpGet]
        public dynamic Get(int rows, int bricks)
        {
            BrickWall wall = new BrickWall();

            BrickWallGenerator generator = new BrickWallGenerator();

            long tick1 = DateTime.Now.Ticks;
            wall = generator.GenerateBrickWall(rows, bricks);
            long tick2 = DateTime.Now.Ticks;

            return new { wall, tick = tick2 - tick1 };
        }

        [HttpPost]
        public dynamic Post([FromBody] BrickWall wall)
        {
            long tick1 = DateTime.Now.Ticks;

            SumAndContStrategy strategy = new SumAndContStrategy();

            int hits = strategy.GetOptimizedLine(wall);

            long tick2 = DateTime.Now.Ticks;

            return new { hits, tick = tick2 - tick1 };
        }
    }
}
