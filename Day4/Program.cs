// See https://aka.ms/new-console-template for more information



List<string> input = File.ReadAllLines("InputFile.txt").ToList();

List<Tuple<Elf, Elf>> elves = new List<Tuple<Elf, Elf>>();

foreach (string line in input)
{
    string[] split = line.Split(",");
    Elf elf1 = new Elf();
    elf1.LowerBound = int.Parse(split.First().Split("-").First());
    elf1.UpperBound = int.Parse(split.First().Split("-").Last());
    Elf elf2 = new Elf();
    elf2.LowerBound = int.Parse(split.Last().Split("-").First());
    elf2.UpperBound = int.Parse(split.Last().Split("-").Last());
    elves.Add(new Tuple<Elf, Elf>(elf1, elf2));
}


Console.WriteLine(elves.Count(t => t.Item1.Contains(t.Item2) || t.Item2.Contains(t.Item1)));

Console.WriteLine(elves.Count(t => t.Item1.Overlaps(t.Item2) || t.Item2.Overlaps(t.Item1)));

Console.ReadLine();

public class Elf
{
    public int LowerBound { get; set; }
    public int UpperBound { get; set; }

    public bool Contains(Elf compareElf)
    {
        return (LowerBound <= compareElf.LowerBound) && (UpperBound >= compareElf.UpperBound);
    }

    public bool Overlaps(Elf compareElf)
    {
        return (LowerBound <= compareElf.LowerBound || LowerBound <= compareElf.LowerBound) || (UpperBound >= compareElf.UpperBound || LowerBound >= compareElf.UpperBound);

    }
}