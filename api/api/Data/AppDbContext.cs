using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> users { get; set; }
        public DbSet<CategoryType> categoryTypes { get; set; }

        public DbSet<Category> categories { get; set; }

        public DbSet<Size> sizes { get; set; }
        public DbSet<Color> colors { get; set; }

        public DbSet<Product> products { get; set; }
        public DbSet<Cart> carts { get; set; }
        public DbSet<ProductImage> productImages { get; set; }
        public DbSet<ProductSize> productSizes { get; set; }
        public DbSet<Promotion> promotion { get; set; }
        public DbSet<UserPromotion> userPromotion { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryType>()
               .HasMany(ct => ct.Categories)
               .WithOne()
               .HasForeignKey(c => c.CategoryTypeId);
            modelBuilder.Entity<Product>()
                .HasOne(c => c.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryId);
            modelBuilder.Entity<Product>()
                .HasMany(c => c.ProductImages)
                .WithOne()
                .HasForeignKey(p => p.ProductId);
            modelBuilder.Entity<Product>()
                .HasMany(c => c.ProductSizes)
                .WithOne()
                .HasForeignKey(p => p.ProductId);
            modelBuilder.Entity<Product>()
                .HasMany(c => c.ProductColors)
                .WithOne()
                .HasForeignKey(p => p.ProductId);
            modelBuilder.Entity<ProductSize>()
                .HasOne(c => c.Size)
                .WithMany()
                .HasForeignKey(p => p.SizeId);
            modelBuilder.Entity<ProductColor>()
                .HasOne(c => c.Color)
                .WithMany()
                .HasForeignKey(p => p.ColorId);
            modelBuilder.Entity<User>()
                .HasMany(c=>c.UserPromotions)
                .WithOne()
                .HasForeignKey(p=>p.UserId);
            modelBuilder.Entity<Cart>()
                .HasOne(c=>c.Product)
                .WithMany()
                .HasForeignKey(p => p.ProductId);
        }
    }
}
