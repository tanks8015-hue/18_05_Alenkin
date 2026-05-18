using Microsoft.EntityFrameworkCore;
using Alenkin_18_05.Models;
namespace Alenkin_18_05.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
