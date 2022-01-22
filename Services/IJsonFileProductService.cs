using TestApplication.Models;

#nullable disable

namespace TestApplication.Services
{
    public interface IJsonFileProductService
    {
        public IWebHostEnvironment WebHostEnvironment { get; set; }
        public Product[] GetProducts();

        public void AddRatings(string productId, int rating);
    }
}