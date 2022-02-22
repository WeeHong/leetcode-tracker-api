using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeetCodeTracker.Models;

[Table("QuestionsTrackers")]
public class QuestionTracker
{
    [Column("id")] public int Id { get; set; }

    [Column("question_id")] public int QuestionId { get; set; }

    [Column("user_id")] public string? UserId { get; set; }

    [Column("status")]
    [Required(ErrorMessage = "Status is required.")]
    public string? Status { get; set; }

    [Column("created_at")] public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Column("updated_at")] public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}