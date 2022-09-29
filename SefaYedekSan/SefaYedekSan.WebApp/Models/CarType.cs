using System.Collections.Generic;

namespace SefaYedekSan.WebApp.Models
{
    public class CarType:EntityBase
    {
        public string Name { get; set; }
        public List<Brand> Brands { get; set; }
    }
}
