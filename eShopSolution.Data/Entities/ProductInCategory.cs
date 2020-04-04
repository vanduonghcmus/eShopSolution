﻿using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public class ProductInCategory
    {
        public int ProductId { get; set; }

        public Product Product { get; set; }
        public int CategotyId { get; set; }

        public Category Category { get; set; }
    }
}
