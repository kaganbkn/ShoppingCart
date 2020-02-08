using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartDemo.Entity
{
    public class DeliveryCostCalculator
    {
        public double CostPerDelivery { get; set; }
        public double NumberOfDeliveries { get; set; }
        public double CostPerProduct { get; set; }
        private double FixedCost = 2.99;

        public DeliveryCostCalculator(double costPerDelivery, double numberOfDeliveries, double costPerProduct)
        {
            CostPerDelivery = costPerDelivery;
            NumberOfDeliveries = numberOfDeliveries;
            CostPerProduct = costPerProduct;
        }

        public double CalculateFor(DeliveryCostCalculator deliveryCostCalculator)
        {
            return (deliveryCostCalculator.CostPerDelivery * deliveryCostCalculator.NumberOfDeliveries) +
                   (deliveryCostCalculator.CostPerProduct * deliveryCostCalculator.NumberOfDeliveries) + FixedCost;
        }
        public double CalculateFor1(ShoppingCart shoppingCart)
        {
            return 1.3;
        }
    }
}
