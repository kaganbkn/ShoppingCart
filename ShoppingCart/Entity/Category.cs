using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartDemo.Entity
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
