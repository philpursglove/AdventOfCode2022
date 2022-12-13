// See https://aka.ms/new-console-template for more information



using AdventUtilities;

List<string> input = System.IO.File.ReadAllLines("InputFile.txt").ToList();

char[,] grid = input.ToArray().ToCharGrid();

ValueTuple<int, int> start = grid.FindValue('S', true);
ValueTuple<int, int> end = grid.FindValue('E', true);

Console.WriteLine($"Start: {start.Item1},{start.Item2}");
Console.WriteLine($"End: {end.Item1},{end.Item2}");

var startTile = new Tile();
startTile.Y = start.Item1;
startTile.X = start.Item2;

var finish = new Tile();
finish.Y = end.Item1;
finish.X = end.Item2;

startTile.SetDistance(finish.X, finish.Y);

var activeTiles = new List<Tile>();
activeTiles.Add(startTile);
var visitedTiles = new List<Tile>();

while (activeTiles.Any())
{
	var checkTile = activeTiles.OrderBy(x => x.CostDistance).First();

	if (checkTile.X == finish.X && checkTile.Y == finish.Y)
	{
		//Console.Log(We are at the destination!);
		//We can actually loop through the parents of each tile to find our exact path which we will show shortly. 
		return;
	}

	visitedTiles.Add(checkTile);
	activeTiles.Remove(checkTile);

	var walkableTiles = GetWalkableTiles(grid, checkTile, finish);

	foreach (var walkableTile in walkableTiles)
	{
		//We have already visited this tile so we don't need to do so again!
		if (visitedTiles.Any(x => x.X == walkableTile.X && x.Y == walkableTile.Y))
			continue;

		//It's already in the active list, but that's OK, maybe this new tile has a better value (e.g. We might zigzag earlier but this is now straighter). 
		if (activeTiles.Any(x => x.X == walkableTile.X && x.Y == walkableTile.Y))
		{
			var existingTile = activeTiles.First(x => x.X == walkableTile.X && x.Y == walkableTile.Y);
			if (existingTile.CostDistance > checkTile.CostDistance)
			{
				activeTiles.Remove(existingTile);
				activeTiles.Add(walkableTile);
			}
		}
		else
		{
			//We've never seen this tile before so add it to the list. 
			activeTiles.Add(walkableTile);
		}
	}
}

foreach (Tile visitedTile in visitedTiles)
{
	Console.WriteLine($"{visitedTile.X},{visitedTile.Y}");
}

Console.WriteLine(visitedTiles.Count);

Console.ReadLine();


List<Tile> GetWalkableTiles(char[,] grid, Tile currentTile, Tile targetTile)
{
	var possibleTiles = new List<Tile>()
	{
		new Tile { X = currentTile.X, Y = currentTile.Y - 1, Parent = currentTile, Cost = currentTile.Cost + 1 },
		new Tile { X = currentTile.X, Y = currentTile.Y + 1, Parent = currentTile, Cost = currentTile.Cost + 1 },
		new Tile { X = currentTile.X - 1, Y = currentTile.Y, Parent = currentTile, Cost = currentTile.Cost + 1 },
		new Tile { X = currentTile.X + 1, Y = currentTile.Y, Parent = currentTile, Cost = currentTile.Cost + 1 },
	};

	possibleTiles.ForEach(tile => tile.SetDistance(targetTile.X, targetTile.Y));

	var maxX = grid.GetUpperBound(0);
	var maxY = grid.GetUpperBound(1);

	foreach (Tile possibleTile in possibleTiles)
	{
		if (possibleTile.X >= 0 && possibleTile.X <= maxX && possibleTile.Y >= 0 && possibleTile.Y <= maxY)
		{
			int currentTileValue = 0;
			int possibleTileValue = 0;
			if (currentTile.X == 0 && currentTile.Y == 0)
			{
				currentTileValue = 'a'.ToAscii();
			}

			if (possibleTile.X == targetTile.X && possibleTile.Y == targetTile.Y)
			{
				possibleTileValue = 'z'.ToAscii();
			}
			else
			{
				possibleTileValue = grid[possibleTile.X, possibleTile.Y].ToAscii();
			}


			if (possibleTileValue > (currentTileValue + 1))
			{
				possibleTile.Blocked = true;
			}
		}
	}

	return possibleTiles
		.Where(tile => tile.X >= 0 && tile.X <= maxX)
		.Where(tile => tile.Y >= 0 && tile.Y <= maxY)
		.Where(tile => tile.Blocked == false)
		//		.Where(tile => grid[tile.Y,tile.X] == ' ' || grid[tile.Y,tile.X] == 'E')
		.ToList();
}

class Tile
{
	public int X { get; set; }
	public int Y { get; set; }
	public int Cost { get; set; }
	public int Distance { get; set; }
	public int CostDistance => Cost + Distance;
	public Tile Parent { get; set; }

	//The distance is essentially the estimated distance, ignoring walls to our target. 
	//So how many tiles left and right, up and down, ignoring walls, to get there. 
	public void SetDistance(int targetX, int targetY)
	{
		this.Distance = Math.Abs(targetX - X) + Math.Abs(targetY - Y);
	}

	public bool Blocked { get; set; }
}

