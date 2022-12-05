// See https://aka.ms/new-console-template for more information



using AdventUtilities;

List<string> input = File.ReadAllLines("InputFile.txt").ToList();

Stack<Crate> stack1 = new Stack<Crate>();
Stack<Crate> stack2 = new Stack<Crate>();
Stack<Crate> stack3 = new Stack<Crate>();
Stack<Crate> stack4 = new Stack<Crate>();
Stack<Crate> stack5 = new Stack<Crate>();
Stack<Crate> stack6 = new Stack<Crate>();
Stack<Crate> stack7 = new Stack<Crate>();
Stack<Crate> stack8 = new Stack<Crate>();
Stack<Crate> stack9 = new Stack<Crate>();

string[] cratesSetup = input.Take(8).ToArray();

for (int i = 7;i > -1; i--)
{
    string crateLine = cratesSetup[i];
    Crate newCrate;
    newCrate = CreateCrate(crateLine, 1);
    if (newCrate != null)
    {
        stack1.Push(newCrate);
    }
    newCrate = CreateCrate(crateLine, 5);
    if (newCrate != null)
    {
        stack2.Push(newCrate);
    }
    newCrate = CreateCrate(crateLine, 9);
    if (newCrate != null)
    {
        stack3.Push(newCrate);
    }
    newCrate = CreateCrate(crateLine, 13);
    if (newCrate != null)
    {
        stack4.Push(newCrate);
    }
    newCrate = CreateCrate(crateLine, 17);
    if (newCrate != null)
    {
        stack5.Push(newCrate);
    }
    newCrate = CreateCrate(crateLine, 21);
    if (newCrate != null)
    {
        stack6.Push(newCrate);
    }
    newCrate = CreateCrate(crateLine, 25);
    if (newCrate != null)
    {
        stack7.Push(newCrate);
    }
    newCrate = CreateCrate(crateLine, 29);
    if (newCrate != null)
    {
        stack8.Push(newCrate);
    }
    newCrate = CreateCrate(crateLine, 33);
    if (newCrate != null)
    {
        stack9.Push(newCrate);
    }

}

List<string> moves = input.Skip(10).Take(512).ToList();

foreach (string move in moves)
{
    string[] splitMove = move.Split(" ");
    int number = int.Parse(splitMove[1]);
    int source = int.Parse(splitMove[3]);
    int destination = int.Parse(splitMove[5]);

    Stack<Crate> sourceStack = null;
    Stack<Crate> destinationStack = null;
    switch (source)
    {
        case 1:
            sourceStack = stack1;
            break;
        case 2:
            sourceStack = stack2;
            break;
        case 3:
            sourceStack = stack3;
            break;
        case 4:
            sourceStack = stack4;
            break;
        case 5:
            sourceStack = stack5;
            break;
        case 6:
            sourceStack = stack6;
            break;
        case 7:
            sourceStack = stack7;
            break;
        case 8:
            sourceStack = stack8;
            break;
        case 9:
            sourceStack = stack9;
            break;
    }
    switch (destination)
    {
        case 1:
            destinationStack = stack1;
            break;
        case 2:
            destinationStack = stack2;
            break;
        case 3:
            destinationStack = stack3;
            break;
        case 4:
            destinationStack = stack4;
            break;
        case 5:
            destinationStack = stack5;
            break;
        case 6:
            destinationStack = stack6;
            break;
        case 7:
            destinationStack = stack7;
            break;
        case 8:
            destinationStack = stack8;
            break;
        case 9:
            destinationStack = stack9;
            break;
    }

    Stack<Crate> transfer = new Stack<Crate>();
    for (int i = 0; i < number; i++)
    {
        transfer.Push(sourceStack.Pop());
    }

    for (int i = 0; i < number; i++)
    {
        destinationStack.Push(transfer.Pop());
    }
}

Console.WriteLine($"{stack1.Peek().Name}{stack2.Peek().Name}{stack3.Peek().Name}{stack4.Peek().Name}{stack5.Peek().Name}{stack6.Peek().Name}{stack7.Peek().Name}{stack8.Peek().Name}{stack9.Peek().Name}");

Console.ReadLine();

Crate CreateCrate(string crateLine, int index)
{
    string crateName = crateLine.Substring(index, 1);
    if (crateName != " ")
    {
        return new Crate() { Name = crateName };
    }
    else
    {
        return null;
    }
}

public class Crate
{
    public string Name { get; set; }
}