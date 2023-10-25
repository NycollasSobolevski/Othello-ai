// string file = args.Length < 1 ? "m1" : args[0];
// string gamePath = "../front/";
// file = gamePath + file;
// // Game initial = new();
// // Node tree = new Node(){
// //     Youplays = file == "m1"
// // };

// var files = Directory.GetFiles($"{gamePath}/");
// var archive = files.Where(file => file.Contains(file)).FirstOrDefault();

// var fileData = File.ReadLines(archive!).FirstOrDefault();
// System.Console.WriteLine(fileData);


ulong num  = 65536;
var res = num >>> (16 - 6) & (16 - 6);

if(res == 0)
    num += (1 << 10);
res = num >>> (16 - 6) & ((16 - 6)+1);


System.Console.WriteLine(Convert.ToString((long)num, toBase: 2));
System.Console.WriteLine(num);
// System.Console.WriteLine(Convert.ToString((long)res, toBase: 2));
System.Console.WriteLine(res);