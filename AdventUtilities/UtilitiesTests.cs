using System.Drawing;
using NUnit.Framework;

namespace AdventUtilities;

[TestFixture]
public class ManhattanDistanceTests
{
	[Test]
	public void Two_Points_With_The_Same_Coordinates_Have_Zero_Manhattan_Distance()
	{
		Point point1 = new Point(1, 1);
		Point point2 = new Point(1, 1);
		int result = Utilities.ManhattanDistance(point1, point2, "X", "Y");
		Assert.That(result, Is.Zero);
	}

	[TestCase(0, 1)]
	[TestCase(1, 0)]
	[TestCase(2, 1)]
	[TestCase(1, 2)]
	public void Two_Points_With_One_Orthoganal_Distance_Have_One_Manhattan_Distance(int x, int y)
	{
		Point point1 = new Point(x, y);
		Point point2 = new Point(1, 1);
		int result = Utilities.ManhattanDistance(point1, point2, "X", "Y");
		Assert.That(result, Is.EqualTo(1));
	}

	[TestCase(0, 0)]
	[TestCase(0, 2)]
	[TestCase(2, 0)]
	[TestCase(2, 2)]
	public void Two_Points_With_Two_Diagonal_Distance_Have_Two_Manhattan_Distance(int x, int y)
	{
		Point point1 = new Point(x, y);
		Point point2 = new Point(1, 1);
		int result = Utilities.ManhattanDistance(point1, point2, "X", "Y");
		Assert.That(result, Is.EqualTo(2));
	}
}