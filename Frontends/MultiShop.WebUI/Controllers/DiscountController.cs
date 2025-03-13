using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.DiscountServices;

namespace MultiShop.WebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly IBasketService _basketService;

        public DiscountController(IDiscountService discountService, IBasketService basketService)
        {
            _discountService = discountService;
            _basketService = basketService;
        }
        [HttpGet]
        public async Task<PartialViewResult> ConfirmDiscountCoupon()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmDiscountCoupon(string code)
        {
            var values = await _discountService.GetDiscountCode(code);
            if(values == null)
            {
                return RedirectToAction("Index", "ShoppingCart");
            }
            else
            {
                var basketValues = await _basketService.GetBasket();
                var totalPriceWithTax = basketValues.TotalPrice + basketValues.TotalPrice / 100 * 18;
                var DiscountValue = (totalPriceWithTax * values.Rate) / 100;
                var totalNewPriceWithDiscount = totalPriceWithTax - DiscountValue;
                ViewBag.totalNewPriceWithDiscount = totalNewPriceWithDiscount;
                return RedirectToAction("Index", "ShoppingCart", new { code, discountRate = values.Rate, totalNewPriceWithDiscount });
            }
        }
    }
}
