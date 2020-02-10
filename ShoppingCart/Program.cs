using System;
using ShoppingCartDemo.Enums;
using ShoppingCartDemo.Sources;

namespace ShoppingCartDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            var food = new Category("food");
            var drink = new Category("drink");

            var cola = new Product("Cola", 20, drink);
            var sprite = new Product("Sprite", 40, drink);
            var apple = new Product("Apple", 10.0, food);
            var almond = new Product("Almonds", 15.0, food);

            var cart = new ShoppingCart();

            cart.AddItem(apple, 3);
            cart.AddItem(almond, 2);
            cart.AddItem(cola, 5);
            cart.AddItem(sprite, 2);

            var campaign1 = new Campaign(food, 20.0, 2, DiscountType.Rate);
            var campaign2 = new Campaign(food, 1.0, 5, DiscountType.Amount);
            var campaign3 = new Campaign(drink, 25.0, 5, DiscountType.Rate);
            cart.ApplyDiscounts(campaign1, campaign2, campaign3);

            var coupon = new Coupon(170, 10, DiscountType.Amount);
            cart.ApplyCoupon(coupon);

            cart.Print();

            Console.Read();
        }
    }
}
