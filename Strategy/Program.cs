using Strategy;

Console.Title = "Strategy Pattern";

//Description:
//    The goal of Strategy Pattern is to define a family of algorithms, encapsulate each one, and make them interchangeable.
//    Strategy lets the algorithm vary independently from clients that use it.

var order = new Order("Dimitrije", 1, "License");
order.Export(new CSVExportService());

Console.ReadKey();