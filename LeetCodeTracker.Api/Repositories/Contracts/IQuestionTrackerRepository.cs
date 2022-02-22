using LeetCodeTracker.Dtos.Response.Shared;
using LeetCodeTracker.Models;

namespace LeetCodeTracker.Repositories.Contracts;

public interface IQuestionTrackerRepository
{
    Task<PageList<QuestionTracker>> GetAllQuestionsTrackersAsync(PaginationDto paginationDto);
    Task<QuestionTracker?> GetQuestionTrackerByIdAsync(int id);
    Task CreateQuestionTrackerAsync(QuestionTracker questionTracker);
    Task UpdateQuestionTrackerAsync(QuestionTracker questionTracker, int id);
    Task SaveAsync();
}