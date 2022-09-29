namespace SefaYedekSan.WebApp.Models
{
    public class Model:EntityBase
    {
        public string Name { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
