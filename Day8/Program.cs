// See https://aka.ms/new-console-template for more information



using AdventUtilities;

int[,] grid = System.IO.File.ReadAllLines("InputFile.txt").ToIntGrid();

for (int i = 0; i < grid.GetUpperBound(1); i++)
{
    for (int j = 0; j < grid.GetUpperBound(0); j++)
    {
        int height = grid[i, j];
    }
}



Console.ReadLine();