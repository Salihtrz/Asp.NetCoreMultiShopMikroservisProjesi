using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.OrderDtos.OrderAddressDtos;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.OrderServices.OrderAddressServices;

namespace MultiShop.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderAddressServices _orderAddressServices;
        private readonly IUserService _userService;

        public OrderController(IOrderAddressServices orderAddressServices, IUserService userService)
        {
            _orderAddressServices = orderAddressServices;
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.directory1 = "MultiShop";
            ViewBag.directory2 = "Siparişler";
            ViewBag.directory3 = "Sipariş İşlemleri";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateOrderAddressDto createOrderAddressDto)
        {
            var values = await _userService.GetUserInfo();
            createOrderAddressDto.UserID = values.Id;
            createOrderAddressDto.Description = "a";

            await _orderAddressServices.CreateOrderAddressAsync(createOrderAddressDto);

            return RedirectToAction("Index", "Payment");
        }
    }
}
