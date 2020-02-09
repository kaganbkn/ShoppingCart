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
    }
}
