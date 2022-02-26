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
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Question> Questions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(u => u.UserId);
        modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
        modelBuilder.Entity<Question>().HasIndex(u => u.Id).IsUnique();

        modelBuilder.Entity<Answer>().HasIndex(u => u.AnswerId).IsUnique();
        modelBuilder.Entity<Answer>().HasOne(x => x.Creator).WithMany(x => x.Answers).OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<AnswerLiker>().HasKey(nameof(Answer.AnswerId), nameof(User.UserId));

        modelBuilder.Entity<AnswerLiker>().HasOne(u => u.User).WithMany(x => x.LikedAnswers).OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<AnswerLiker>().HasOne(u => u.Answer).WithMany(x => x.Users).OnDelete(DeleteBehavior.NoAction);
    }
}