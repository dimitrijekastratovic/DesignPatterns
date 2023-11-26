using Command;
Console.Title = "Command Pattern";

// Description:
//    The goal of Command Pattern is to encapsulate a request as an object, thereby letting you parameterize
//    clients with different request, queue or log requests, and support undoable operations.

CommandManager commandManager = new();
IEmployeeManagerRepository repository = new EmployeeManagerRepository();

commandManager.Invoke(new AddEmployeeToManagerList(repository, 1, new Employee(111, "Kevin")));
commandManager.Undo();

repository.WriteDataStore();

commandManager.Invoke(new AddEmployeeToManagerList(repository, 1, new Employee(222, "Leo")));
commandManager.Invoke(new AddEmployeeToManagerList(repository, 2, new Employee(333, "Marco")));
commandManager.Invoke(new AddEmployeeToManagerList(repository, 2, new Employee(333, "Marco"))); //duplicate, won't execute

repository.WriteDataStore();

Console.ReadKey();