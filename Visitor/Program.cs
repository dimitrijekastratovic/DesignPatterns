using Visitor;
Console.Title = "Visitor Pattern";

// Description:
//    The goal of Visitor Pattern is to represent an operation to be performed on the elements of an object structure.
//    Visitor lets you define a new operation without changing the classes of the elements on which it operates.

var container = new Container();

container.Customers.Add(new Customer("Name1", 50));
container.Customers.Add(new Customer("Name2", 1000));
container.Customers.Add(new Customer("Name3", 800));
container.Employees.Add(new Employee("Name4", 18));
container.Employees.Add(new Employee("Name5", 5));

DiscountVisitor discountVisitor = new();

container.Accept(discountVisitor);
Console.WriteLine($"Total discount given: {discountVisitor.TotalDiscountGiven}");

Console.ReadKey();
