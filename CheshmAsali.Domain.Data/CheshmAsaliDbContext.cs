using CheshmAsali.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CheshmAsali.Domain.Data
{
    public class CheshmAsaliDbContext : DbContext
    {
        public CheshmAsaliDbContext(DbContextOptions<CheshmAsaliDbContext> options)
            : base(options)
        {
        }

        // تعریف DbSet‌ها
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // تنظیمات بیشتر مدل‌ها در اینجا
        }
    }
}