using Composite;

Console.Title = "Composite Pattern";

//Description:
//    The goal of Composite Pattern is to compose objects into tree structures to represent part-whole hierarchies.
//    It lets clients treat individual objects and compositions of objects uniformly: as if they all were individual objects.

var root = new Composite.Directory("root", 0);
var topLevelFile = new Composite.File("toplevel.txt", 100);
var topLevelDir1 = new Composite.Directory("topLevelDir1", 4);
var topLevelDir2 = new Composite.Directory("topLevelDir2", 4);

root.Add(topLevelFile);
root.Add(topLevelDir1);
root.Add(topLevelDir2);

var lowLevelFile1 = new Composite.File("lowlevel1.txt", 200);
var lowLevelFile2 = new Composite.File("lowlevel2.txt", 150);

topLevelDir2.Add(lowLevelFile1);
topLevelDir2.Add(lowLevelFile2);

Console.WriteLine($"Top level dir 1 size: {topLevelDir1.GetSize()}");
Console.WriteLine($"Top level dir 2 size: {topLevelDir2.GetSize()}");
Console.WriteLine($"Root size: {root.GetSize()}");

Console.ReadKey();