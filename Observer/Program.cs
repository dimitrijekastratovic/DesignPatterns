using Observer;

Console.Title = "Observer Pattern";

// Description:
//    The goal of Observer Pattern is to define a one to many dependency between
//    objects so that when one object changes state, all its dependents are
//    notified and updated automatically.

OrderService orderService = new();
orderService.AddObserver(new TicketStockService());
orderService.AddObserver(new TicketResellerService());

orderService.CompleteTicketSale(1, 10);

Console.ReadKey();