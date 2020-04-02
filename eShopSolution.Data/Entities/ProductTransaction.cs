using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public class ProductTransaction
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SeoTitile { get; set; }
        public string Details { get; set; }
        public string SeoDescription { get; set; }
        public int LanguageId { get; set; }

    }
}
