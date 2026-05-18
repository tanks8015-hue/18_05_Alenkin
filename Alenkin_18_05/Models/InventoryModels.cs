using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace Alenkin_18_05.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;

        [JsonIgnore]
        public List<Product> Products { get; set; } = new();
    }

    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Role { get; set; } = null!; 
    }

    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string SKU { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int StockQuantity { get; set; }
        public string? PhotoUrl { get; set; }

        public Category? Category { get; set; }
    }
}
