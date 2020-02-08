using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartDemo.Entity
{
    public class ShoppingCart
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

        private Dictionary<Product,int> Products { get; set; }

        public void AddItem(Product product, int quantity)
        {
            Products.Add(product,quantity);
        }


        public void GetTotalAmountAfterDiscounts()
        {

        }

        public void GetCouponDiscounts()
        {

        }

        public void GetCampaignDiscounts()
        {

        }

        public void GetDeliveryCost()
        {

        }

        public void Print()
        {

        }
        public void CalculateNumberOfDeliveries()
        {
            //distinc categories
        }
        public void CalculateNumberOfProducts()
        {
            //number of product type, not quantity
        }
        public void ApplyDiscounts()
        {

        }
        public void ApplyCoupon(Coupon coupon)
        {

        }
    }
}
