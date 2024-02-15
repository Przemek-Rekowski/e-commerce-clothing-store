using Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class EcommerceShopDbContext : DbContext
    {
        public EcommerceShopDbContext(DbContextOptions<EcommerceShopDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductItem> Items { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Size> Sizes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductItem>()
                .HasKey(pi => new { pi.ProductId, pi.SizeId, pi.ColorId });

            modelBuilder.Entity<ProductItem>()
                .HasOne(pi => pi.Product)
                .WithMany(p => p.Items);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Items)
                .WithOne(pi => pi.Product)
                .HasForeignKey(pi => pi.ProductId);

            modelBuilder.Entity<ProductItem>()
                .HasOne(pi => pi.Color)
                .WithMany(c => c.Items)
                .HasForeignKey(pi => pi.ColorId);

            modelBuilder.Entity<ProductItem>()
                .HasOne(pi => pi.Size)
                .WithMany(s => s.Items)
                .HasForeignKey(pi => pi.SizeId);

            modelBuilder.Entity<Color>()
                .HasMany(c => c.Items)
                .WithOne(pi => pi.Color)
                .HasForeignKey(pi => pi.ColorId);

            modelBuilder.Entity<Size>()
                .HasMany(s => s.Items)
                .WithOne(pi => pi.Size)
                .HasForeignKey(pi => pi.SizeId);
        }
    }
}
