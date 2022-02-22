using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LeetCodeTracker.Controllers;
using LeetCodeTracker.Dtos.Response;
using LeetCodeTracker.Dtos.Response.Shared;
using LeetCodeTracker.Repository.Contracts;
using LeetCodeTracker.Services;
using LeetCodeTracker.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace LeetCodeTracker.UnitTest;

public class QuestionControllerTest
{
    private readonly IMapper _mapper;
    private readonly IQuestionRepository _repo;
    private readonly QuestionController _controller;
    private readonly IQuestionService _service;

    public QuestionControllerTest()
    {
        _service = new QuestionService(_repo, _mapper);
        _controller = new QuestionController(_service);
    }
    
    [Fact]
    public void GetAllRecords()
    {
        var paginationDto = new PaginationDto()
        {
            PageNumber = 1
        };
        var result = _controller.GetAllQuestions(paginationDto);
    }
}