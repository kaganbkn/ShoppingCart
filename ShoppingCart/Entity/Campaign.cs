using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ShoppingCartDemo.Entity
{
    public class Campaign
    {
        public Category Category { get; set; }
        public double Discount { get; set; }
        public int ItemQuantity { get; set; }
        public DiscountType DiscountType { get; set; }

        public Campaign(Category category, double discount, int itemQuantity, DiscountType discountType)
        {
            Category = category;
            Discount = discount;
            ItemQuantity = itemQuantity;
            DiscountType = discountType;
        }
    }
}
