using System.Collections.Generic;

namespace SefaYedekSan.WebApp.Models
{
    public class Brand:EntityBase
    {
        public string Name { get; set; }

        public int CarTypeId { get; set; }
        public CarType CarType { get; set; }

        public List<History> Histories { get; set; }
        public List<Model> Models { get; set; }
    }
}
