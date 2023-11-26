using AbstractFactory;

Console.Title = "Abstract Factory Pattern";

//Description:
//    The goal of Abstract Factory Pattern is to provide an interface for
//    creating families of related or dependent objects without specifying
//    their concrete classes.

var serbiaShoppingCartPurchaseFactory = new SerbiaShoppingCartPurchaseFactory();
var serbiaShoppingCart = new ShoppingCart(serbiaShoppingCartPurchaseFactory);
serbiaShoppingCart.CalculateCosts();

var franceShoppingCartPurchaseFactory = new FranceShoppingCartPurchaseFactory();
var franceShoppingCart = new ShoppingCart(franceShoppingCartPurchaseFactory);
franceShoppingCart.CalculateCosts();

Console.ReadKey();