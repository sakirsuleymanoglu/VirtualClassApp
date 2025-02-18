using Newtonsoft.Json;
using System.Text.Json.Serialization;
using VirtualClassApp.Application.Dtos.Courses;

namespace VirtualClassApp.WebAPI;


public class PaginationObject
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
}


public sealed class CoursesPaginationResult : PaginationObject
{
    public CoursesPaginationResult()
    {
        Items = [];
    }

    [JsonPropertyName("courses")]
    public List<CourseDto> Items { get; set; }
}
