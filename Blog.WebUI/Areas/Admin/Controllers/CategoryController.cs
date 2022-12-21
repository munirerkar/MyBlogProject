using Microsoft.AspNetCore.Mvc;

namespace Blog.WebUI.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        public async Task<IActionResult> Index()
        {

            return View();
        }
    }
}
