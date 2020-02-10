using System;

namespace ShoppingCartDemo.Sources
{
    public class DeliveryCostCalculator
    {
        public double CostPerDelivery { get; set; }
        public double CostPerProduct { get; set; }
        public double FixedCost { get; set; }

        public DeliveryCostCalculator(double costPerDelivery, double costPerProduct, double fixedCost = 2.99)
        {
            CostPerDelivery = costPerDelivery;
            CostPerProduct = costPerProduct;
            FixedCost = fixedCost;
        }
        public double CalculateFor(ShoppingCart shoppingCart)
        {
            var numberOfDeliveries = shoppingCart.CalculateNumberOfDeliveries();
            var numberOfProducts = shoppingCart.CalculateNumberOfProducts();
            return Math.Round((CostPerDelivery * numberOfDeliveries) + (CostPerProduct * numberOfProducts) + FixedCost,2);
        }
    }
}
