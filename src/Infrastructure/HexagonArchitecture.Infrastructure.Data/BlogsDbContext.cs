using HexagonArchitecture.Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace HexagonArchitecture.Infrastructure.Data
{
    public class BlogsDbContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=blogdb;Username=postgres;Password=80963144514Aa");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().ToTable("blog");
            modelBuilder.Entity<Post>()
                .ToTable("post")
                .HasOne(post => post.Blog)
                .WithMany(blog => blog.Posts)
                .HasForeignKey(post => post.BlogId);
        }
    }
}