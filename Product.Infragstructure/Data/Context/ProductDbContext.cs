using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product.Domain.Entites;

namespace Product.Infragstructure.Data.Context
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext() { }

        public ProductDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product.Domain.Entites.Product> Product { get; set; }
        public DbSet<TypeProduct> TypeProduct { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-50K05FU\\SQLEXPRESS;Initial Catalog = MicroService_CRUD;Integrated Security=True;Trust Server Certificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product.Domain.Entites.Product>()
                .HasOne(p => p.TypeProduct)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.TypeProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
