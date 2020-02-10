﻿using System;
using ShoppingCartDemo.Entity;
using ShoppingCartDemo.Enums;

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
            var campaign1 = new Campaign(food, 20.0, 7, DiscountType.Rate);
            var campaign2 = new Campaign(food, 50.0, 5, DiscountType.Rate);
            var campaign3 = new Campaign(food, 5.0, 5, DiscountType.Amount);
            var campaign4 = new Campaign(drink, 5.0, 7, DiscountType.Amount);
            var campaign5 = new Campaign(drink, 50.0, 5, DiscountType.Rate);
            Console.WriteLine("total : " + cart.GetTotalAmountBeforeCoupons);
            cart.ProductsPrint();
            Console.WriteLine("---");
            cart.ApplyDiscounts(campaign1,campaign2,campaign3, campaign4, campaign5);



            cart.ProductsPrint();
            Console.WriteLine("total : "+cart.GetTotalAmountBeforeCoupons);



            var coupon =new Coupon(600,10,DiscountType.Amount);
            var coupon2 = new Coupon(500, 10, DiscountType.Amount);
            cart.ApplyCoupon(coupon,coupon2);
            Console.WriteLine("total : "+cart.GetTotalAmountAfterDiscounts());

            var deliveryCostCalculator=new DeliveryCostCalculator(7,5);
            Console.WriteLine("->"+deliveryCostCalculator.CalculateFor(cart));
            Console.WriteLine("delivery : "+cart.CalculateNumberOfDeliveries());
            Console.WriteLine("product : "+cart.CalculateNumberOfProducts());
            Console.WriteLine(cart.GetTotalAmountAfterDiscounts());
            Console.WriteLine(cart.GetCouponDiscounts());
            Console.WriteLine(cart.GetCampaignDiscounts());
            Console.WriteLine(cart.GetDeliveryCost());
            cart.Print();

            Console.Read();
        }
    }
}
