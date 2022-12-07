// See https://aka.ms/new-console-template for more information



using AdventUtilities;

List<string> input = System.IO.File.ReadAllLines("InputFile.txt").ToList();

Folder root = new Folder(null,"");
Folder currentContext = root;

foreach (string line in input)
{
    if (line.StartsWith("$"))
    {
        if (line == "$ cd /")
        {
            currentContext = root;
        }
        else
        {
            if (line.StartsWith("$ cd"))
            {
                var splitLine = line.Split(' ');
                string destination = splitLine.Last();

                if (destination == "..")
                {
                    currentContext = currentContext.Parent;
                }
                else
                {
                    currentContext = currentContext.Folders.Find(f => f.Name == destination);
                }
            }
        }
    }
    else
    {
        var splitLine = line.Split(" ");
        if (splitLine.First() == "dir")
        {
            currentContext.Folders.Add(new Folder(currentContext, splitLine.Last()));
        }
        else
        {
            currentContext.Files.Add(new File(splitLine.Last(), int.Parse(splitLine.First())));
        }
    }
}

long totalSize = 0;
checkFolder(root,ref totalSize);

Console.WriteLine(totalSize);

long unusedSpace = 70000000 - root.TotalSize();
long targetFreeSpace = 30000000 - unusedSpace;

long smallestBigEnough = 30000000;

checkFolder2(root, ref smallestBigEnough);
Console.WriteLine(smallestBigEnough);

Console.ReadLine();

long checkFolder(Folder folder, ref long totalSize)
{
    long currentFolderTotalSize = folder.TotalSize();
    if (currentFolderTotalSize < 100000)
    {
        totalSize += currentFolderTotalSize;

    }

    foreach (var subFolder in folder.Folders)
    {
        checkFolder(subFolder, ref totalSize);
    }

    return totalSize;
}

long checkFolder2(Folder folder, ref long smallestBigEnough)
{
    long currentFolderTotalSize = folder.TotalSize();
    if (currentFolderTotalSize > targetFreeSpace)
    {
        if (currentFolderTotalSize < smallestBigEnough)
        {
            smallestBigEnough = currentFolderTotalSize;
        }
    }

    foreach (var subFolder in folder.Folders)
    {
        checkFolder2(subFolder, ref smallestBigEnough);
    }

    return totalSize;
}

public class Folder
{
    public Folder(Folder parent, string name)
    {
        Folders = new List<Folder>();
        Files = new List<File>();
        Parent = parent;
        Name = name;
    }

    public string Name { get; set; }

    public List<Folder> Folders { get; set; }
    public List<File> Files { get; set; }

    public int TotalSize()
    {
        return Files.Sum(f => f.Size) + Folders.Sum(f => f.TotalSize());
    }

    public Folder Parent { get; set; }
}

public class File
{
    public File(string name, int size)
    {
        Name = name;
        Size = size;
    }

    public string Name { get; set; }
    public int Size { get; set; }
}