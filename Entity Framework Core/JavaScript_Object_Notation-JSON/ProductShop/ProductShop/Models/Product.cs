﻿namespace ProductShop.Models
{
    using System.Collections.Generic;

    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public int SellerId { get; set; }
        public virtual User Seller { get; set; } = null!;

        public int? BuyerId { get; set; }
        public virtual User? Buyer { get; set; }

        public ICollection<CategoryProduct> CategoriesProducts { get; set; }
            = new HashSet<CategoryProduct>();
    }
}