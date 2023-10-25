// // string file = args.Length < 1 ? "m1" : args[0];
// // string gamePath = "../front/";
// // file = gamePath + file;
// // // Game initial = new();
// // // Node tree = new Node(){
// // //     Youplays = file == "m1"
// // // };

// // var files = Directory.GetFiles($"{gamePath}/");
// // var archive = files.Where(file => file.Contains(file)).FirstOrDefault();

// // var fileData = File.ReadLines(archive!).FirstOrDefault();
// // System.Console.WriteLine(fileData);

// using System.ComponentModel;

// ulong num = 65536;
// num = 68_853_694_464;
// num = 34_628_173_824;

// System.Console.Write("binario Num:  ");
// System.Console.WriteLine(Convert.ToString((long)num, toBase: 2));

// int totalLength = Convert.ToString((long)num, toBase: 2).Length;
// ulong table = 64;
// int width = 8;
// int column = 2 - 1;
// int row = 2 - 1;
// int objectivePosition = (width * column) + row;
// var resbin = num >>> objectivePosition;
// var objectiveIsOcupped = (resbin & (table - (ulong)objectivePosition + 1)) == 1;

// if (!objectiveIsOcupped)
//     num += (ulong)(1 << objectivePosition);

// System.Console.Write("binario Num:  ");
// System.Console.WriteLine(Convert.ToString((long)num, toBase: 2));
// System.Console.Write("Decimal Num resultado:  ");
// System.Console.WriteLine(num);
// System.Console.Write("binario Res:  ");
// System.Console.WriteLine(Convert.ToString((long)resbin, toBase: 2));
// System.Console.Write("Ocupado:  ");
// System.Console.WriteLine(objectiveIsOcupped);

Player p1 = new();
Player p2 = new();

p1.CurrentPlays = 68_853_694_464;
p1.Enemy = p2;

System.Console.WriteLine(p1.Play(1,2));