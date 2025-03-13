using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.BasketDtos;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly IProductService _productService;

        public ShoppingCartController(IBasketService basketService, IProductService productService)
        {
            _basketService = basketService;
            _productService = productService;
        }

        public async Task<IActionResult> Index(string code, int discountRate, decimal totalNewPriceWithDiscount)
        {
            ViewBag.totalNewPriceWithDiscount = totalNewPriceWithDiscount;
            ViewBag.Code = code;
            ViewBag.discountRate = discountRate;
            ViewBag.directory1 = "Ana Sayfa";
            ViewBag.directory2 = "Ürünler";
            ViewBag.directory3 = "Sepetim";
            var values = await _basketService.GetBasket();
            ViewBag.Total = values.TotalPrice;
            var totalPriceWithTax = values.TotalPrice + values.TotalPrice / 100 * 18;
            var tax = values.TotalPrice / 100 * 18;
            ViewBag.tax = tax;
            ViewBag.TotalPriceWithTax = totalPriceWithTax;
            return View();
        }
        public async Task<IActionResult> AddBasketItem(string id)
        {
            var values = await _productService.GetByIdProductAsync(id);
            var items = new BasketItemDto
            {
                ProductID = values.ProductID,
                Price = values.ProductPrice,
                ProductName = values.ProductName,
                ProductImageUrl = values.ProductImageUrl,
                Quantity = 1
            };
            await _basketService.AddBasketItem(items);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> RemoveBasketItem(string id)
        {
            await _basketService.RemoveBasketItem(id);
            return RedirectToAction("Index");
        }
    }
}
