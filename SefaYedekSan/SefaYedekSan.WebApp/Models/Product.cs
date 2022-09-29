namespace SefaYedekSan.WebApp.Models
{
    public class Product:EntityBase
    {
        public string Name { get; set; }

        public int CategoryId  { get; set; }
        public Category Category { get; set; }

        public float Price { get; set; }
        public string Image { get; set; }
    }
}
