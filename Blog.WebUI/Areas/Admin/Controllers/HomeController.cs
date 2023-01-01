using Blog.Business.Abstract;
using Blog.Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static Blog.WebUI.ResultMessages.Messages;

namespace Blog.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IArticleService articleService;
        private readonly UserManager<AppUser> userManager;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public HomeController(IArticleService articleService,UserManager<AppUser> userManager)
        {
            this.articleService = articleService;
            this.userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var articles = await articleService.GetAllArticlesWithCategoryNonDeletedAsync();
            var loggedInUser = await userManager.GetUserAsync(HttpContext.User);
            return View(articles);
        }
    }
}
