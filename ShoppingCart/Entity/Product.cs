using System;
using System.Reflection.Metadata;

namespace ShoppingCartDemo.Entity
{
    public class Product
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public double DiscountedAmount{ get; set; }
        public Category Category { get; set; }
        public Product(string title, double price, Category category)
        {
            Title = title;
            Price = price;
            Category = category;
            DiscountedAmount = price;
        }
    }
}
