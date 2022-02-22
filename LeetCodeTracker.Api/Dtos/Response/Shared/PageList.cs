using LeetCodeTracker.Models;

namespace LeetCodeTracker.Dtos.Response.Shared;

public class PageList<T> : List<T>
{
    public PageList(List<T> items, int count, int pageNumber, int pageSize)
    {
        PageMeta = new PageMeta
        {
            TotalCount = count,
            PageSize = pageSize,
            CurrentPage = pageNumber,
            TotalPage = (int) Math.Ceiling(count / (double) pageSize)
        };

        AddRange(items);
    }

    public PageMeta PageMeta { get; set; }

    public static PageList<T> ToPageList(IEnumerable<T> source, int total, int pageNumber, int pageSize)
    {
        return new PageList<T>(source.ToList(), total, pageNumber, pageSize);
    }
}