namespace ShoppingCartDemo.Sources
{
    public class Category
    {
        public string Title { get; set; }
        public Category ParentCategory { get; set; }
        public Category(string title)
        {
            Title = title;
        }
    }
}
