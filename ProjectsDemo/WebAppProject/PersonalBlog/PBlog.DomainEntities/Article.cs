namespace PBlog.DomainEntities;

public class Article
{
    public required Guid Id { get; set; } = Guid.Empty;
    public required string Title { get; set; }  = String.Empty;
    public string? Content { get; set; }
    public DateTime PublishDate { get; set; } = DateTime.UtcNow;
    public DateTime UpdateDate { get; set; } 
    
}