using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;

namespace MultiShop.WebUI.Controllers
{
    public class TestController : Controller
    {
        private readonly ICategoryService _categoryService;

        public TestController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Deneme2()
        {
            var result = await _categoryService.GetAllCategoryAsync();
            return View(result);
        }
    }
}
