using Bridge;

Console.Title = "Bridge Pattern";


//Description:
//    The goal of Bridge Pattern is to decouple an abstraction from its
//    implementation so the two can vary independently.

var oneEuroCoupon = new OneEuroCoupon();
var twoEuroCoupon = new TwoEuroCoupon();

var meatMenu = new MeatMenu(oneEuroCoupon);
var vegetarianMenu = new VegetarianMenu(twoEuroCoupon);

Console.WriteLine($"Meat menu price: {meatMenu.CalculatePrice()}. Vegetarian menu price: {vegetarianMenu.CalculatePrice()}.");
Console.ReadKey();