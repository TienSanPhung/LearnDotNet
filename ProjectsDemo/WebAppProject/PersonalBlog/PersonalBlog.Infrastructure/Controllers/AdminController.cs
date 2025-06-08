using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PBlog.DomainEntities;
using PersonalBlog.Infrastructure.Models;
using PersonalBlog.UseCases;

namespace PersonalBlog.Infrastructure.Controllers;

[Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
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
    [AllowAnonymous] // Cho phép truy cập mà không cần xác thực
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromForm] LoginModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        try
        {
            if (await _AdminManager.AuthenAdmin(model.Password))
            {
                //
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "Admin")
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddSeconds(180)
                };
                
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme, 
                    new ClaimsPrincipal(identity), 
                    authProperties);
                return RedirectToAction("Index", "Article");
            }
        
            ModelState.AddModelError("", "Invalid password");
            return View(model);
        }
        catch (Exception ex)
        {
            _Logger.LogError($"Login failed: {ex.Message}");
            ModelState.AddModelError("", "Login failed");
            return View(model);
        }
    }

    
    [HttpPost]
    public async Task<IActionResult> ResetPassword(Admin admin)
    {
        try
        {
            await _AdminManager.ResetPassword();
            _Logger.LogInformation("Password for admin reset successfully.");
        }
        catch (Exception ex)
        {
            _Logger.LogError($"Reset password failed: {ex.Message}");
            TempData["Error"] = "Failed to reset password.";
            return RedirectToAction("Index");
        }
        TempData["Success"] = "Password reset successfully.";
        return RedirectToAction("Index","Article");
    }
    [HttpPost]
    public async Task<IActionResult> ChangesPassword([FromForm]ChangesPasswordModel changesPasswordModel)
    {
        if (!ModelState.IsValid)
        {
            TempData["Error"] = "Invalid input.";
            return RedirectToAction("Index", "Home");
        }

        try
        {
            await _AdminManager.ChangesPassword(changesPasswordModel.oldPassword, changesPasswordModel.newPassword);
            _Logger.LogInformation("Password changed successfully.");
            return RedirectToAction("Index","Article");
        }
        catch (Exception ex)
        {
            _Logger.LogError($"An error occurred while changing password: {ex.Message}");
            ModelState.AddModelError("", "Failed to change password.");
            return RedirectToAction("Index", "Home");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");

    }
}