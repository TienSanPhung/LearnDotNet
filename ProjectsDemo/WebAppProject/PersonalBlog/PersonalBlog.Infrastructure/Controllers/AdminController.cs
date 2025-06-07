using Microsoft.AspNetCore.Mvc;
using PBlog.DomainEntities;
using PersonalBlog.Infrastructure.Models;
using PersonalBlog.UseCases;

namespace PersonalBlog.Infrastructure.Controllers;

public class AdminController : Controller
{
    readonly ILogger<AdminController> _Logger;
    readonly IAdminManager _AdminManager;

    // GET
    public AdminController(ILogger<AdminController> logger, IAdminManager adminManager)
    {
        this._Logger = logger;
        this._AdminManager = adminManager;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> AuthenAdmin(Admin admin)
    {
        await _AdminManager.AuthenAdmin(admin.Password);
        return RedirectToRoute("/Article/Index");
    }
    [HttpPost]
    public async Task<IActionResult> ResetPassword(Admin admin)
    {
        await _AdminManager.ResetPassword();
        return RedirectToRoute("/Article/Index");
    }
    [HttpPost]
    public async Task<IActionResult> ChangesPassword([FromForm]ChangesPasswordModel changesPasswordModel)
    {
        await _AdminManager.ChangesPassword(changesPasswordModel.oldPassword,changesPasswordModel.newPassword);
        return RedirectToRoute("/Article/Index");
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        return RedirectToRoute("/Home/Index");
    }
}