using Iterator;
Console.Title = "Iterator Pattern";

// Description:
//    The goal of Iterator Pattern is to provide access to the
//    elements of and aggregate object (Enumerable, Array, List, ...)
//    sequentially without exposing its underlying representation

PeopleCollection people = new()
{
    new("FirstName1","LastName1"),
    new("FirstName2","LastName2"),
    new("FirstName3","LastName3")
};

var peopleIterator = people.CreateIterator();

for(Person person = peopleIterator.First(); !peopleIterator.IsDone; person = peopleIterator.Next())
{
    Console.WriteLine($"{person?.FirstName}");
}

Console.ReadKey();