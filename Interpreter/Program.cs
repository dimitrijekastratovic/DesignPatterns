using Interpreter;

Console.Title = "Interpreter Pattern";

// Description:
//    The goal of Iterator Pattern is to, given the language,
//    define a representation for its grammar along with an interpreter
//    that uses the representation to interpret sentences in the language.

var expressions = new List<RomanExpression>
{
    new RomanHundredExpression(),
    new RomanTenExpression(),
    new RomanOneExpression()
};

var context = new RomanContext(523);
foreach(var expression in expressions)
{
    expression.Interpret(context);
}

Console.WriteLine($"Translating Arabic numerals to Roman numeral: 5 = {context.Output}");
Console.ReadKey();