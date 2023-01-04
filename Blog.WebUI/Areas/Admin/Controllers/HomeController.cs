using Blog.Business.Abstract;
using Blog.Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        private readonly IDashboardService dashboardService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public HomeController(IArticleService articleService,UserManager<AppUser> userManager,IDashboardService dashboardService)
        {
            this.articleService = articleService;
            this.userManager = userManager;
            this.dashboardService = dashboardService;
        }
        public async Task<IActionResult> Index()
        {
            var articles = await articleService.GetAllArticlesWithCategoryNonDeletedAsync();
            return View(articles);
        }
        [HttpGet]
        public async Task<IActionResult> YearlyArticleCounts()
        {
            var count = await dashboardService.GetYearlyArticleCounts();
            return Json(JsonConvert.SerializeObject(count));
        }
        [HttpGet]
        public async Task<IActionResult> TotalArticleCount()
        {
            var count = await dashboardService.GetTotalArticleCount();
            return Json(count);
        }
        [HttpGet]
        public async Task<IActionResult> TotalCategoryCount()
        {
            var count = await dashboardService.GetTotalCategoryCount();
            return Json(count);
        }
        [HttpGet]
        public async Task<IActionResult> TotalUserCount()
        {
            var count = await dashboardService.GetTotalUserCount();
            return Json(count);
        }
    }
}
