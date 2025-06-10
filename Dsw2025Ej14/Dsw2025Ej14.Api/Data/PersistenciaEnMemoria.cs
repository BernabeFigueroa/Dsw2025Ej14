using Dsw2025Ej14.Api.Domain;
using System.Text.Json;

namespace Dsw2025Ej14.Api.Data
{
    public class PersistenciaEnMemoria
    {
        private List<Product> _products = new();

        public async Task LoadProducts()
        {
            const string filePath = "Data/products.json";

            if (!File.Exists(filePath))
                return;

            var json = await File.ReadAllTextAsync(filePath);
            var products = JsonSerializer.Deserialize<List<Product>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? [];

            _products = products;
        }

        public List<Product> GetActiveProducts()
        {
            return _products.Where(p => p.IsActive).ToList();
        }

        public Product? GetProductBySku(string sku)
        {
            return _products.FirstOrDefault(p => p.Sku == sku);
        }
    }
}
