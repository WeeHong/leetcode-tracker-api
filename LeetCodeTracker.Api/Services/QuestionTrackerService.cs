using AutoMapper;
using LeetCodeTracker.Dtos.Request;
using LeetCodeTracker.Dtos.Response.Shared;
using LeetCodeTracker.Models;
using LeetCodeTracker.Repositories.Contracts;
using LeetCodeTracker.Services.Contracts;

namespace LeetCodeTracker.Services;

public class QuestionTrackerService : IQuestionTrackerService
{
    private readonly IMapper _mapper;
    private readonly IQuestionTrackerRepository _repo;

    public QuestionTrackerService(IMapper mapper, IQuestionTrackerRepository repo)
    {
        _mapper = mapper;
        _repo = repo;
    }

    public async Task<(IEnumerable<QuestionTrackerDto> questions, PageMeta pageMeta)> GetAllQuestionsTrackersAsync(PaginationDto pagination)
    {
        var result = await _repo.GetAllQuestionsTrackersAsync(pagination);
        var resultDto = _mapper.Map<IEnumerable<QuestionTrackerDto>>(result);
        return (questions: resultDto, pageMeta: result.PageMeta);
    }

    public async Task<QuestionTrackerDto?> GetQuestionsTrackerByIdAsync(int id)
    {
        var result = await _repo.GetQuestionTrackerByIdAsync(id);
        return _mapper.Map<QuestionTrackerDto>(result);
    }

    public async Task CreateQuestionTrackerAsync(QuestionTrackerDto questionTrackerDto)
    {
        var result = _mapper.Map<QuestionTracker>(questionTrackerDto);
        await _repo.CreateQuestionTrackerAsync(result);
        await _repo.SaveAsync();
    }

    public async Task UpdateQuestionTrackerAsync(QuestionTrackerDto questionTrackerDto, int id)
    {
        var result = _mapper.Map<QuestionTracker>(questionTrackerDto);
        await _repo.UpdateQuestionTrackerAsync(result, id);
        await _repo.SaveAsync();
    }
}