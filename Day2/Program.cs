// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

List<string> input = File.ReadAllLines("InputFile.txt").ToList();

//input = new List<string>
//{
//    "A Y",
//    "B X",
//    "C Z"
//};

List<Game> games = new List<Game>();

foreach (string line in input)
{
    Game game = new Game();
    char elf = line.First();
    char phil = line.Last();

    switch (elf)
    {
        case 'A':
            game.Elf = Choice.Rock;
            break;
        case 'B':
            game.Elf = Choice.Paper;
            break;
        case 'C':
            game.Elf = Choice.Scissors;
            break;
    }

    switch (phil)
    {
        case 'X':
            game.Phil = Choice.Rock;
            break;
        case 'Y':
            game.Phil = Choice.Paper;
            break;
        case 'Z':
            game.Phil = Choice.Scissors;
            break;
    }
    games.Add(game);
}

Console.WriteLine(games.Sum(g => g.PhilScore()));

List<RiggedGame> riggedGames = new List<RiggedGame>();
foreach (string line in input)
{
    char elf = line.First();
    char rigged = line.Last();
    Choice Elf = (Choice)0;
    Choice Phil = (Choice)0;
    switch (elf)
    {
        case 'A':
            Elf = Choice.Rock;
            break;
        case 'B':
            Elf = Choice.Paper;
            break;
        case 'C':
            Elf = Choice.Scissors;
            break;
    }

    switch (rigged)
    {
        case 'X':
            switch (Elf)
            {
                case Choice.Rock:
                    Phil = Choice.Scissors;
                    break;
                case Choice.Paper:
                    Phil = Choice.Rock; 
                    break;
                case Choice.Scissors:
                    Phil = Choice.Paper;
                    break;
            }
            break;
        case 'Y':
            Phil = Elf;
            break;
        case 'Z':
            switch (Elf)
            {
                case Choice.Rock:
                    Phil = Choice.Paper;
                    break;
                case Choice.Paper:
                    Phil = Choice.Scissors;
                    break;
                case Choice.Scissors:
                    Phil = Choice.Rock;
                    break;
            }
            break;
    }

    RiggedGame riggedGame = new RiggedGame(Elf, Phil);
    riggedGames.Add(riggedGame);
}

Console.WriteLine(riggedGames.Count);
Console.WriteLine(riggedGames.Sum(g => g.PhilScore()));

Console.ReadLine();

public class Game
{
    public Choice Elf { get; set; }
    public Choice Phil { get; set; }

    public int PhilScore()
    {
        int score = (int)Phil;

        if (Elf == Phil)
        {
            score += 3;
            return score;
        }
        else
        {
            switch (Elf)
            {
                case Choice.Rock:
                    if (Phil == Choice.Paper)
                    {
                        score += 6;
                    }
                    break;
                case Choice.Paper:
                    if (Phil == Choice.Scissors)
                    {
                        score += 6;
                    }
                    break;
                case Choice.Scissors:
                    if (Phil == Choice.Rock)
                    {
                        score += 6;
                    }
                    break;
            }
        }

        return score;
    }
}

public enum Choice
{
    Rock = 1,
    Paper = 2,
    Scissors = 3
}

public class RiggedGame : Game
{
    public RiggedGame (Choice elf, Choice phil)
    {
        Elf = elf;
        Phil = phil;
    }
}