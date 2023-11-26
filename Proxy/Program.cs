using Proxy;

Console.Title = "Proxy Pattern";

//Description:
//    The goal of Proxy Pattern is to provide a surrogate or placeholder for another object
//    (remote API) to control access to it.

//Variations: 
//  -Remote Proxy: Client can communicate with the proxy, feels like local resource
//  -Virtual Proxy: Allows creating expensive objects on demand
//  -Smart Proxy: Allows adding additional logic around the subject
//  -Protection Proxy: Used to control access to an object
//      *TIP* Chain proxies when multiple variations are requeired for use case

Console.WriteLine("Loading document...");
var document = new Document("document.pdf");
Console.WriteLine("Loaded document.");
document.DisplayDocument();

Console.WriteLine();

//Virtual
Console.WriteLine("Loading document proxy...");
var documentProxy = new DocumentProxy("documentProxy.pdf");
Console.WriteLine("Loaded document proxy.");
documentProxy.DisplayDocument();

Console.WriteLine();

//Protected (chained)
Console.WriteLine("Loading document protected proxy...");
var protectedDocumentProxy = new ProtectedDocumentProxy("documentProtectedProxy.pdf", "Viewer");
Console.WriteLine("Loaded document protected proxy.");
protectedDocumentProxy.DisplayDocument();

Console.WriteLine();

Console.WriteLine("Loading document protected proxy...");
var protectedDocumentProxy2 = new ProtectedDocumentProxy("documentProtectedProxy.pdf", "Viewer2");
Console.WriteLine("Loaded document protected proxy.");
protectedDocumentProxy2.DisplayDocument();

Console.ReadKey();

