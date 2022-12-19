// See https://aka.ms/new-console-template for more information

List<string> input = new List<string>
{
    "Blueprint 1: Each ore robot costs 4 ore. Each clay robot costs 2 ore. Each obsidian robot costs 3 ore and 14 clay. Each geode robot costs 2 ore and 7 obsidian."
};



int oreBots = 1;
int clayBots = 0;
int ore = 0;
int clay = 0;
bool clayBuilding = false;
bool obsidianBuilding = false;
int obsidianBots = 0;
int obsidian = 0;
bool geodeBuilding = false;
int geode = 0;
int geodeBots = 0;

for (int minute = 1; minute < 25; minute++)
{
    if (ore >= 2)
    {
        if (obsidian >= 7)
        {
            geodeBuilding = true;
            ore -= 2;
            obsidian -= 7;
        }
        else
        {
            if (clay >= 7)
            {
                if (ore >= 3 && clay >= 14 && geodeBots == 0)
                {
                    obsidianBuilding = true;
                    ore -= 3;
                    clay -= 14;
                }
            }
            else
            {
                clayBuilding = true;
                ore -= 2;
            }
        }
    }

    ore += oreBots;
    clay += clayBots;
    obsidian += obsidianBots;
    geode += geodeBots;

    if (clayBuilding)
    {
        clayBots++;
        clayBuilding = false;
    }

    if (obsidianBuilding)
    {
        obsidianBots++;
        obsidianBuilding = false;
    }

    if (geodeBuilding)
    {
        geodeBots++;
        geodeBuilding = false;
    }
}


Console.WriteLine($"OreBots: {oreBots}");
Console.WriteLine($"ClayBots: {clayBots}");
Console.WriteLine($"ObsidianBots: {obsidianBots}");
Console.WriteLine($"GeodeBots: {geodeBots}");

Console.WriteLine($"Ore: {ore}");
Console.WriteLine($"Clay: {clay}");
Console.WriteLine($"Obsidian: {obsidian}");
Console.Write($"Geodes: {geode}");

Console.ReadLine();