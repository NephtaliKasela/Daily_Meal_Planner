using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Reflection.Emit;
using BisinessLayer;

namespace DataLayer
{
    public class MyDBContext: DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
        }

        public DbSet<Category> Formations { get; set; }
        public DbSet<User> Users { get; set; }

        //get data
        //FormationMemoryRepository repository = new FormationMemoryRepository();
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Formation>()
        //    .Property(f => f.Descriotion)
        //        .HasMaxLength(500);

        //    modelBuilder.Entity<Formation>().HasData(repository.GetAllFormations());
        //}
    }
}