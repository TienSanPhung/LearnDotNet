using Microsoft.AspNetCore.Mvc;
using PBlog.DomainEntities;
using PersonalBlog.UseCases;
using PersonalBlog.UseCases.IRepository;

namespace PersonalBlog.Infrastructure.Controllers;

public class ArticleController : Controller
{
    readonly ILogger<ArticleController> _Logger;
    readonly IAdminManager _AdminManager;
    readonly IArticleManager _ArticleManager;

    // GET
    public ArticleController(ILogger<ArticleController> logger, IArticleManager articleManager)
    {
        this._Logger = logger;
        this._ArticleManager = articleManager ?? throw new System.ArgumentNullException(nameof(articleManager));
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var articles = await _ArticleManager.GetAllArticle();
        return View(articles);
    }

    [HttpPost]
    public async Task<IActionResult> Add( Article article)
    {
        await _ArticleManager.AddArticle(article);
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    {
        var article = await _ArticleManager.GetArticleById(id);
        if (article != null)
        {
            return View(article);
        }
        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Article article)
    {
            await _ArticleManager.EditArticle(article);
            return View(article);
    }
    [HttpPost]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _ArticleManager.DeleteArticle(id);
        return RedirectToAction(nameof(Index));
    }

    
    
}