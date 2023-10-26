using System.IO;

string FilePath = "./m1.txt";
string fileBool = args.Length < 1 ? "m1" : args[0];

FileClass file = new FileClass();
file.Read(FilePath);

int deep = 4;

Game initial = new Game();
Node tree = new Node
{
    State = initial,
    YouPlays = fileBool == "m1"
};

tree.Expand(deep);

if (tree.YouPlays)
{
    tree.Alphabeta();
    tree = tree.PlayBest();
    tree.Expand(deep);
    var last = tree.State.GetLast();

    System.Console.WriteLine(last);
}

Player p1 = new();
Player p2 = new();

p1.CurrentPlays = 68_853_694_464;
p1.Enemy = p2;

System.Console.WriteLine(p1.Play(1,2));

while (true)
{

    // if (!File.Exists($"{file} last.txt"))
    //     continue;
    
    var text = File.ReadAllText($"m1.txt");
    // File.Delete($"{file} last.txt");

    var data = text.Split(" ");
    var whiteCount = int.Parse(data[0]);
    var whiteInfo = int.Parse(data[1]);
    var blackCount = int.Parse(data[2]);
    var blackInfo = int.Parse(data[3]);
    var whitePlays = int.Parse(data[4]);

    break;

    tree = tree.Play(67);
    tree.Expand(deep);

    tree.Alphabeta();
    tree = tree.PlayBest();
    tree.Expand(deep);

    var last = tree.State.GetLast();
    
    File.WriteAllText($"m1.txt", $"{last.board} {last.position}");
}