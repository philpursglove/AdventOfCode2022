using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdventUtilities
{
    public static class StringExtensions
    {
        public static string[,] ToGrid<T>(this string[] strings)
        {
            string[,] grid = new string[strings.First().Length, strings.Length];

            for (int i = 0; i < strings.Length; i++)
            {
                for (int j = 0; j < strings[i].Length; j++)
                {
                    grid[i, j] = strings[i].Substring(j, 1);
                }
            }

            return grid;
        }

        public static int[,] ToIntGrid(this string[] strings)
        {
            int[,] grid = new int[strings.First().Length, strings.Length];

            for (int i = 0; i < strings.Length; i++)
            {
                for (int j = 0; j < strings[i].Length; j++)
                {
                    grid[i, j] = int.Parse(strings[i].Substring(j, 1));
                }
            }

            return grid;
        }

    }
}
