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

foreach ((string, string) pair in pairs)
{
	PacketData packet = PacketData.Parse(pair.Item1);
	packet = PacketData.Parse(pair.Item2);
}

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

	public PacketData()
	{
		Data = new List<object>();
	}
	public List<Object> Data { get; set; }

	public PacketData Parent { get; set; }
}