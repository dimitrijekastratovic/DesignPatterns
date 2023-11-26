using System;
namespace AbstractFactory
{
	/// <summary>
	/// Abstract Factory
	/// </summary>
	public interface IShoppingCartPurchaseFactory
	{
		IDiscountService CreateDiscountService();
		IShippingCostsService CreateShippingCostsService();
	}

	/// <summary>
	/// Abstract Product
	/// </summary>
	public interface IDiscountService
	{
		int DiscountPercentages { get; }
	}

	/// <summary>
	/// Concrete Product
	/// </summary>
	public class SerbiaDiscountService : IDiscountService
	{
        public int DiscountPercentages => 10;
	}

	/// <summary>
	/// Concrete Product
	/// </summary>
    public class FranceDiscountService : IDiscountService
    {
        public int DiscountPercentages => 20;
    }

    /// <summary>
    /// Abstract Product
    /// </summary>
    public interface IShippingCostsService
    {
		decimal ShippingCosts { get; }
    }


    /// <summary>
    /// Concrete Product
    /// </summary>
    public class SerbiaShippingCostsService : IShippingCostsService
    {
        public decimal ShippingCosts => 15;
    }

    /// <summary>
    /// Concrete Product
    /// </summary>
    public class FranceShippingCostsService : IShippingCostsService
    {
        public decimal ShippingCosts => 25;
    }

    /// <summary>
    /// Concrete Factory
    /// </summary>
    public class SerbiaShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
    {
        public IDiscountService CreateDiscountService()
        {
            return new SerbiaDiscountService();
        }

        public IShippingCostsService CreateShippingCostsService()
        {
            return new SerbiaShippingCostsService();
        }
    }

    /// <summary>
    /// Concrete Factory
    /// </summary>
    public class FranceShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
    {
        public IDiscountService CreateDiscountService()
        {
            return new FranceDiscountService();
        }

        public IShippingCostsService CreateShippingCostsService()
        {
            return new FranceShippingCostsService();
        }
    }

    /// <summary>
    /// Client Class
    /// </summary>
    public class ShoppingCart
    {
        private int _totalCosts;
        private readonly IDiscountService _discoutService;
        private readonly IShippingCostsService _shippingCostsService;

        //Constructor
        public ShoppingCart(IShoppingCartPurchaseFactory factory)
        {
            _totalCosts = 200;
            _discoutService = factory.CreateDiscountService();
            _shippingCostsService = factory.CreateShippingCostsService();
        }

        public void CalculateCosts()
        {
            Console.WriteLine($"Total costs = {_totalCosts - (_totalCosts / 100 * _discoutService.DiscountPercentages) + _shippingCostsService.ShippingCosts}");
        }
    }
}

