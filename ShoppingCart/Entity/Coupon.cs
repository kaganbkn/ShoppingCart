using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCartDemo.Enums;

namespace ShoppingCartDemo.Entity
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
