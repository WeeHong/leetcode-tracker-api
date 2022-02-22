using LeetCodeTracker.Data;
using LeetCodeTracker.Dtos.Response.Shared;
using LeetCodeTracker.Models;
using LeetCodeTracker.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace LeetCodeTracker.Repositories;

public class QuestionTrackerRepository : IQuestionTrackerRepository
{
    private readonly DatabaseContext _context;

    public QuestionTrackerRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<PageList<QuestionTracker>> GetAllQuestionsTrackersAsync(PaginationDto paginationDto)
    {
        var result = await _context.QuestionsTrackers!
            .Skip((paginationDto.PageNumber - 1) * 50)
            .Take(50)
            .ToListAsync();

        var count = await _context.QuestionsTrackers!.CountAsync();

        return PageList<QuestionTracker>
            .ToPageList(result, count, paginationDto.PageNumber, 50);
    }

    public Task<QuestionTracker?> GetQuestionTrackerByIdAsync(int id)
    {
        return Task.FromResult(_context.QuestionsTrackers!.FirstOrDefault(x => x.Id == id));
    }

    public async Task CreateQuestionTrackerAsync(QuestionTracker questionTracker)
    {
        await _context.QuestionsTrackers!.AddAsync(questionTracker);
    }

    public Task UpdateQuestionTrackerAsync(QuestionTracker questionTracker, int id)
    {
        var result = _context.QuestionsTrackers!.FirstOrDefault(x => x.Id == id);
        if (result == null)
            throw new Exception("Id not found.");
        result.QuestionId = questionTracker.QuestionId;
        result.UserId = questionTracker.UserId;
        result.Status = questionTracker.Status;

        return Task.CompletedTask;
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}