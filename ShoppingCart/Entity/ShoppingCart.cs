﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShoppingCartDemo.Enums;

namespace ShoppingCartDemo.Entity
{
    public class ShoppingCart
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        private Dictionary<Product, int> Products { get; set; }
        private Dictionary<Category, int> ProductsInCategories { get; set; }

        private double _totalAmount;
        public double GetTotalAmountBeforeCoupons
        {
            get { return Products.Sum(c => c.Key.DiscountedAmount * c.Value); }
            set => _totalAmount = value;
        }
        public double GetTotalAmountAfterDiscounts()
        {
            return _totalAmount;
        }

        private double _totalCampaignDiscounts = 0;

        public ShoppingCart()
        {
            ProductsInCategories = new Dictionary<Category, int>();
            Products = new Dictionary<Product, int>();
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
                    var totalDiscount = campaign.DiscountType == DiscountType.Amount
                        ? campaign.Discount
                        : product.Key.DiscountedAmount * (campaign.Discount / 100);

                    product.Key.DiscountedAmount -= totalDiscount;
                    _totalCampaignDiscounts += totalDiscount * product.Value;
                }
            }
        }
        public void ApplyCoupon(params Coupon[] coupons)
        {
            foreach (var coupon in coupons.Where(c => c.MinimumAmount <= GetTotalAmountBeforeCoupons))
            {
                GetTotalAmountBeforeCoupons -= coupon.DiscountType == DiscountType.Amount
                    ? coupon.Discount
                    : (coupon.Discount / 100) * GetTotalAmountBeforeCoupons;
            }
        }

        public double GetCouponDiscounts()
        {
            return GetTotalAmountBeforeCoupons - _totalAmount;
        }

        public double GetCampaignDiscounts()
        {
            return _totalCampaignDiscounts;
        }

        public double GetDeliveryCost()
        {
            var cost = new DeliveryCostCalculator(7, 5);
            return cost.CalculateFor(this);
        }

        public void Print()
        {
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            Console.WriteLine("|  Category Name  |  Product Name  |  Quantity  |  Unit Price  |  Total Price  |  Total Discount |");
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            foreach (var product in Products.OrderBy(c => c.Key.Category.Title))
            {
                Console.WriteLine($"| {TextBeautifier(product.Key.Category.Title, 15)} | " +
                                  $"{TextBeautifier(product.Key.Title, 14)} | " +
                                  $"{TextBeautifier(product.Value.ToString(), 10)} | " +
                                  $"{TextBeautifier(product.Key.Price, 12)} | " +
                                  $"{TextBeautifier(product.Value * product.Key.Price, 13)} | " +
                                  $"{TextBeautifier((product.Key.Price - product.Key.DiscountedAmount) * product.Value, 15)} |");
            }
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            Console.WriteLine($"------------------------------ Total Amount : {Products.Sum(c => c.Key.Price * c.Value)}");
            Console.WriteLine($"------------- Total Discounts for Campaigns : {GetCampaignDiscounts()}");
            Console.WriteLine($"--------------- Total Discounts for Coupons : {GetCouponDiscounts()}");
            Console.WriteLine($"-------------- Total Amount After Discounts : {GetTotalAmountAfterDiscounts()}");
            Console.WriteLine($"----------------------------- Delivery Cost : {GetDeliveryCost()}");

        }
        public int CalculateNumberOfDeliveries()
        {
            return Products.Select(c => c.Key.Category).Distinct().Count();
        }
        public int CalculateNumberOfProducts()
        {
            return Products.Keys.Count;
        }

        private string TextBeautifier<T>(T text, int character)
        {
            var value = text.ToString();
            return value.PadLeft(character / 2, ' ').PadRight(character, ' ');
        }

        private void NumberOfProductsInCategories() //refactor this code
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
        public void ProductsInCategoriesPrint() //sil
        {
            foreach (var item in ProductsInCategories)
            {
                Console.WriteLine("--> " + item.Key.Title + " " + item.Value);
            }
        }
        public void ProductsPrint() //sil
        {
            foreach (var item in Products)
            {
                Console.WriteLine("--> name : " + item.Key.Title + " price: " + item.Key.Price + " quantity: " + item.Value);
            }
        }
    }
}
