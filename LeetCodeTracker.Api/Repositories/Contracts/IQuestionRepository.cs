using LeetCodeTracker.Dtos.Response.Shared;
using LeetCodeTracker.Models;

namespace LeetCodeTracker.Repositories.Contracts;

public interface IQuestionRepository
{
    Task<PageList<Question>> GetAllQuestionsAsync(PaginationDto paginationDto);
}