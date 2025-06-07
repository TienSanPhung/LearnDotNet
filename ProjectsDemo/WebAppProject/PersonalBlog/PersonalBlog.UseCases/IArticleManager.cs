using PBlog.DomainEntities;

namespace PersonalBlog.UseCases;

public interface IArticleManager
{
    public Task AddArticle(Article article);
    public Task EditArticle(Article article);
    public Task DeleteArticle(Guid id);
    public Task<Article> GetArticleById(Guid id);
    public Task<IEnumerable<Article>> GetAllArticle();
    
    
}