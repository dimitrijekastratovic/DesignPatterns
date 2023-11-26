using System;
namespace Bridge
{

    /// <summary>
    /// Abstraction
    /// </summary>
    public abstract class Menu
    {
        public readonly ICoupon _coupon = null!; //null forgiving 
        public abstract int CalculatePrice();

        public Menu(ICoupon coupon)
        {
            _coupon = coupon;
        }
    }

    /// <summary>
    /// Redefined Abstraction
    /// </summary>
    public class VegetarianMenu : Menu
    {
        public VegetarianMenu(ICoupon coupon) : base(coupon)
        {
        }

        public override int CalculatePrice()
        {
            return 20 - _coupon.CouponValue;
        }
    }

    /// <summary>
    /// Redefined Abstraction
    /// </summary>
    public class MeatMenu : Menu
    {
        public MeatMenu(ICoupon coupon) : base(coupon)
        {
        }

        public override int CalculatePrice()
        {
            return 25 - _coupon.CouponValue;
        }
    }

    /// <summary>
    /// Implementor
    /// </summary>
    public interface ICoupon
	{
	    int CouponValue { get; }
	}

    /// <summary>
    /// Concrete Implementor
    /// </summary>
    public class OneEuroCoupon : ICoupon
    {
        public int CouponValue { get => 1; }
    }

    /// <summary>
    /// Concrete Implementor
    /// </summary>
    public class TwoEuroCoupon : ICoupon
    {
        public int CouponValue { get => 2; }
    }
}