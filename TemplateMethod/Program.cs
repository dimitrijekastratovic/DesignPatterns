using TemplateMethod;
Console.Title = "Template Method Pattern";

//Description:
//    The goal of Template Method Pattern is to define skeleton of an algorithm in an operation, deferring some steps to subclasses.
//    It lets subclasses redefine certain steps of an algorithm without chaning the algorithm's structure.


GmailMailParser gmailParser = new();
Console.WriteLine(gmailParser.ParseMailBody("1111"));
Console.WriteLine();

OutlookMailParser outlookParser = new();
Console.WriteLine(outlookParser.ParseMailBody("2222"));
Console.WriteLine();

Console.ReadKey();