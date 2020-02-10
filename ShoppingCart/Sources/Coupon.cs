using ShoppingCartDemo.Enums;

namespace ShoppingCartDemo.Sources
{
    public class Coupon
    {
        public double MinimumAmount { get; set; }
        public double Discount { get; set; }
        public DiscountType DiscountType { get; set; }

        public Coupon(double minimumAmount, double discount, DiscountType discountType)
        {
            MinimumAmount = minimumAmount;
            Discount = discount;
            DiscountType = discountType;
        }
    }
}
