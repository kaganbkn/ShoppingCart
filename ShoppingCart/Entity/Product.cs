using System;

namespace ShoppingCartDemo.Entity
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }
        public Product(string title, double price, Category category)
        {
            Title = title;
            Price = price;
            Category = category;
        }
    }
}
