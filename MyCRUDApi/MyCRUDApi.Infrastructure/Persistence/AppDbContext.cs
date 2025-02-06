using Microsoft.EntityFrameworkCore;
using MyCRUDApi.MyCRUDApi.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace MyCRUDApi.MyCRUDApi.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }  // ✅ Add DbSet for Products

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Optional: Configure constraints, relationships, or seed data if needed
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.ProductId);
                entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
                entity.Property(p => p.Description).HasMaxLength(255);
                entity.Property(p => p.Price).HasColumnType("decimal(18,2)");
                entity.Property(p => p.Stock).IsRequired();
            });
        }
    }
}
