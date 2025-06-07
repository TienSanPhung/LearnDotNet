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
        this._Logger = logger;
        this._Article =  repository ??  throw new ArgumentNullException(nameof(repository));
    }

    public async Task AddArticle(Article article)
    {
        if (article != null)
        {
            await _Article.Add(article);
            _Logger.LogInformation("The article added. {Article}",article);
        }
        else
        {
            _Logger.LogInformation("The article could not be added.");
            throw new  ArgumentNullException(nameof(article));
        }
        
    }

    public async Task EditArticle(Article article)
    {
        var art = await _Article.GetById(article.Id);
        if (art != null)
        {
            await _Article.Update(article);
            _Logger.LogInformation("The article updated. {Article}",article);
        }
        else
        {
            _Logger.LogInformation("The article could not be updated.");
            throw new  ArgumentNullException(nameof(article));
        }
    }

    public async Task DeleteArticle(Guid id)
    {
        var art = await _Article.GetById(id);
        if (art != null)
        {
            await _Article.Delete(id);
            _Logger.LogInformation("The article delete.");
        }
        else
        {
            _Logger.LogInformation("The article could not finded.");
            throw new  ArgumentNullException();
        }
    }

    public async Task<Article> GetArticleById(Guid id)
    {
        if (id != Guid.Empty)
        {
            _Logger.LogInformation("The article id's {ArticleId} counldn't find", id);
        }
        return await _Article.GetById(id);
    }

    public async Task<IEnumerable<Article>> GetAllArticle()
    {
        return await _Article.GetAll() ?? [];
    }
}