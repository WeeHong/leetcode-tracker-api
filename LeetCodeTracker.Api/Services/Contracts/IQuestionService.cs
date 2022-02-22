using LeetCodeTracker.Dtos.Response;
using LeetCodeTracker.Dtos.Response.Shared;

namespace LeetCodeTracker.Services.Contracts;

public interface IQuestionService
{
    Task<(IEnumerable<QuestionDto> questions, PageMeta pageMeta)>
        GetAllQuestionsAsync(PaginationDto pagination);
}