﻿using System.Drawing;
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

[TestFixture]
public class IntExtensionsTests
{
	[TestCase(1,3,2,true)]
	[TestCase(-3,-1,-2, true)]
	[TestCase(1,3,4,false)]
	[TestCase(-1,1,0,true)]
	public void Between(int lower, int upper, int between, bool expected)
	{
		Assert.That(between.Between(lower,upper), Is.EqualTo(expected));
	}
}

[TestFixture]
public class CharExtensionsTests
{
	[TestCase('a', 97, TestName = "Lower case")]
	[TestCase('A', 65, TestName = "Upper case")]
	[TestCase(' ', 32, TestName = "Punctuation")]
	[TestCase('0', 48, TestName = "Numeric")]
	public void AsciiCode(char letter, int expected)
	{
		Assert.That(letter.ToAscii(), Is.EqualTo(expected));
	}

	[TestCase('a', true)]
	[TestCase('e', true)]
	[TestCase('i', true)]
	[TestCase('o', true)]
	[TestCase('u', true)]
	[TestCase('A', true)]
	[TestCase('E', true)]
	[TestCase('I', true)]
	[TestCase('O', true)]
	[TestCase('U', true)]
	[TestCase('b', false)]
	[TestCase('B', false)]
	public void IsVowel(char letter, bool expected)   
    {
        Assert.That(letter.IsVowel(), Is.EqualTo(expected));
    }
}

[TestFixture]
public class StringExtensionsTests
{
	
}