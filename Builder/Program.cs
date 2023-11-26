using Builder;

Console.Title = "Builder Pattern";

//Description:
//    The goal of Builder Pattern is to separate the construction of a complex
//    object from its representation. By doing so, the same construction process
//    can create different representations.

var garage = new Garage();

var golfBuilder = new GolfBuilder();
var bmwBuilder = new BMWBuilder();

garage.Construct(golfBuilder);
garage.Show();

garage.Construct(bmwBuilder);
garage.Show();

Console.ReadKey();