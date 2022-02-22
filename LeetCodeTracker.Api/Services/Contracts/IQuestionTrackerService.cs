using LeetCodeTracker.Dtos.Request;
using LeetCodeTracker.Dtos.Response;
using LeetCodeTracker.Dtos.Response.Shared;
using LeetCodeTracker.Models;

namespace LeetCodeTracker.Services.Contracts;

public interface IQuestionTrackerService
{
    Task<(IEnumerable<QuestionTrackerDto> questions, PageMeta pageMeta)>
        GetAllQuestionsTrackersAsync(PaginationDto pagination);
    Task<QuestionTrackerDto?> GetQuestionsTrackerByIdAsync(int id);
    Task CreateQuestionTrackerAsync(QuestionTrackerDto questionTrackerDto);
    Task UpdateQuestionTrackerAsync(QuestionTrackerDto questionTrackerDto, int id);
}