using System.ComponentModel.DataAnnotations;
using ChainOfResponsibility;
Console.Title = "Chain Of Responsibility Pattern";

// Description:
//    The goal of Chain Of Responsibility Pattern is to avoid coupling the sender of a request to its receiver by
//    giving more than one object a chance to handle the request. It does that by chaining the receiving objects
//    and apsssing request along the chain until an object hnadles it.

var validDocument = new Document("New Document", DateTimeOffset.UtcNow, true, true);
var invalidDocument = new Document("New Document", DateTimeOffset.UtcNow, false, true);

var documentHandlerChain = new DocumentTitleHandler();
documentHandlerChain
    .SetSuccessor(new DocumentLastModifiedHandler())
    .SetSuccessor(new DocumentApprovedByDevelopersHandler())
    .SetSuccessor(new DocumentApprovedByManagementHandler());

try
{
    documentHandlerChain.Handle(validDocument);
    Console.WriteLine("Valid document is valid");
    documentHandlerChain.Handle(invalidDocument);
    Console.WriteLine("Invalid document is valid");
}
catch (ValidationException validationException)
{
    Console.WriteLine(validationException.Message);
}

Console.ReadKey();