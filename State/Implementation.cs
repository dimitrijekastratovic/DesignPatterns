using System;
namespace State
{
	/// <summary>
	/// Context
	/// </summary>
	public class BankAccount
	{
        public BankAccountState BankAccountState { get; set; }
        public int Balance { get { return BankAccountState.Balance; } }

        public BankAccount()
        {
            BankAccountState = new RegularState(200, this);
        }

        public void Deposit(int amount)
        {
            BankAccountState.Deposit(amount);
        }

        public void Withdraw(int amount)
        {
            BankAccountState.Withdraw(amount);
        }
    }

	/// <summary>
	/// State
	/// </summary>
	public abstract class BankAccountState
	{
		public BankAccount BankAccount { get; protected set; } = null!;
        public int Balance { get; protected set; }
		public abstract void Deposit(int amount);
        public abstract void Withdraw(int amount);
    }

    /// <summary>
    /// Concrete State
    /// </summary>
    public class RegularState : BankAccountState
    {
        public RegularState(int balance, BankAccount bankAccount)
        {
            Balance = balance;
            BankAccount = bankAccount;
        }

        public override void Deposit(int amount)
        {
            Console.WriteLine($"Depositing {amount:C0} into {GetType()}");
            Balance += amount;

            if (Balance >= 1000)
            {
                BankAccount.BankAccountState = new GoldState(Balance, BankAccount);
            }
        }

        public override void Withdraw(int amount)
        {
            Console.WriteLine($"Withdrawing {amount:C0} from {GetType()}");
            Balance -= amount;

            if(Balance < 0)
            {
                BankAccount.BankAccountState = new OverdrawnState(Balance, BankAccount);
            }
        }
    }

    /// <summary>
    /// Concrete State
    /// </summary>
    public class OverdrawnState : BankAccountState
    {
        public OverdrawnState(int balance, BankAccount bankAccount)
        {
            Balance = balance;
            BankAccount = bankAccount;
        }

        public override void Deposit(int amount)
        {
            Console.WriteLine($"Depositing {amount:C0} into {GetType()}.");
            Balance += amount;

            if(Balance >= 0)
            {
                BankAccount.BankAccountState = new RegularState(Balance, BankAccount);
            }
        }

        public override void Withdraw(int amount)
        {
            Console.WriteLine($"Can't withdraw money from {GetType()}, because current balance is: {Balance:C0}");
        }
    }

    public class GoldState : BankAccountState
    {
        public GoldState(int balance, BankAccount bankAccount)
        {
            Balance = balance;
            BankAccount = bankAccount;
        }

        public override void Deposit(int amount)
        {
            int bonus = amount / 10;

            Console.WriteLine($"Depositing {amount:C0} into {GetType()}, with additional 10% bonus of {bonus:C0}.");
            Balance += amount + bonus;
        }

        public override void Withdraw(int amount)
        {
            Console.WriteLine($"Withdrawing {amount:C0} from {GetType()}");
            Balance -= amount;

            BankAccount.BankAccountState = Balance switch
            {
                var balance when balance < 0 => new OverdrawnState(Balance, BankAccount),
                var balance when balance >= 0 && balance < 1000 => new RegularState(Balance, BankAccount),
                _ => null!
            };
        }
    }
}

