using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tech_test_payment_api.src.Entities;

namespace tech_test_payment_api.src.Context
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Seller> Seller { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().HasKey(key => key.Id);
            builder.Entity<Seller>().HasKey(key => key.SellerId);
            builder.Entity<Sale>(saleTable =>
            {
                saleTable.HasKey(entitySale => entitySale.Id);

                saleTable.HasMany(products => products.Product).WithOne().HasForeignKey(product => product.IdSale);

                saleTable.HasOne(seller => seller.Seller).WithOne().HasForeignKey<Seller>(key => key.SellerId);
            });
        }
    }
}