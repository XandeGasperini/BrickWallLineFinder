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
        //Retorna uma nova BrickWall, baseado nos parametros recebidos
        public BrickWall GenerateBrickWall(int rows, int maxBricksInRow)
        {
            BrickWall wall = new BrickWall();

            for (int i = 0; i < rows; i++)
            {
                wall.Rows.Add(GenerateBrickRow(maxBricksInRow));
            }

            return wall;
        }

        //Cria uma nova BrickRow, baseado no número máximo de Bricks que ela pode conter
        private BricksRow GenerateBrickRow(int maxBricks)
        {
            BricksRow row = new BricksRow();

            Random random = new Random();

            int next = random.Next(1, maxBricks + 1); //Pois ele exclue o último maior range

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
