using Microsoft.EntityFrameworkCore;

namespace StackOverflow.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.Username);

            modelBuilder.Entity<Question>().HasIndex(u => u.Id).IsUnique();

            modelBuilder.Entity<Answer>().HasIndex(u => u.Id).IsUnique();
        }
    }
}