using AutoMapper;
using LeetCodeTracker.Dtos.Response;
using LeetCodeTracker.Dtos.Response.Shared;
using LeetCodeTracker.Repositories.Contracts;
using LeetCodeTracker.Services.Contracts;

namespace LeetCodeTracker.Services;

public class QuestionService : IQuestionService
{
    private readonly IMapper _mapper;
    private readonly IQuestionRepository _repo;

    public QuestionService(IQuestionRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<(IEnumerable<QuestionDto> questions, PageMeta pageMeta)> GetAllQuestionsAsync(
        PaginationDto pagination)
    {
        var result = await _repo.GetAllQuestionsAsync(pagination);
        var resultDto = _mapper.Map<IEnumerable<QuestionDto>>(result);
        return (questions: resultDto, pageMeta: result.PageMeta);
    }
}