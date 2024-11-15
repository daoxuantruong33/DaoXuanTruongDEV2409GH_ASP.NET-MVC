using Microsoft.EntityFrameworkCore;
using NetCoreMVCLab06.Models;
using NetCoreMVCLAB6.Models;
namespace NetCoreLAB6_EF.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
