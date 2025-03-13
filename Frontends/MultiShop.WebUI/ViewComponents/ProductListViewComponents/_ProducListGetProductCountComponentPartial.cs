using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProducListGetProductCountComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
