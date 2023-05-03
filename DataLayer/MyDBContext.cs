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
        public DbSet<Category> Categories { get; set; }
        //public DbSet<User> Users { get; set; }

        //get data
        ProductsFileRepository repository = new ProductsFileRepository();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Formation>()
            //.Property(f => f.Descriotion)
            //    .HasMaxLength(500);

            modelBuilder.Entity<Category>().HasData(
                new Product { Id = 1, Name = "Бренди 40% алкоголя", Gramms = 100, Protein = 0.00, Fats = 0.00, Carbs = 0.50, Calories = 225, CategoryName = "Алкоголь" }
                
                );
        }
    }
}