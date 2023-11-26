using Facade;

Console.Title = "Facade Pattern";

//Description:
//    The goal of Facade Pattern is to provide a unified interface to a set of interfaces in a subsystem.
//    It defines a higer-level interface that makes the subsystem easier to use.

var facade = new DiscountFacade();
Console.WriteLine($"Discount for customer with id {1}: {facade.CalculateDiscountPercentage(1)}");
Console.WriteLine($"Discount for customer with id {10}: {facade.CalculateDiscountPercentage(10)}");

Console.ReadKey();