using Factory;

Console.Title = "Factory Pattern";

//Description:
//    The goal of Factory Pattern is to define an interface for creating an object,
//    but to let subclasses decide which class to instantiate. Factory method lets
//    a class defer instantiation to subclasses.

var factories = new List<DiscountFactory> {
    new CodeDiscountFactory (Guid.NewGuid()),
    new CountryDiscountFactory ("BE")};

foreach (var factory in factories)
{
    var discountService = factory.CreateDiscountService();
    Console.WriteLine($"Percentage {discountService.DiscountPercentage}, coming from {discountService}");
}

Console.ReadKey();