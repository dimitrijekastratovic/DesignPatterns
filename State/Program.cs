using State;

Console.Title = "State Pattern";

// Description:
//    The goal of Iterator Pattern is to allow an object to alter its behavior when its internal state changes.
//    The object will apear to change its class.


BankAccount bankAccount = new BankAccount();
bankAccount.Deposit(100);
bankAccount.Withdraw(500);
bankAccount.Withdraw(100);

//deposit enough for gold
bankAccount.Deposit(2000);

//should be in gold
bankAccount.Deposit(100);

//overdrawn
bankAccount.Withdraw(3000);

//go to regular
bankAccount.Deposit(3000);

//still in regular
bankAccount.Deposit(100);
Console.ReadKey();