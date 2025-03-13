using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.User.ViewComponents.UserLayoutViewComponent
{
    public class _UserLayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
