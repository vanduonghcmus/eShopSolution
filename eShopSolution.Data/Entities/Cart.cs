using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Entities
{
   public class Cart
   {
       public int Id { get; set; }
       public string ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

    }
}
