// See https://aka.ms/new-console-template for more information



using AdventUtilities;

//List<string> input = System.IO.File.ReadAllLines("InputFile.txt").ToList();

List<string> input =  new List<string>()
{
    "[1, 1, 3, 1, 1]",
    "[1, 1, 5, 1, 1]",
    "",
    "[[1],[2, 3, 4]]",
    "[[1],4]",
    "",
    "[9]",
    "[[8,7,6]]",
    "",
    "[[4,4],4,4]",
    "[[4,4],4,4,4]",
    "",
    "[7,7,7,7]",
    "[7,7,7]",
    "",
    "[]",
    "[3]",
    "",
    "[[[]]]",
    "[[]]",
    "",
    "[1,[2,[3,[4,[5,6,7]]]],8,9]",
    "[1,[2,[3,[4,[5,6,0]]]],8,9]"
};

List<string[]> chunks = input.Chunk(3).ToList();

Console.WriteLine(chunks.Count);

List<ValueTuple<string, string>> pairs = new List<(string, string)>();
foreach (string[] chunk in chunks)
{
    ValueTuple<string, string> pair = new ValueTuple<string, string>(chunk[0], chunk[1]);
    pairs.Add(pair);
}

Console.WriteLine(pairs.Count);

List<ValueTuple<PacketData, PacketData>> packetPairs = new List<(PacketData, PacketData)>();
foreach ((string, string) pair in pairs)
{
	PacketData leftPacket = PacketData.Parse(pair.Item1);
	PacketData rightPacket = PacketData.Parse(pair.Item2);

	packetPairs.Add((leftPacket, rightPacket));
}

Console.WriteLine(PacketData.Compare(packetPairs.First().Item1, packetPairs.First().Item2));

Console.ReadLine();

public class PacketData
{
	public static PacketData Parse(string input)
	{
        PacketData result = new PacketData();
        PacketData context;
        context = result;
		foreach (char inputChar in input.Substring(1, input.Length-2))
		{
			if (char.IsNumber(inputChar))
			{
				context.Data.Add(int.Parse(inputChar.ToString()));
			}
			else if (inputChar == '[')
			{
				PacketData parent = context;
				context = new PacketData() {Parent = parent};
			}
            else if (inputChar == ']')
			{
				context.Parent.Data.Add(context);
                context = context.Parent;
			}
		}
        return result;
	}

	public static bool Compare(PacketData left, PacketData right)
	{
		for (int i = 0; i < left.Data.Count; i++)
		{
			object leftItem = left.Data[i];
			object rightItem = right.Data[i];

			if (leftItem is int leftInt && rightItem is int rightInt)
			{
				if (leftInt < rightInt)
				{
					return true;
				}
				else if (rightInt > leftInt)
				{
					return false;
				}
			}
			else if (leftItem is PacketData && rightItem is PacketData)
			{

			}
		}

		return false;
	}

	public PacketData()
	{
		Data = new List<object>();
	}
	public List<Object> Data { get; set; }

	public PacketData Parent { get; set; }

    
}