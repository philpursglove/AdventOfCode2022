// See https://aka.ms/new-console-template for more information



using AdventUtilities;

//List<string> input = System.IO.File.ReadAllLines("InputFile.txt").ToList();

List<string> input = new List<string>()
{
	"R 5",
	"U 8",
	"L 8",
	"D 3",
	"R 17",
	"D 10",
	"L 25",
	"U 20",
};

List<Move> moves = new List<Move>();

foreach (string line in input)
{
	Move move = new Move();
	string[] split = line.Split(' ');
	move.Distance = int.Parse(split.Last());

	switch (split.First())
	{
		case "R":
			move.Direction = Direction.Right;
			break;
		case "L":
			move.Direction = Direction.Left;
			break;
		case "U":
			move.Direction = Direction.Up;
			break;
		case "D":
			move.Direction = Direction.Down;
			break;
	}
	moves.Add(move);
}

//Point start = new Point() { x = 0, y = 0 };
Point head = new Point { x = 0, y = 0 };
Point knot1 = new Point { x = 0, y = 0 };
Point knot2 = new Point { x = 0, y = 0 };
Point knot3 = new Point { x = 0, y = 0 };
Point knot4 = new Point { x = 0, y = 0 };
Point knot5 = new Point { x = 0, y = 0 };
Point knot6 = new Point { x = 0, y = 0 };
Point knot7 = new Point { x = 0, y = 0 };
Point knot8 = new Point { x = 0, y = 0 };
Point knot9 = new Point { x = 0, y = 0 };

List<Point> tailPoints = new List<Point>();

tailPoints.Add(new Point() { x = knot9.x, y = knot9.y });

foreach (Move move in moves)
{
	switch (move.Direction)
	{
		case Direction.Left:
			for (int i = 0; i < move.Distance; i++)
			{
				head.x -= 1;
				MoveTail(head, knot1);
				MoveTail(knot1, knot2);
				MoveTail(knot2, knot3);
				MoveTail(knot3, knot4);
				MoveTail(knot4, knot5);
				MoveTail(knot5, knot6);
				MoveTail(knot6, knot7);
				MoveTail(knot7, knot8);
				MoveTail(knot8, knot9);

			}
			break;
		case Direction.Right:
			for (int i = 0; i < move.Distance; i++)
			{
				head.x += 1;
				MoveTail(head, knot1);
				MoveTail(knot1, knot2);
				MoveTail(knot2, knot3);
				MoveTail(knot3, knot4);
				MoveTail(knot4, knot5);
				MoveTail(knot5, knot6);
				MoveTail(knot6, knot7);
				MoveTail(knot7, knot8);
				MoveTail(knot8, knot9);
			}
			break;
		case Direction.Up:
			for (int i = 0; i < move.Distance; i++)
			{
				head.y += 1;
				MoveTail(head, knot1);
				MoveTail(knot1, knot2);
				MoveTail(knot2, knot3);
				MoveTail(knot3, knot4);
				MoveTail(knot4, knot5);
				MoveTail(knot5, knot6);
				MoveTail(knot6, knot7);
				MoveTail(knot7, knot8);
				MoveTail(knot8, knot9);
			}
			break;
		case Direction.Down:
			for (int i = 0; i < move.Distance; i++)
			{
				head.y -= 1;
				MoveTail(head, knot1);
				MoveTail(knot1, knot2);
				MoveTail(knot2, knot3);
				MoveTail(knot3, knot4);
				MoveTail(knot4, knot5);
				MoveTail(knot5, knot6);
				MoveTail(knot6, knot7);
				MoveTail(knot7, knot8);
				MoveTail(knot8, knot9);
			}
			break;
	}

	if (!tailPoints.Contains(new Point { x = knot9.x, y = knot9.y }))
	{
		tailPoints.Add(new Point() { x = knot9.x, y = knot9.y });
	}

	//Console.ReadLine()
}

Console.WriteLine($"head x: {head.x}");
Console.WriteLine($"head y: {head.y}");
Console.WriteLine($"tail x: {knot9.x}");
Console.WriteLine($"tail y: {knot9.y}");


Console.WriteLine(tailPoints.Count());

Console.ReadLine();

void MoveTail(Point point, Point tail1)
{
	int distance = Utilities.ManhattanDistance(point, tail1, "x", "y");
	if (distance == 2)
	{
		if (point.x == tail1.x)
		{
			if (point.y > tail1.y)
			{
				tail1.y += 1;
			}
			else
			{
				tail1.y -= 1;
			}
		}
		else if (point.y == tail1.y)
		{
			if (point.x > tail1.x)
			{
				tail1.x += 1;
			}
			else
			{
				tail1.x -= 1;
			}
		}
	}
	else if (distance == 3)
	{
		if (point.x > tail1.x && point.y > tail1.y)
		{
			tail1.x += 1;
			tail1.y += 1;
		}
		else if (point.x < tail1.x && point.y < tail1.y)
		{
			tail1.x -= 1;
			tail1.y -= 1;
		}
		else if (point.x > tail1.x && point.y < tail1.y)
		{
			tail1.x += 1;
			tail1.y -= 1;
		}
		else if (point.x < tail1.x && point.y > tail1.y)
		{
			tail1.x -= 1;
			tail1.y += 1;
		}

	}


}



public class Move
{
	public Direction Direction { get; set; }
	public int Distance { get; set; }
}

public enum Direction
{
	Up, Down, Left, Right
}

public class Point : IEquatable<Point>
{
	public int x { get; set; }
	public int y { get; set; }

	public bool Equals(Point? other)
	{
		if (ReferenceEquals(null, other)) return false;
		if (ReferenceEquals(this, other)) return true;
		return x == other.x && y == other.y;
	}

	public override bool Equals(object? obj)
	{
		if (ReferenceEquals(null, obj)) return false;
		if (ReferenceEquals(this, obj)) return true;
		if (obj.GetType() != this.GetType()) return false;
		return Equals((Point)obj);
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(x, y);
	}
}