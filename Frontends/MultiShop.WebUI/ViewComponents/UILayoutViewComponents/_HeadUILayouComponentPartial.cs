using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _HeadUILayouComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
