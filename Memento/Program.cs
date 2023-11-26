using Memento;
Console.Title = "Memento Pattern";

// Description:
//    The goal of Memento Pattern is to capture and externalize an object's internal state so that the object can be
//    restored to this state later, without violating encapsulation.

CommandManager commandManager = new();
IEmployeeManagerRepository repository = new EmployeeManagerRepository();

commandManager.Invoke(new AddEmployeeToManagerList(repository, 1, new Employee(111, "Kevin")));
commandManager.Undo();

repository.WriteDataStore();
Console.WriteLine();

commandManager.Invoke(new AddEmployeeToManagerList(repository, 1, new Employee(222, "Leo")));
commandManager.Invoke(new AddEmployeeToManagerList(repository, 2, new Employee(333, "Marco")));
commandManager.Invoke(new AddEmployeeToManagerList(repository, 2, new Employee(333, "Marco"))); //duplicate, won't execute

repository.WriteDataStore();
Console.WriteLine();

commandManager.UndoAll ();

repository.WriteDataStore();
Console.WriteLine();

Console.ReadKey();