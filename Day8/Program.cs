// See https://aka.ms/new-console-template for more information



using AdventUtilities;

int[,] grid = System.IO.File.ReadAllLines("InputFile.txt").ToIntGrid();

//List<string> input = new List<string>
//{
//    "30373",
//    "25512",
//    "65332",
//    "33549",
//    "35390",
//};

//grid = input.ToArray().ToIntGrid();

int visibleCount = 0;

for (int i = 1; i < grid.GetUpperBound(1); i++)
{
    for (int j = 1; j < grid.GetUpperBound(0); j++)
    {
        int height = grid[i, j];

        List<int> west = grid.GetWestValues(i, j);
        List<int> south = grid.GetSouthValues(i, j);
        List<int> east = grid.GetEastValues(i, j);
        List<int> north = grid.GetNorthValues(i, j);

        if (north.TrueForAll(x => x < height) || south.TrueForAll(x => x < height) ||
            east.TrueForAll(x => x < height) || west.TrueForAll(x => x < height))
        {
            visibleCount += 1;
        }
    }
}

Console.WriteLine(visibleCount);


visibleCount += ((grid.GetUpperBound(1)+1) * 2);
visibleCount += (((grid.GetUpperBound(0)+1) * 2) - 4);

Console.WriteLine(visibleCount);

Console.ReadLine();