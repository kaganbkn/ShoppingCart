using System;
using System.Linq;
using ShoppingCartDemo.Entity;
using ShoppingCartDemo.Enums;
using Xunit;

namespace ShoppingCartDemo.Tests
{
    public class UnitTest1
    {
        private ShoppingCart BuildShoppingCart()
        {
            var phones = new Category("phones");
            var xiaomi = new Product("xiaomi", 700, phones);
            var huawei = new Product("huawei", 900, phones);
            var shopCart = new ShoppingCart();
            shopCart.AddItem(xiaomi, 1);
            shopCart.AddItem(huawei, 1);
            return shopCart;
        }

        [Fact]
        public void Add_Item_To_Shopping_Cart()
        {
            var product = new Product("bmw", 1000, new Category("car"));
            var cart = new ShoppingCart();
            cart.AddItem(product, 2);
            Assert.Equal(2, cart.Products[product]);
        }

        [Fact]
        public void Apply_Discounts_For_Campaign() //refactor
        {
            var cart = BuildShoppingCart();
            var campaign = new Campaign(cart.Products.Select(c => c.Key.Category).FirstOrDefault(), 10, 2, DiscountType.Rate);
            cart.ApplyDiscounts(campaign);
            Assert.Equal(1440, cart.GetTotalAmountBeforeCoupons);
        }

        [Fact]
        public void Get_Campaign_Discounts() //refactor
        {
            var cart = BuildShoppingCart();
            var campaign = new Campaign(cart.Products.Select(c => c.Key.Category).FirstOrDefault(), 10, 2, DiscountType.Rate);
            cart.ApplyDiscounts(campaign);
            Assert.Equal(160, cart.GetCampaignDiscounts());
        }

        [Fact]
        public void Apply_Discounts_For_Coupon()
        {
            var cart = BuildShoppingCart();
            var coupon1 = new Coupon(1000, 20, DiscountType.Rate);
            var coupon2 = new Coupon(3000, 20, DiscountType.Rate);
            cart.ApplyCoupon(coupon1,coupon2);
            Assert.Equal(1280, cart.GetTotalAmountAfterDiscounts());

        }

        [Fact]
        public void Get_Coupon_Discounts()
        {
            var cart = BuildShoppingCart();
            var coupon1 = new Coupon(1000, 20, DiscountType.Rate);
            var coupon2 = new Coupon(3000, 20, DiscountType.Rate);
            cart.ApplyCoupon(coupon1, coupon2);
            Assert.Equal(320, cart.GetCouponDiscounts());
        }

        [Fact]
        public void Calculate_Delivery_Cost()
        {
            var cart = BuildShoppingCart();
            var deliveryCostCalculator = new DeliveryCostCalculator(2, 3,2.99);
            Assert.Equal(10.99, deliveryCostCalculator.CalculateFor(cart));

        }

        [Fact]
        public void Calculate_Number_Of_Product()
        {
            var cart = BuildShoppingCart();
            Assert.Equal(2, cart.CalculateNumberOfProducts());
        }

        [Fact]
        public void Calculate_Number_Of_Deliveries()
        {
            var cart = BuildShoppingCart();
            Assert.Equal(1, cart.CalculateNumberOfDeliveries());
        }
    }
}
