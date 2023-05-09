using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Reflection.Emit;
using BusinessLayer;

namespace DataLayer
{
    public class MyDBContext: DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProduct> UserProducts { get; set; }

        //get data
        ProductsFileRepository repository = new ProductsFileRepository();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(repository.GetAllProducts());
        }
    }
}