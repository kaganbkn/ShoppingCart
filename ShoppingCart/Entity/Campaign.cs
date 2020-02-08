using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ShoppingCart.Entity
{
    public class Campaign
    {
        public Guid Id { get; set; }
        public Category Category { get; set; }
        public decimal Discount { get; set; }
        public int ItemQuantity { get; set; }
        public DiscountType DiscountType { get; set; }

        public Campaign(Category category, decimal discount, int itemQuantity, DiscountType discountType)
        {
            Category = category;
            Discount = discount;
            ItemQuantity = itemQuantity;
            DiscountType = discountType;
        }
    }
}
