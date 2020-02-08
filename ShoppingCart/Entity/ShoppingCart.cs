using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Entity
{
    public class ShoppingCart
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public ShoppingCart(Product product,int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}
