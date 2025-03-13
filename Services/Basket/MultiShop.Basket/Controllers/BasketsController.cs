using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Basket.Dtos;
using MultiShop.Basket.LoginServices;
using MultiShop.Basket.Services;

namespace MultiShop.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILoginService _loginService;

        public BasketsController(IBasketService basketService, ILoginService loginService)
        {
            _basketService = basketService;
            _loginService = loginService;
        }
        [HttpGet]
        public async Task<IActionResult> GetMyBasketDetail()
        {
            var user = User.Claims; // Sisteme girmiş olan Token'a ait bilgileri gösterecek.
            var values = await _basketService.GetBasket(_loginService.GetUserId);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> SaveMyBasket(BasketTotalDto basketTotalDto)
        {
            basketTotalDto.UserID = _loginService.GetUserId;
            await _basketService.Savebasket(basketTotalDto);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
            await _basketService.Deletebasket(_loginService.GetUserId);
            return Ok();
        }
    }
}
