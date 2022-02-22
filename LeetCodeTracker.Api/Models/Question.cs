using System.ComponentModel.DataAnnotations.Schema;

namespace LeetCodeTracker.Models;

[Table("Questions")]
public class Question
{
    [Column("id")] public int Id { get; set; }

    [Column("title")] public string? Title { get; set; }

    [Column("slug")] public string? Slug { get; set; }

    [Column("difficulty")] public string? Difficulty { get; set; }

    [Column("created_at")] public DateTime CreatedAt { get; set; }

    [Column("updated_at")] public DateTime UpdatedAt { get; set; }
}