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
            var blogs = modelBuilder.Entity<Blog>().ToTable("blog");
            blogs.HasKey(blog => blog.Id);
            blogs.Property(blog => blog.Id).ValueGeneratedOnAdd();
            blogs.HasMany(blog => blog.Posts)
                 .WithOne(post => post.Blog)
                 .HasForeignKey(post => post.BlogId);

            var posts = modelBuilder.Entity<Post>().ToTable("post");
            posts.HasKey(post => post.Id);
            posts.Property(post => post.Id).ValueGeneratedOnAdd();
            posts.HasOne(post => post.Blog)
                 .WithMany(blog => blog.Posts)
                 .HasForeignKey(post => post.BlogId);
        }
    }
}