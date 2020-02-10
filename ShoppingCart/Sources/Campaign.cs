using ShoppingCartDemo.Enums;

namespace ShoppingCartDemo.Sources
{
    public class Campaign
    {
        public Category Category { get; set; }
        public double Discount { get; set; }
        public int ItemQuantity { get; set; }
        public DiscountType DiscountType { get; set; }

        public Campaign(Category category, double discount, int itemQuantity, DiscountType discountType)
        {
            Category = category;
            Discount = discount;
            ItemQuantity = itemQuantity;
            DiscountType = discountType;
        }
    }
}
