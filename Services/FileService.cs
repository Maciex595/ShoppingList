using System.Text.Json;
using ShoppingList.Models;

namespace ShoppingList.Services
{
    public class FileService
    {
        private string FilePath => Path.Combine(FileSystem.AppDataDirectory, "shopping_list.json");

        public List<Product> LoadProducts()
        {
            if (!File.Exists(FilePath))
                return new List<Product>();

            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
        }

        public void SaveProducts(List<Product> products)
        {
            var json = JsonSerializer.Serialize(products);
            File.WriteAllText(FilePath, json);
        }
    }
}