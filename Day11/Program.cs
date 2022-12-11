// See https://aka.ms/new-console-template for more information



using AdventUtilities;

List<string> input = System.IO.File.ReadAllLines("InputFile.txt").ToList();

Monkey monkey0 = new Monkey(0);
Monkey monkey1 = new Monkey(1);
Monkey monkey2 = new Monkey(2);
Monkey monkey3 = new Monkey(3);
Monkey monkey4 = new Monkey(4);
Monkey monkey5 = new Monkey(5);
Monkey monkey6 = new Monkey(6);
Monkey monkey7 = new Monkey(7);

Monkey currentMonkey;

List<string[]> chunks = input.Chunk(7).ToList();
foreach (string[] chunk in chunks)
{
	string monkeyLine = chunk[0].Replace(":",string.Empty);
	currentMonkey = FindMonkey(int.Parse(monkeyLine.Last().ToString()));
	string itemsLine = chunk[1].Substring(18);
	string[] items = itemsLine.Split(",");
	foreach (string item in items)
	{
		currentMonkey.Items.Add(long.Parse(item.Trim()));
	}

	string[] operationLine = chunk[2].Split(" ");
	if (operationLine[6] == "*")
	{
		currentMonkey.Operation.Operator = Operator.Multiply;
	}
	else
	{
		currentMonkey.Operation.Operator = Operator.Add;
	}

	if (operationLine[7] == "old")
	{
		currentMonkey.Operation.Value = 0;
	}
	else
	{
		currentMonkey.Operation.Value = long.Parse(operationLine[7].Trim());
	}

	string[] testLine = chunk[3].Split(" ");
	currentMonkey.TestValue = long.Parse(testLine.Last());

	string[] trueLine = chunk[4].Split(" ");
	currentMonkey.TrueTarget = FindMonkey(int.Parse(trueLine.Last()));
	string[] falseLine = chunk[5].Split(" ");
	currentMonkey.FalseTarget = FindMonkey(int.Parse(falseLine.Last()));

}

for (int i = 0; i < 10000; i++)
{
	Round();

}

List<Monkey> monkeys = new List<Monkey>
{
	monkey0, monkey1, monkey2, monkey3, monkey4, monkey5, monkey6, monkey7
};

List<Monkey> topMonkeys = monkeys.OrderByDescending(m => m.InspectionCount).Take(2).ToList();

Console.WriteLine(topMonkeys.First().InspectionCount * topMonkeys.Last().InspectionCount);

Console.ReadLine();

void Round()
{
	monkey0.InspectItems();
	monkey0.GetBored();
	monkey0.TestItems();

	monkey1.InspectItems();
	monkey1.GetBored();
	monkey1.TestItems();

	monkey2.InspectItems();
	monkey2.GetBored();
	monkey2.TestItems();

	monkey3.InspectItems();
	monkey3.GetBored();
	monkey3.TestItems();

	monkey4.InspectItems();
	monkey4.GetBored();
	monkey4.TestItems();

	monkey5.InspectItems();
	monkey5.GetBored();
	monkey5.TestItems();

	monkey6.InspectItems();
	monkey6.GetBored();
	monkey6.TestItems();

	monkey7.InspectItems();
	monkey7.GetBored();
	monkey7.TestItems();
}

Monkey FindMonkey(int number)
{
	switch (number)
	{
		case 0:
			return monkey0;
		case 1:
			return monkey1;
		case 2:
			return monkey2;
		case 3:
			return monkey3;
		case 4:
			return monkey4;
		case 5:
			return monkey5;
		case 6:
			return monkey6;
		case 7:
			return monkey7;
	}

	return null;
}

public class Monkey
{
	public Monkey(int number)
	{
		Name = number.ToString();
		Items = new List<long>();
		Operation = new Operation();
	}

	public string Name { get; set; }

	public List<long> Items { get; set; }

	public Operation Operation { get; set; }

	public long TestValue { get; set; }

	public Monkey TrueTarget { get; set; }
	public Monkey FalseTarget { get; set; }

	public int InspectionCount { get; set; }

	public void InspectItems()
	{
		List<long> newItems = new List<long>();

		foreach (long item in Items)
		{
			InspectionCount += 1;

			bool square = false;
			if (Operation.Value == 0)
			{
				square = true;
				Operation.Value = item;
			}
			switch (Operation.Operator)
			{
				case Operator.Multiply:
					newItems.Add(item * Operation.Value);
					break;
				case Operator.Add:
					newItems.Add(item + Operation.Value);
					break;
			}
			if (square) Operation.Value = 0;
		}

		Items = newItems;
	}

	public void GetBored()
	{
		//List<long> newItems = new List<long>();

		//foreach (long item in Items)
		//{
		//	newItems.Add((long)Math.Floor(new decimal(item / 3)));
		//}

		//Items = newItems;

	}

	public void TestItems()
	{
		long[] items = Items.ToArray();

		for(int i = 0; i < items.Length; i++)
		{
			long remainder = items[i] % TestValue;

			if (remainder == 0)
			{
				TrueTarget.Items.Add(items[i]);
			}
			else
			{
				FalseTarget.Items.Add(items[i]);
			}

			Items.Remove(items[i]);

		}
	}
}

public class Operation
{
	public Operator Operator { get; set; }

	public long Value { get; set; }
}

public enum Operator
{
	Multiply,
	Add
}