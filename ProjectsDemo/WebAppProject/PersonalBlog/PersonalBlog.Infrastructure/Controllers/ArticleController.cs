using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PBlog.DomainEntities;
using PersonalBlog.Infrastructure.Models;
using PersonalBlog.UseCases;
using PersonalBlog.UseCases.IRepository;

namespace PersonalBlog.Infrastructure.Controllers;

[Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
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
    [HttpGet]
    public async Task<IActionResult> Add()
    {
        var article = new Article()
        {
            Id = Guid.Empty,
            Content = "",
            PublishDate = DateTime.UtcNow,
            Title = "",
            UpdateDate = DateTime.UtcNow,
        };
        return View("Form", article);
    }
    [HttpPost]
    public async Task<IActionResult> Add( Article article)
    {
        if (!ModelState.IsValid)
        {
            return View("Form",article);; // Trả lại view với lỗi xác thực
        }
        await _ArticleManager.AddArticle(article);
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    {
        var article = await _ArticleManager.GetArticleById(id);
        if (article == null)
        {
            _Logger.LogWarning($"Attempt to edit non-existent article with ID {id}");
            return NotFound();
        }
        return View("Form",article);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Article article)
    {
        if (!ModelState.IsValid)
        {
            return View("Form",article);
        }
        await _ArticleManager.EditArticle(article);
        return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _ArticleManager.DeleteArticle(id);
        return RedirectToAction(nameof(Index));
    }

    
    
}