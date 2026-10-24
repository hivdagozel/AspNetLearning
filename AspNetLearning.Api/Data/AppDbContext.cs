using AspNetLearning.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetLearning.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) 
    
        {
        }

        public DbSet<Product> Products => Set<Product>();
    }
}//DbSet<Product>: Product nesneleri üzerinde sorgulama, ekleme, güncelleme ve silme yapmamızı sağlar.
