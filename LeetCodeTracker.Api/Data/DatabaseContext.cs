using LeetCodeTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace LeetCodeTracker.Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Question>? Questions { get; set; }
    public DbSet<QuestionTracker>? QuestionsTrackers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Question>()
            .ToTable(nameof(Questions), t
                => t.ExcludeFromMigrations());
        Configure(modelBuilder);
    }

    private void Configure(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<QuestionTracker>(builder => { builder.HasKey(x => x.Id); });
    }
}