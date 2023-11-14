using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    // Context sınıfı veritabanı bağlantı sınıfı oluştumaktadır. Bu sınıf EntityFrameworkCore içerisindeki DbContext kontex sınıfını miras almalıdır.
    public class DenedinMiContext : DbContext
    {   // Veritabanı bağlantı adresi tanımlanmıştır
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-MRUSB36;Database=DenedinMi;Trusted_Connection=true;TrustServerCertificate=True");
        }
        // Veritabanın da bulunan tabloların dbset içerisinde birer nesnesi oluşturulur.
        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
