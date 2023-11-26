using Mediator;
Console.Title = "Mediator Pattern";

// Description:
//    The goal of Mediator Pattern is to define an object - the mediator - that encapsulates how a set of objects interact.
//    It does that by forcing objects to communicate via that mediator.

TeamChatRoom teamChatRoom = new();

var lawyer1 = new Lawyer("Lawyer1");
var lawyer2 = new Lawyer("Lawyer2");
var accountmanager1 = new AccountManager("AccountManager1");
var accountmanager2 = new AccountManager("AccountManager2");
var accountmanager3 = new AccountManager("AccountManager3");

teamChatRoom.Register(lawyer1);
teamChatRoom.Register(lawyer2);
teamChatRoom.Register(accountmanager1);
teamChatRoom.Register(accountmanager2);
teamChatRoom.Register(accountmanager3);

lawyer1.Send("Hello Everyone");
lawyer2.Send("Sup");

accountmanager1.Send("Lawyer1", "Hey Lawyer2");
accountmanager1.Send("Lawyer1", "Hey Again Lawyer2");
lawyer2.SendTo<AccountManager>("Hey All Account managers");

Console.ReadKey();