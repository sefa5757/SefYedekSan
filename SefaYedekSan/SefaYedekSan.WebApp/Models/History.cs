namespace SefaYedekSan.WebApp.Models
{
    public class History:EntityBase
    {
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
    }
}
