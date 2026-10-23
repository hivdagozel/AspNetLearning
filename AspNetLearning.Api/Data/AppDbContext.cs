using AspNetLearning.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetLearning.Api.Data
{
    //DbContext :Uygulama ile veritabanı arasındaki bağlantıyı yönetir.
    public class AppDbContext : DbContext
    {
        //DbContextOptions: Hangi veritabanına ve hangi bağlantı ayarlarıyla bağlanacağımızı taşır.
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) 
    
        {
        }

        public DbSet<Product> Products => Set<Product>();
    }
}//DbSet<Product>: Product nesneleri üzerinde sorgulama, ekleme, güncelleme ve silme yapmamızı sağlar.