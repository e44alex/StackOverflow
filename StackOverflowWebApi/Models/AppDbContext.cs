using Microsoft.EntityFrameworkCore;
using StackOverflow.Common.Models;

namespace StackOverflowWebApi.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public AppDbContext()
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Question> Questions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(u => u.Id);
        modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
        modelBuilder.Entity<Question>().HasIndex(u => u.Id).IsUnique();

        modelBuilder.Entity<Answer>().HasIndex(u => u.Id).IsUnique();
        modelBuilder.Entity<AnswerLiker>().HasKey(u => new
        {
            userId = u.Id,
            answerId = u.Answer.Id
        });

        modelBuilder.Entity<AnswerLiker>().HasOne(u => u.User).WithMany(x => x.LikedAnswers);
        modelBuilder.Entity<AnswerLiker>().HasOne(u => u.Answer).WithMany(x => x.Users);
    }
}