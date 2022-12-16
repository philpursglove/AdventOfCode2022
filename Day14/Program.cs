// See https://aka.ms/new-console-template for more information

List<string> input =  new List<string>()
{
	"498,4 -> 498,6 -> 496,6",
	"503,4 -> 502,4 -> 502,9 -> 494,9"
};

List<Line> lines = new List<Line>();

foreach (var line in input)
{
	string[] segments = line.Replace(" ", "").Split("->");

	for (int i = 0; i < segments.Length-1; i++)
	{
		Point start = Point.Parse(segments[i]);
		Point end = Point.Parse(segments[i+1]);
		lines.Add(new Line(start, end));
	}
}

Console.WriteLine(lines.Count);

Dictionary<Point, string> cave = new Dictionary<Point, string>();
foreach (var line in lines)
{
	switch (line.Direction)
	{
		case Direction.Vertical:
			int x = line.Start.x;
			for (int i = line.Start.y; i <= line.End.y; i++)
			{
				cave.Add(new Point(x, i),"Rock");
			}
			break;
		case Direction.Horizontal:
			int y = line.Start.y;
			for (int i = line.Start.x; i <= line.End.x; i++)
			{
				cave.Add(new Point(i, y), "Rock");
			}
			break;
	}
}

foreach (KeyValuePair<Point, string> pair in cave)
{
	Console.WriteLine($"{pair.Key.x},{pair.Key.y} - {pair.Value}");
}

Console.ReadLine();

class Point
{
	public static Point Parse(string input)
	{
		string[] coordinates = input.Split(',');
		return new Point(int.Parse(coordinates[0]), int.Parse(coordinates[1]));
	}

	public Point(int X, int Y)
	{
		x = X;
		y = Y;
	}

	public int x { get; set; }
	public int y { get; set; }
}

class Line
{
	public Line(Point start, Point end)
	{
		Start = start;
		End = end;

		if (Start.x == End.x)
		{
			Direction = Direction.Vertical;
		}
		else
		{
			Direction = Direction.Horizontal;
		}

		Point temp;
		switch (Direction)
		{
			case Direction.Horizontal:
				if (Start.x > End.x)
				{
					temp = End;
					End = Start;
					Start = temp;
				}
				break;
			case Direction.Vertical:
				if (Start.y > End.y)
				{
					temp = End;
					End = Start;
					Start = temp;
				}
				break;
		}
	}

	public Point Start;
	public Point End;
	public Direction Direction { get; set; }
}

enum Direction
{
	Horizontal,
	Vertical
}