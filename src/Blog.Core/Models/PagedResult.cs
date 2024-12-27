namespace Blog.Core.Models;

public class PagedResult<T> : PageResultBase where T : class
{
    public List<T> Results { get; set; }

    public PagedResult()
    {
        Results = new List<T>();
    }
}