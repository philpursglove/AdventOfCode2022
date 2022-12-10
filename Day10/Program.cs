// See https://aka.ms/new-console-template for more information



using AdventUtilities;

List<string> input = System.IO.File.ReadAllLines("InputFile.txt").ToList();

//List<string> input = new List<string>
//{
//	"addx 15",
//	"addx -11",
//	"addx 6",
//	"addx -3",
//	"addx 5",
//	"addx -1",
//	"addx -8",
//	"addx 13",
//	"addx 4",
//	"noop",
//	"addx -1",
//	"addx 5",
//	"addx -1",
//	"addx 5",
//	"addx -1",
//	"addx 5",
//	"addx -1",
//	"addx 5",
//	"addx -1",
//	"addx -35",
//	"addx 1",
//	"addx 24",
//	"addx -19",
//	"addx 1",
//	"addx 16",
//	"addx -11",
//	"noop",
//	"noop",
//	"addx 21",
//	"addx -15",
//	"noop",
//	"noop",
//	"addx -3",
//	"addx 9",
//	"addx 1",
//	"addx -3",
//	"addx 8",
//	"addx 1",
//	"addx 5",
//	"noop",
//	"noop",
//	"noop",
//	"noop",
//	"noop",
//	"addx -36",
//	"noop",
//	"addx 1",
//	"addx 7",
//	"noop",
//	"noop",
//	"noop",
//	"addx 2	 ",
//	"addx 6	 ",
//	"noop",
//	"noop",
//	"noop",
//	"noop",
//	"noop",
//	"addx 1",
//	"noop",
//	"noop",
//	"addx 7	 ",
//	"addx 1	 ",
//	"noop",
//	"addx -13",
//	"addx 13",
//	"addx 7",
//	"noop",
//	"addx 1",
//	"addx -33",
//	"noop",
//	"noop",
//	"noop",
//	"addx 2",
//	"noop",
//	"noop",
//	"noop",
//	"addx 8",
//	"noop",
//	"addx -1",
//	"addx 2",
//	"addx 1",
//	"noop",
//	"addx 17",
//	"addx -9",
//	"addx 1",
//	"addx 1",
//	"addx -3",
//	"addx 11",
//	"noop",
//	"noop",
//	"addx 1",
//	"noop",
//	"addx 1",
//	"noop",
//	"noop",
//	"addx -13",
//	"addx -19",
//	"addx 1",
//	"addx 3",
//	"addx 26",
//	"addx -30",
//	"addx 12",
//	"addx -1",
//	"addx 3",
//	"addx 1",
//	"noop",
//	"noop",
//	"noop",
//	"addx -9",
//	"addx 18",
//	"addx 1",
//	"addx 2",
//	"noop",
//	"noop",
//	"addx 9",
//	"noop",
//	"noop",
//	"noop",
//	"addx -1",
//	"addx 2",
//	"addx -37",
//	"addx 1",
//	"addx 3",
//	"noop",
//	"addx 15",
//	"addx -21",
//	"addx 22",
//	"addx -6",
//	"addx 1",
//	"noop",
//	"addx 2",
//	"addx 1",
//	"noop",
//	"addx -10",
//	"noop",
//	"noop",
//	"addx 20",
//	"addx 1",
//	"addx 2",
//	"addx 2",
//	"addx -6 ",
//	"addx -11",
//	"noop",
//	"noop",
//	"noop"
//};

List<Operation> operations = new List<Operation>();

foreach (string inputLine in input)
{
	Operation operation = new Operation();
	if (inputLine.Contains(' '))
	{
		string[] split = inputLine.Split(' ');
		operation.Name = split[0];
		operation.Value = int.Parse(split[1]);
	}
	else
	{
		operation.Name = inputLine;
	}
	operations.Add(operation);
}

List<int> cycleTimes = new List<int>() {20, 60, 100, 140, 180, 220};
List<int> signalStrengths = new List<int>();
int register = 1;
int cycle = 0;
foreach (Operation operation in operations)
{
	switch (operation.Name)
	{
		case "noop":
			cycle++;
			CheckSignalStrength(cycleTimes, cycle, signalStrengths, register);

			break;
		case "addx":
			cycle++;
			CheckSignalStrength(cycleTimes, cycle, signalStrengths, register);

			cycle++;
			CheckSignalStrength(cycleTimes, cycle, signalStrengths, register);
			register += operation.Value;

			break;
	}
}

Console.WriteLine(signalStrengths.Sum());

Console.ReadLine();

void CheckSignalStrength(List<int> ints, int i, List<int> list, int register1)
{
	if (ints.Contains(i))
	{
		list.Add(register1 * i);
	}
}

public class Operation
{
	public string Name { get; set; }
	public int Value { get; set; }
}