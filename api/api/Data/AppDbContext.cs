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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryType>()
               .HasMany(ct => ct.Categories)
               .WithOne()
               .HasForeignKey(c => c.CategoryTypeId);

        }
    }
}
