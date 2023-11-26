using Decorator;

Console.Title = "Decorator Pattern";

//Description:
//    The goal of Decorator Pattern is to attach additional responsibilities to an object dynamically (runtime).
//    A decorator thus provides a flexible alternative to subclassing for extending functionality.

var cloudMailService = new CloudMailService();
cloudMailService.SendMail("Cloud Mail Service");

var onPremMailService = new OnPremMailService();
onPremMailService.SendMail("On Prem Mail Service");

//Additional behavior
var statisticsDecorator = new StatisticsDecorator(cloudMailService);
statisticsDecorator.SendMail($"Hi there via {nameof(StatisticsDecorator)}");

var messageDatabaseDecorator = new MessageDatabaseDecorator(onPremMailService);
messageDatabaseDecorator.SendMail("Message 1");
messageDatabaseDecorator.SendMail("Message 2");

foreach(var message in messageDatabaseDecorator.SentMessages)
{
    Console.WriteLine($"{message}");
}

Console.ReadKey();