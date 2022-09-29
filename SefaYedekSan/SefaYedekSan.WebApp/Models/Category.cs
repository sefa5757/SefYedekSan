using System.Collections.Generic;

namespace SefaYedekSan.WebApp.Models
{
    public class Category:EntityBase
    {
        public string Name { get; set; }

        public int? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }

        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
    }
}
