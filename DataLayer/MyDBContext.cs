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
        public DbSet<UserMealtime> UserMealtime { get; set; }

        //get data
        ProductsFileRepository repository = new ProductsFileRepository();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            int count = 0;
            foreach (Product p in repository.ReadData())
            {
                modelBuilder.Entity<Product>().HasData(
                    new Product {Id = count + 1, Name = p.Name, Protein = p.Protein, Gramms = p.Gramms, Fats = p.Fats, Carbs = p.Carbs, Calories = p.Calories, CategoryName = p.CategoryName, State = false}

                );
                count++;
            }
        }
    }
}