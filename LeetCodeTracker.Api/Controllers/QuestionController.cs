using LeetCodeTracker.Dtos.Response.Shared;
using LeetCodeTracker.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LeetCodeTracker.Controllers;

[Route("/api/v1/[controller]")]
[ApiController]
public class QuestionController : ControllerBase
{
    private readonly IQuestionService _service;

    public QuestionController(IQuestionService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllQuestions([FromQuery] PaginationDto pagination)
    {
        var result = await _service.GetAllQuestionsAsync(pagination);
        return Ok(new
        {
            data = result.questions,
            pagination = result.pageMeta
        });
    }
}