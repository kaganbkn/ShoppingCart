using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShoppingCartDemo.Enums;

namespace ShoppingCartDemo.Entity
{
    public class ShoppingCart
    {
        public Dictionary<Product, int> Products { get; set; }
        public ShoppingCart()
        {
            Products = new Dictionary<Product, int>();
        }

        private double _totalCampaignDiscounts = 0;
        private double _totalCouponDiscounts = 0;

        public double GetTotalAmountAfterDiscounts()
        {
            return GetTotalAmountBeforeCoupons() - _totalCouponDiscounts;
        }

        public double GetTotalAmountBeforeCoupons()
        {
            return Products.Sum(c => c.Key.DiscountedAmount * c.Value);
        }

        public void AddItem(Product product, int quantity)
        {
            Products.Add(product, quantity);
        }
        public void ApplyDiscounts(params Campaign[] campaigns)
        {
            foreach (var campaign in campaigns)
            {
                if (Products.Where(c => c.Key.Category == campaign.Category).Sum(c => c.Value) < campaign.ItemQuantity) continue;
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
            foreach (var coupon in coupons.Where(c => c.MinimumAmount <= GetTotalAmountBeforeCoupons() - _totalCouponDiscounts))
            {
                _totalCouponDiscounts += coupon.DiscountType == DiscountType.Amount
                    ? coupon.Discount
                    : (coupon.Discount / 100) * GetTotalAmountBeforeCoupons();
            }
        }
        public double GetCouponDiscounts()
        {
            return _totalCouponDiscounts;
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
            Console.WriteLine("-----------------------------------------Shopping Cart-------------------------------------------");
            Console.WriteLine("|  Category Name  |  Product Name  |  Quantity  |  Unit Price  |  Total Price  |  Total Discount |");
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            foreach (var product in Products.OrderBy(c => c.Key.Category.Title))
            {
                var parentCategory = product.Key.Category.ParentCategory != null ? $"{product.Key.Category.ParentCategory.Title }->" : null;
                Console.WriteLine($"| {parentCategory}{TextBeautifier(product.Key.Category.Title, 15)} | " +
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
    }
}
