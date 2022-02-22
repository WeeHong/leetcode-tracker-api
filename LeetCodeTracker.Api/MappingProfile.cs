using AutoMapper;
using LeetCodeTracker.Dtos.Request;
using LeetCodeTracker.Dtos.Response;
using LeetCodeTracker.Models;

namespace LeetCodeTracker;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Question, QuestionDto>();
        CreateMap<QuestionTracker, QuestionTrackerDto>()
            .ReverseMap();
    }
}