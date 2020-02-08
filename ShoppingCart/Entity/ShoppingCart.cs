using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCartDemo.Entity
{
    public class ShoppingCart
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        private Dictionary<Product, int> Products { get; set; }
        private Dictionary<Category, int> ProductsInCategories { get; set; }

        public ShoppingCart()
        {
            ProductsInCategories = new Dictionary<Category, int>();
            Products = new Dictionary<Product, int>();
        }

        public void ProductsInCategoriesPrint()
        {
            foreach (var item in ProductsInCategories)
            {
                Console.WriteLine("--> " + item.Key.Title + " " + item.Value);
            }
        }
        public void ProductsPrint()
        {
            foreach (var item in Products)
            {
                Console.WriteLine("--> name : " + item.Key.Title + " price: " + item.Key.Price + " quantity: " + item.Value);
            }
        }

        public void AddItem(Product product, int quantity)
        {
            Products.Add(product, quantity);
        }
        public void ApplyDiscounts(params Campaign[] campaigns)
        {
            NumberOfProductsInCategories();
            foreach (var campaign in campaigns)
            {
                if (ProductsInCategories[campaign.Category] < campaign.ItemQuantity) continue;
                foreach (var product in Products.Where(c => c.Key.Category == campaign.Category))
                {
                    if (campaign.DiscountType == DiscountType.Amount)
                    {
                        product.Key.Price -= campaign.Discount;

                    }
                    else
                    {
                        product.Key.Price -= product.Key.Price * (campaign.Discount / 100);

                    }
                }
            }
        }
        public void ApplyCoupon(params Campaign[] campaigns)
        {
            NumberOfProductsInCategories();
            foreach (var campaign in campaigns)
            {
                if (ProductsInCategories[campaign.Category] < campaign.ItemQuantity) continue;
                foreach (var product in Products.Where(c => c.Key.Category == campaign.Category))
                {
                    if (campaign.DiscountType == DiscountType.Amount)
                    {
                        product.Key.Price -= campaign.Discount;

                    }
                    else
                    {
                        product.Key.Price -= product.Key.Price * (campaign.Discount / 100);

                    }
                }
            }
        }

        private double GetTotalAmountBeforeDiscounts()
        {
            double total = 0;
            foreach (var product in Products)
            {
                total += product.Key.Price * product.Value;
            }
            return total;
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
        public void ApplyCoupon(Coupon coupon)
        {

        }


        public void NumberOfProductsInCategories()
        {
            foreach (var product in Products)
            {
                if (ProductsInCategories.ContainsKey(product.Key.Category))
                {
                    ProductsInCategories[product.Key.Category] += product.Value;
                }
                else
                {
                    ProductsInCategories.Add(product.Key.Category, product.Value);
                }
            }
        }
    }
}
