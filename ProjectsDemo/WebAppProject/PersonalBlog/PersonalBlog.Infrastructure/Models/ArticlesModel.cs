namespace PersonalBlog.Infrastructure.Models;

public class ArticlesModel
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public DateTime PushlishDate { get; set; }
    public DateTime UpdateDate { get; set; }
    
}