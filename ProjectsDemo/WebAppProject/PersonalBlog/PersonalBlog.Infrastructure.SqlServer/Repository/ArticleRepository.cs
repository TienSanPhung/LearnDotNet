using Microsoft.EntityFrameworkCore;
using PBlog.DomainEntities;
using PersonalBlog.Infrastructure.SqlServer.ConText;
using PersonalBlog.UseCases.IRepository;

namespace PersonalBlog.Infrastructure.SqlServer.Repository;

public class ArticleRepository : IArticleRepository
{
    
    readonly BlogDbContext _Context;

    public ArticleRepository( BlogDbContext context)
    {
        this._Context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Article> GetById(Guid id)
    {
       return  await _Context.Articles.Where(x => x.Id == id).FirstOrDefaultAsync();
        
    }

    public async Task<IEnumerable<Article>> GetAll()
    {
        return await  _Context.Articles.ToListAsync();
    }

    public async Task Add(Article article)
    {
            await _Context.Articles.AddAsync(article);
            await _Context.SaveChangesAsync();
    }

    public async Task Update(Article article)
    {
        var art = await _Context.Articles.Where(x => x.Id == article.Id).FirstOrDefaultAsync();
        if (art != null)
        {
            art.Title = article.Title;
            art.Content = article.Content;
            art.UpdateDate = DateTime.UtcNow;
            await _Context.SaveChangesAsync();
        }
    }

    public async Task Delete(Guid id)
    {
        var art = await _Context.Articles.Where(x => x.Id == id).FirstOrDefaultAsync();
        _Context.Articles.Remove(art);
        await _Context.SaveChangesAsync();
    }
}