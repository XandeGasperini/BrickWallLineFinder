﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrickWallLineFinder.Interfaces;
using BrickWallLineFinder.Models;

namespace BrickWallLineFinder.Helpers
{
    public class SumAndContStrategy : ICountStrategy
    {
        //Retorna a menor quantidade de Bricks que uma linha vertical pode atingir
        public int GetOptimizedLine(BrickWall wall)
        {
            BrickWall clearPaths = new BrickWall();

            wall.Rows.ForEach((el) =>
            {
                clearPaths.Rows.Add(GetClearRowPaths(el));
            });

            return FindOptimizedPath(clearPaths);
        }

        //Descobre quais espaços da linha são "vazios"
        private BricksRow GetClearRowPaths(BricksRow wallRow)
        {
            BricksRow res = new BricksRow();

            int soma = 0;

            for (int i = 0; i < wallRow.Bricks.Count - 1; i++) // -1 pois ignoramos o último brick, pois o final dele é no final da parede 
            {
                soma += wallRow.Bricks[i];
                res.Bricks.Add(soma);
            }

            return res;
        }

        //Descobre a linha vertical que cruza por menos Bricks em uma BrickWall Ordenada
        public int FindOptimizedPath(BrickWall wall)
        {
            int maxNumberOfBricks = wall.Rows.Count;

            int maxSumOfOpen = 0;
            int sumOfOpen = 0;
            for (int i = 1; i < maxNumberOfBricks; i++)
            {
                foreach (var el in wall.Rows)
                {
                    if (el.Bricks.BinarySearch(i) >= 0) //BinarySearch ao invés de Contains pois nosso array é ordenado
                        sumOfOpen++;
                }

                if (sumOfOpen > maxSumOfOpen)
                {
                    maxSumOfOpen = sumOfOpen;
                }

                sumOfOpen = 0;
            }

            return maxNumberOfBricks - maxSumOfOpen;
        }

    }
}
