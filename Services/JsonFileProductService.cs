using TestApplication.Models;
using System.Text.Json;
using System.Net;
using System.Web.Http;

namespace TestApplication.Services
{
#nullable enable

    public class JsonFileProductService : IJsonFileProductService
    {
        /**
         * Our counter variable.
         */
        private int Counter;

        /**
         * Array containing the currently grabbed products.
         */
        public Product[] ThreeProducts { get; internal set; }

        /**
         * IWebHostEnvironment class variable.
         */
        public IWebHostEnvironment WebHostEnvironment { get; }

        /**
         * Constructor.
         */
        public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
            Counter = 0;
        }

        /**
         * Returns the file path of our JSON file.
         * 
         */
        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json"); }
        }

        IWebHostEnvironment IJsonFileProductService.WebHostEnvironment
        {
            get => throw new NotImplementedException(); set => throw new NotImplementedException();
        }

        /**
         * Returns the JSON product objects as an array.
         * 
         */
        public Product[] GetProducts()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Product[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            }
        }

        /**
         * Retrives the next three products for the JSON file.
         */
        private Product[] NextThreeProducts()
        {
            var products = this.GetProducts();
            var total = 0;
            var nextThreeProduct = new Product[3];

            while (total < 3 && Counter < products.Length)
            {
                nextThreeProduct[total++] = products[Counter++];
            }
            return nextThreeProduct;
        }

        /**
         * Updates the ThreeProducts array with the next available three products or whatever remains.
         */
        public void GetNextThreeProducts()
        {
            ThreeProducts = this.NextThreeProducts();
        }

        /**
         * Adds rating to JSON object base on supplied ID.
         */
        public void AddRatings(string productId, int rating)
        {
            Product[] products = this.GetProducts();

            // LINQ
            Product? query;

            query = products.First(x => x.Id == productId);

            if (query.Ratings == null)
            {
                query.Ratings = new int[] { rating };
            }
            else
            {
                var ratings = query.Ratings.ToList();
                ratings.Add(rating);
                query.Ratings = ratings.ToArray();
            }

            using (var outputStream = File.OpenWrite(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<Product>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    products
                    );
            }
        }

        /**
         * Resets the counter variable.
         */
        public JsonFileProductService ResetCounter()
        {
            this.Counter = 0;

            return this;
        }
    }
}
