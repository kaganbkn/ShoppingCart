using System;
using ShoppingCartDemo.Entity;

namespace ShoppingCartDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var food=new Category("food");

            var apple=new Product("Apple",100.0,food);
            var almond=new Product("Almonds",150.0,food);
            var cart= new ShoppingCart();
            cart.AddItem(apple, 3);
            cart.AddItem(almond, 1);







            Console.WriteLine(food.Title);


            Console.Read();
        }
    }
}
