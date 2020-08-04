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
        public dynamic Get(int rows, int bricks, int rowsInc, int bricksInc, int average)
        {
            BrickWallGenerator generator = new BrickWallGenerator();

            BrickWall wall = new BrickWall();

            List<float> millList = new List<float>();
            List<float> hitsList = new List<float>();
            SumAndContStrategy strategy = new SumAndContStrategy();

            long tick1 = 0;
            long tick2 = 0;


            int bricksCount = bricksInc;
            int rowsCount = rowsInc;

            while (bricksCount < bricks || rowsCount < rows)
            {
                List<int> millListTemp = new List<int>();
                List<int> hitsListTemp = new List<int>();

                for (int i = 0; i < average; i++)
                {
                    //Gera uma BrickWall para ser trabalhada
                    wall = generator.GenerateBrickWall(rowsCount, bricksCount);

                    tick1 = DateTime.Now.Ticks;
                    //Descobre a linha que menos corta tijolos
                    hitsListTemp.Add(strategy.GetOptimizedLine(wall));
                    tick2 = DateTime.Now.Ticks;

                    millListTemp.Add(Convert.ToInt32(tick2 - tick1));
                }
                if (rowsCount < rows)
                {
                    rowsCount += rowsInc;
                }

                if (bricksCount < bricks)
                {
                    bricksCount += bricksInc;
                }

                hitsList.Add(hitsListTemp.Sum() / average);
                millList.Add(millListTemp.Sum() / average);
            }

            return new { millis = millList.ToArray(), hits = hitsList.ToArray() };
        }
    }
}
