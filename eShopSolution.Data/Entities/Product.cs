﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace eShopSolution.Data.Entities
{
   public class Product
   {
        // Configure Attribute
        //[Table("Product")]
        public int Id {get;set;}
        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; }
        public int Stock { get; set; }
        public int ViewCount { get; set; }
        public DateTime DateCreated { get; set; }
        //[Required]
        public string SeoAlias {get;set;}

        public List<ProductInCategory> ProductInCategories { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<Cart> Carts { get; set; }
        public List<ProductTransaction> ProductTransactions { get; set; }
}
}
