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
    public class AnalysisController
    {
        [HttpGet]
        public dynamic Get(int rows, int bricks, int rowsInc, int bricksInc)
        {
            BrickWallGenerator generator = new BrickWallGenerator();

            BrickWall wall = new BrickWall();

            List<int> millList = new List<int>();
            List<int> hitsList = new List<int>();
            SumAndContStrategy strategy = new SumAndContStrategy();

            int bricksCount = bricksInc;
            int rowsCount = rowsInc;

            long tick1 = 0;
            long tick2 = 0;

            while (bricksCount < bricks || rowsCount < rows)
            {
                //Gera uma BrickWall para ser trabalhada
                wall = generator.GenerateBrickWall(rowsCount, bricksCount);

                tick1 = DateTime.Now.Ticks;
                //Descobre a linha que menos corta tijolos
                hitsList.Add(strategy.GetOptimizedLine(wall));
                tick2 = DateTime.Now.Ticks;

                millList.Add(Convert.ToInt32(tick2 - tick1));

                if (rowsCount < rows)
                {
                    rowsCount += rowsInc;
                }

                if (bricksCount < bricks)
                {
                    bricksCount += bricksInc;
                }
            }

            return new { millis = millList.ToArray() , hits = hitsList.ToArray()};
        }
    }
}
