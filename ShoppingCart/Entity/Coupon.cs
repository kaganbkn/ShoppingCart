using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartDemo.Entity
{
    public class Coupon
    {
        public Guid Id { get; set; }
        public decimal MinimumAmount { get; set; }
        public decimal Discount { get; set; }
        public DiscountType DiscountType { get; set; }

        public Coupon(decimal minimumAmount, decimal discount, DiscountType discountType)
        {
            MinimumAmount = minimumAmount;
            Discount = discount;
            DiscountType = discountType;
        }
    }
}
