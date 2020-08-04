using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using BrickWallLineFinder.Models;

namespace BrickWallLineFinder.Helpers
{
    public class BrickWallGenerator
    {
        public BrickWall GenerateBrickWall(int rows, int maxBricksInRow)
        {
            BrickWall wall = new BrickWall();

            for (int i = 0; i < rows; i++)
            {
                wall.Rows.Add(GenerateBrickRow(maxBricksInRow));
            }

            return wall;
        }

        public BricksRow GenerateBrickRow(int maxBricks)
        {
            BricksRow row = new BricksRow();

            Random random = new Random();

            int next = random.Next(1, maxBricks + 1); //Pq ele exclue o ultimo maior range

            if(maxBricks - next == 0)
            {
                row.Bricks.Add(next);
                return row;
            }

            while (row.Bricks.Sum() < maxBricks)
            {
                next = random.Next(1, maxBricks - next + 1);

                if (row.Bricks.Sum() + next <= maxBricks)
                {
                    row.Bricks.Add(next);
                }
            }

            return row;
        }
    }
}
