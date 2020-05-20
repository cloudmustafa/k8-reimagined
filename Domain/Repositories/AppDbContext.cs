using SimpleApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace SimpleApi.Domain.Repositories
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData
            (
                new User { Id = 100, Name = "First User", Age = 19 },
                new User { Id = 101, Name = "Second User", Age = 24 },
                new User { Id = 102, Name = "Thirg User", Age = 37 },
                new User { Id = 103, Name = "Fourth User", Age = 45 },
                new User { Id = 104, Name = "Fifth User", Age = 52 }
            );
        }
    }
}