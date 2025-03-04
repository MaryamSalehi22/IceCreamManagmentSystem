using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class IceCreamShopDbContext : DbContext
    {
        public IceCreamShopDbContext(DbContextOptions<IceCreamShopDbContext> options) : base(options) { }
        public IceCreamShopDbContext(){ }
        public DbSet<IceCream> IceCreams { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<IceCreamTopping> IceCreamToppings { get; set; }
        public DbSet<Order> Orders { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-DCVH6RQ\\MSSQLSERVER2;Initial Catalog=IceCreamDb;TrustServerCertificate=True;Integrated Security=SSPI");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IceCream>().HasData(
                new IceCream { Id = Guid.NewGuid(), Name = "Vanilla", Size = IceCreamSize.Small, BasePrice = 5.00m },
                new IceCream { Id = Guid.NewGuid(), Name = "Chocolate", Size = IceCreamSize.Medium, BasePrice = 5.50m },
                new IceCream { Id = Guid.NewGuid(), Name = "Strawberry", Size = IceCreamSize.Large, BasePrice = 6.00m }
            );

            modelBuilder.Entity<Topping>().HasData(
                new Topping { Id = Guid.NewGuid(), Name = "Smarties", Price = 1.00m },
                new Topping { Id = Guid.NewGuid(), Name = "Melted Chocolate", Price = 1.50m }
            );

            modelBuilder.Entity<IceCreamTopping>()
                .HasKey(it => new { it.IceCreamId, it.ToppingId });
        }
    }
}
