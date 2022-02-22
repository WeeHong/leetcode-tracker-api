using LeetCodeTracker.Dtos.Request;
using LeetCodeTracker.Dtos.Response.Shared;
using LeetCodeTracker.Models;
using LeetCodeTracker.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LeetCodeTracker.Controllers;

[Route("/api/v1/[controller]")]
[ApiController]
public class QuestionTrackerController : ControllerBase
{
    private readonly IQuestionTrackerService _service;

    public QuestionTrackerController(IQuestionTrackerService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetQuestionsTrackers([FromQuery] PaginationDto pagination)
    {
        var result = await _service.GetAllQuestionsTrackersAsync(pagination);
        return Ok(new
        {
            data = result.questions,
            pagination = result.pageMeta
        });
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetQuestionTrackerById(int id)
    {
        var result = await _service.GetQuestionsTrackerByIdAsync(id);
        return Ok(new
        {
            data = result
        });
    }

    [HttpPost]
    public async Task<IActionResult> CreateQuestionAsync(QuestionTrackerDto questionTrackerDto)
    {
        await _service.CreateQuestionTrackerAsync(questionTrackerDto);
        return StatusCode(201);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateQuestionAsync(QuestionTrackerDto questionTrackerDto, int id)
    {
        await _service.UpdateQuestionTrackerAsync(questionTrackerDto, id);
        return NoContent();
    }
}