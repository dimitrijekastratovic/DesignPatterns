using Singleton;

Console.Title = "Singleton Pattern";

//Description:
//    The goal of Singleton Pattern is to ensure that a class only has one instance,
//    and to provide global access to it.

var instance1 = Logger.Instance;
var instance2 = Logger.Instance;

if (instance1 == instance2 && instance2 == Logger.Instance)
    Console.WriteLine("Instances are the same.");

instance1.Log($"Message from {nameof(instance1)}");
instance1.Log($"Message from {nameof(instance2)}");
Logger.Instance.Log($"Message from {nameof(Logger.Instance)}");

Console.ReadLine();