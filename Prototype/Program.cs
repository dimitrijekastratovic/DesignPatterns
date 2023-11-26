using Prototype;

//Description:
//    The goal of Prototype Pattern is to specify the kinds of objects to
//    create using a prototypical instance, and create new objects by copying
//    this prototype.

Console.Title = "Prototype Pattern";

var manager = new Manager("Paul");
var managerClone = (Manager)manager.Clone(true);
Console.WriteLine($"Manager clone name: {managerClone.Name}");

var employee = new Employee("Michael", managerClone);
var employeeClone = (Employee)employee.Clone(true);
Console.WriteLine($"Employee clone name: {employeeClone.Name}, and his manager: {employeeClone.Manager.Name}");

//Even though employeeClone was created before we changed the name of manager clone,
//employeeClone's manager name will still be changed, this is a limitation of MemberwiseClone()
managerClone.Name = "Karen";
Console.WriteLine($"Employee clone name: {employeeClone.Name}, and his manager: {employeeClone.Manager.Name}");

Console.ReadKey();


//Shallow copy:
//-Copy of primitive type values
//-Complex type values will be shared across clones

//Deep copy
//-Copy of primitive type values and complex type values will be shared across clones