using DriveWorks_MVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DriveWorks_MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CarModelParts>().HasNoKey();

            // Define foreign keys if necessary
            modelBuilder.Entity<CarModelParts>()
                .HasOne(cmp => cmp.CarModel)
                .WithMany()
                .HasForeignKey(cmp => cmp.CarModelId);

            modelBuilder.Entity<CarModelParts>()
                .HasOne(cmp => cmp.CarPart)
                .WithMany()
                .HasForeignKey(cmp => cmp.CarPartId);
        }

        public DbSet<CarBrand> CarBrands { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<CarPart> CarParts { get; set; }
        public DbSet<CarModelParts> CarModelParts { get; set; }
    }
}