using System;
using ShoppingCartDemo.Entity;

namespace ShoppingCartDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var food=new Category("food");
            var drink = new Category("drink");

            var cola = new Product("Cola", 120, drink);
            var sprite = new Product("Sprite", 90, drink);
            var apple=new Product("Apple",100.0,food);
            var almond=new Product("Almonds",150.0,food);
            var cart= new ShoppingCart();
            cart.AddItem(apple, 3);
            cart.AddItem(almond, 2);
            cart.AddItem(cola, 5);
            cart.AddItem(sprite, 1);
            var campaign1 = new Campaign(food, 20.0, 3, DiscountType.Rate);
            var campaign2 = new Campaign(food, 50.0, 5, DiscountType.Rate);
            var campaign3 = new Campaign(food, 5.0, 5, DiscountType.Amount);
            var campaign4 = new Campaign(drink, 5.0, 5, DiscountType.Amount);
            var campaign5 = new Campaign(drink, 50.0, 5, DiscountType.Rate);
            cart.ProductsPrint();
            Console.WriteLine("asd");
            cart.ApplyDiscounts(campaign1,campaign2,campaign3, campaign4, campaign5);
            cart.ProductsPrint();
            cart.NumberOfProductsInCategories();

            cart.ProductsPrint();





            Console.Read();
        }
    }
}
