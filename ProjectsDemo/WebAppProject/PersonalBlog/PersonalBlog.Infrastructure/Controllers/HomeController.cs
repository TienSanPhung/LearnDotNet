using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Infrastructure.Models;
using PersonalBlog.UseCases;

namespace PersonalBlog.Infrastructure.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    readonly IArticleManager _articleManager;

    public HomeController(ILogger<HomeController> logger, IArticleManager  articleManager)
    {
        _logger = logger;
        this._articleManager = articleManager ??  throw new ArgumentNullException(nameof(articleManager));;
    }

    public async Task<IActionResult> Index()
    {
        var articles = await _articleManager.GetAllArticle();
        return View(articles);
    }

    public async Task<IActionResult> Detail(Guid id)
    {
        var article = await _articleManager.GetArticleById(id);
        if (article is null)
        {
            _logger.LogWarning($"Article with ID {id} not found.");
            return NotFound();
        }

        return View(article);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}