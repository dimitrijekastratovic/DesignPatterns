//using ObjectAdapter;
using ClassAdapter;

Console.Title = "Adapter Pattern";

//Description:
//    The goal of Adapter Pattern is to convert the interface of a class into another
//    interface clients expect. Adapter lets classes work together that couldn't otherwise
//    because of incompatible interfaces.


ICityAdapter adapter = new CityAdapter();
var city = adapter.GetCity();


Console.WriteLine($"{city.FullName}, {city.Inhabitants}");
Console.ReadKey();