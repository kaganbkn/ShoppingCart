using System;
using ShoppingCart.Entity;

namespace ShoppingCart
{
    class Program
    {
        static void Main(string[] args)
        {
            var food=new Category("food");
            Console.WriteLine(food.Title);


            Console.Read();
        }
    }
}
