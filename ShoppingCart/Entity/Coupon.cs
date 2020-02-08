using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartDemo.Entity
{
    public class Coupon
    {
        public Guid Id { get; set; }
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
