using Microsoft.Extensions.Logging;
using PBlog.DomainEntities;
using PersonalBlog.UseCases.IRepository;

namespace PersonalBlog.UseCases;

public class ArticleServices : IArticleManager
{
    readonly ILogger<ArticleServices> _Logger;
    readonly IArticleRepository _Article;

    public ArticleServices(ILogger<ArticleServices> logger, IArticleRepository repository)
    {
        _Logger = logger;
        _Article =  repository ??  throw new ArgumentNullException(nameof(repository));
    }

    public async Task AddArticle(Article article)
    {
        if (article != null)
        {
            _Logger.LogInformation("Add article");
            await _Article.Add(article);
        }
        else
        {
            throw new  ArgumentNullException(nameof(article));
        }
        
    }

    public async Task EditArticle(Article article)
    {
        if (article != null)
        {
            _Logger.LogInformation("Edit article");
            await _Article.Update(article);
        }
        else
        {
           _Logger.LogWarning("Edit article");
            throw new  ArgumentNullException(nameof(article));
        }
    }

    public async Task DeleteArticle(Guid id)
    {
        var art = await _Article.GetById(id);
        if (art != null)
        {
            _Logger.LogInformation("Delete article");
            await _Article.Delete(id);
        }
        else
        {
            throw new  ArgumentNullException();
        }
    }

    public async Task<Article> GetArticleById(Guid id)
    {
        if (id == Guid.Empty)
        {
            _Logger.LogWarning("Get article by id");
            throw new ArgumentNullException();
        }
        return await _Article.GetById(id);
    }

    public async Task<IEnumerable<Article>> GetAllArticle()
    {
        _Logger.LogInformation("Get all article");
        return await _Article.GetAll() ?? [];
    }
}