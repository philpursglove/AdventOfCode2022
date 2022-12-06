// See https://aka.ms/new-console-template for more information


using AdventUtilities;

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

Console.WriteLine(elves.Count(t => t.Item1.Overlaps2(t.Item2) || t.Item2.Overlaps2(t.Item1)));


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
        List<int> elf1 = new List<int>();
        List<int> elf2 = new List<int>();

        for (int i = LowerBound; i <= UpperBound; i++)
        {
            elf1.Add(i);
        }

        for (int i = compareElf.LowerBound; i <= compareElf.UpperBound; i++)
        {
            elf2.Add(i);
        }

        return elf1.Intersect(elf2).Any();

    }

    public bool Overlaps2(Elf compareElf)
    {
        if (LowerBound <= compareElf.LowerBound && (UpperBound.Between(compareElf.LowerBound, compareElf.UpperBound) || UpperBound > compareElf.UpperBound)) return true;
        if (UpperBound >=  compareElf.UpperBound && (LowerBound.Between(compareElf.LowerBound, compareElf.UpperBound) || LowerBound < compareElf.LowerBound)) return true;
        return false;
    }

}