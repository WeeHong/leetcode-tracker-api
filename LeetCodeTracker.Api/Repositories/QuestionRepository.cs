using LeetCodeTracker.Data;
using LeetCodeTracker.Dtos.Response.Shared;
using LeetCodeTracker.Models;
using LeetCodeTracker.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace LeetCodeTracker.Repositories;

public class QuestionRepository : IQuestionRepository
{
    private readonly DatabaseContext _context;

    public QuestionRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<PageList<Question>> GetAllQuestionsAsync(PaginationDto paginationDto)
    {
        var result = await _context.Questions!
            .Skip((paginationDto.PageNumber - 1) * 50)
            .Take(50)
            .ToListAsync();

        var count = await _context.Questions!.CountAsync();

        return PageList<Question>
            .ToPageList(result, count, paginationDto.PageNumber, 50);
    }
}