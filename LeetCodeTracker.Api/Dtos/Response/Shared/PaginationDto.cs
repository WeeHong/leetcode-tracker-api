namespace LeetCodeTracker.Dtos.Response.Shared;

public class PaginationDto
{
    private const int MaxPageSize = 50;
    public int PageNumber { get; set; } = 1;
}