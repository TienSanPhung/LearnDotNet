using PBlog.DomainEntities;

namespace PersonalBlog.UseCases.IRepository;

public interface IArticleRepository
{
    public Task<Article> GetById(Guid id);
    public Task<IEnumerable<Article>> GetAll();
    public Task Add(Article article);
    public Task Update(Article article);
    public Task Delete(Guid id);
    
}