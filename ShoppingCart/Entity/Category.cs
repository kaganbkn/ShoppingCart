﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Entity
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public Category(string title)
        {
            Title = title;
        }
    }
}