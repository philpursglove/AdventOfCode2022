// See https://aka.ms/new-console-template for more information

using AdventUtilities;

List<string> input = File.ReadAllLines("InputFile.txt").ToList();

//input = new List<string>
//{
//	//"vJrwpWtwJgWrhcsFMMfFFhFp",
//	"jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
//	//"PmmdzqPrVvPwwTWBwg",
//	//"wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
//	//"ttgJtRGJQctTZtZT",
//	//"CrZsJsPPZsGzwwsLwLmpwMDw"
//};

List<Backpack> backpacks = new List<Backpack>();

foreach (string line in input)
{
	int length = line.Length / 2;
	Backpack backpack = new Backpack();
	backpack.Compartment1 = line.Take(length).ToList();
	backpack.Compartment2 = line.Skip(length).Take(length).ToList();
	backpacks.Add(backpack);
}

var common = backpacks.Select(b => b.Compartment1.Intersect(b.Compartment2).First());

int sum = 0;
foreach (var letter in common)
{
	if (Char.IsLower(letter))
	{
		sum += letter.ToAscii() - 96;
	}
	else
	{
		sum += letter.ToAscii() - 38;
	}
}
Console.WriteLine(sum);

List<List<Backpack>> groups = new List<List<Backpack>>();

do
{
	List<Backpack> group = backpacks.Skip(groups.Count * 3).Take(3).ToList();
	groups.Add(group);
} while (groups.Count < 100);

List<char> badges = new List<char>();

foreach (var group in groups)
{
	List<char> badge1 = new List<char>();
	badge1.AddRange(group[0].Compartment1);
	badge1.AddRange(group[0].Compartment2);

	List<char> badge2 = new List<char>();
	badge2.AddRange(group[1].Compartment1);
	badge2.AddRange(group[1].Compartment2);

	List<char> badge3 = new List<char>();
	badge3.AddRange(group[2].Compartment1);
	badge3.AddRange(group[2].Compartment2);

	badges.Add(badge1.Intersect(badge2.Intersect(badge3)).First());
}

sum = 0;
foreach (var badge in badges)
{
	if (Char.IsLower(badge))
	{
		sum += badge.ToAscii() - 96;
	}
	else
	{
		sum += badge.ToAscii() - 38;
	}
}

Console.WriteLine(sum);
Console.ReadLine();

public class Backpack
{
	public List<char> Compartment1 { get; set; }
	public List<char> Compartment2 { get; set; }

	public Backpack()
	{
		Compartment1 = new List<char>();
		Compartment2 = new List<char>();
	}
}