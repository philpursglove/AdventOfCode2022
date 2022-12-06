// See https://aka.ms/new-console-template for more information



using AdventUtilities;

List<string> input = File.ReadAllLines("InputFile.txt").ToList();

string line = input.FirstOrDefault();

int startOfPacket = 0;
for (int i = 0; i < line.Length; i++)
{
    List<char> letters = line.Skip(i).Take(4).ToList();

    var groups = letters.GroupBy(l => l, (letter, count) => new { letter = letter, count = count.Count() });

    if (!groups.Any(g => g.count > 1))
    {
        startOfPacket = i+4;
        break;
    }
}

int startOfMessage = 0;
for (int i = 0; i < line.Length; i++)
{
    List<char> letters = line.Skip(i).Take(14).ToList();

    var groups = letters.GroupBy(l => l, (letter, count) => new { letter = letter, count = count.Count() });

    if (!groups.Any(g => g.count > 1))
    {
        startOfMessage = i + 14;
        break;
    }
}

Console.WriteLine(startOfPacket);
Console.WriteLine(startOfMessage);
Console.ReadLine();