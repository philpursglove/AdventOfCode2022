// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

List<string> input = File.ReadAllLines("InputFile.txt").ToList();

List<Elf> elves = new List<Elf>();
Elf currentElf = new Elf();
foreach (string line in input)
{
    if (string.IsNullOrEmpty(line))
    {
        elves.Add(currentElf);
        currentElf = new Elf();
    }
    else
    {
        currentElf.Calories.Add(int.Parse(line));
    }
}

var topElf = elves.OrderByDescending(e => e.TotalCalories()).First();

Console.WriteLine(topElf.TotalCalories());

var topThree = elves.OrderByDescending(e => e.TotalCalories()).Take((3));

Console.WriteLine(topThree.Sum(e => e.TotalCalories()));

Console.ReadLine();

public class Elf
{
    public Elf()
    {
        Calories = new List<int>();
    }
    public List<int> Calories { get; set; }

    public int TotalCalories()
    {
        return Calories.Sum();
    }

}