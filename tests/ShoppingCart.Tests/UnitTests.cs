using System;
using System.Linq;
using ShoppingCartDemo.Enums;
using ShoppingCartDemo.Sources;
using Xunit;

namespace ShoppingCartDemo.Tests
{
    public class UnitTests
    {
        private ShoppingCart BuildShoppingCart()
        {
            var phone = new Category("phone");
            var computer = new Category("computer");
            var xiaomi = new Product("xiaomi", 700, phone);
            var huawei = new Product("huawei", 900, phone);
            var asus = new Product("asus", 3500, computer);
            var lenovo = new Product("lenovo", 3000, computer);
            var shopCart = new ShoppingCart();
            shopCart.AddItem(xiaomi, 1);
            shopCart.AddItem(huawei, 3);
            shopCart.AddItem(asus, 2);
            shopCart.AddItem(lenovo, 5);
            return shopCart;
        }

        [Fact]
        public void Add_Item_To_Shopping_Cart()
        {
            var product = new Product("bmw", 1000, new Category("car"));
            var cart = new ShoppingCart();
            cart.AddItem(product, 2);
            Assert.Contains(product, cart.Products.Keys);
        }

        [Fact]
        public void Apply_Discounts_For_Rate_Type_Campaign()
        {
            var cart = BuildShoppingCart();
            var categoryFromCart = cart.Products.Select(c => c.Key.Category)
                .OrderBy(t => t.Title)
                .FirstOrDefault(); //computer
            var campaign = new Campaign(categoryFromCart, 10, 5, DiscountType.Rate);
            cart.ApplyDiscounts(campaign);
            Assert.Equal(19800, cart.Products
                .Where(z => z.Key.Category == categoryFromCart)
                .Sum(c => c.Key.DiscountedAmount * c.Value));
        }

        [Fact]
        public void Apply_Discounts_For_Amount_Type_Campaign()
        {
            var cart = BuildShoppingCart();
            var categoryFromCart = cart.Products.Select(c => c.Key.Category)
                .OrderByDescending(t => t.Title)
                .FirstOrDefault(); //phone
            var campaign = new Campaign(categoryFromCart, 150, 2, DiscountType.Amount);
            cart.ApplyDiscounts(campaign);
            Assert.Equal(2800, cart.Products
                .Where(z => z.Key.Category == categoryFromCart)
                .Sum(c => c.Key.DiscountedAmount * c.Value));
        }

        [Fact]
        public void Apply_Discounts_For_Multiple_Campaign()
        {
            var cart = BuildShoppingCart();
            var categoryFromCart = cart.Products.Select(c => c.Key.Category)
                .OrderByDescending(t => t.Title)
                .FirstOrDefault();
            var campaign1 = new Campaign(categoryFromCart, 20, 2, DiscountType.Rate);
            var campaign2 = new Campaign(categoryFromCart, 150, 3, DiscountType.Amount);
            cart.ApplyDiscounts(campaign1, campaign2);
            Assert.Equal(2120, cart.Products
                .Where(z => z.Key.Category == categoryFromCart)
                .Sum(c => c.Key.DiscountedAmount * c.Value));
        }

        [Fact]
        public void Get_Campaign_Discounts()
        {
            var cart = BuildShoppingCart();
            var categoryFromCart = cart.Products.Select(c => c.Key.Category)
                .OrderByDescending(t => t.Title)
                .FirstOrDefault();
            var campaign = new Campaign(categoryFromCart, 10, 2, DiscountType.Rate);
            cart.ApplyDiscounts(campaign);
            Assert.Equal(340, cart.GetCampaignDiscounts());
        }

        [Fact]
        public void Apply_Discounts_For_Multiple_Coupon()
        {
            var cart = BuildShoppingCart();
            var coupon1 = new Coupon(20000, 10, DiscountType.Rate);
            var coupon2 = new Coupon(10000, 1200, DiscountType.Amount);
            cart.ApplyCoupon(coupon1, coupon2);
            Assert.Equal(21660, cart.GetTotalAmountAfterDiscounts());
        }

        [Fact]
        public void Get_Coupon_Discounts()
        {
            var cart = BuildShoppingCart();
            var coupon1 = new Coupon(20000, 10, DiscountType.Rate);
            var coupon2 = new Coupon(10000, 1200, DiscountType.Amount);
            cart.ApplyCoupon(coupon1, coupon2);
            Assert.Equal(3740, cart.GetCouponDiscounts());
        }

        [Fact]
        public void Calculate_Delivery_Cost()
        {
            var cart = BuildShoppingCart();
            var deliveryCostCalculator = new DeliveryCostCalculator(2, 3, 2.99);
            Assert.Equal(18.99, deliveryCostCalculator.CalculateFor(cart));

        }

        [Fact]
        public void Calculate_Number_Of_Product()
        {
            var cart = BuildShoppingCart();
            Assert.Equal(4, cart.CalculateNumberOfProducts());
        }

        [Fact]
        public void Calculate_Number_Of_Deliveries()
        {
            var cart = BuildShoppingCart();
            Assert.Equal(2, cart.CalculateNumberOfDeliveries());
        }
    }
}
