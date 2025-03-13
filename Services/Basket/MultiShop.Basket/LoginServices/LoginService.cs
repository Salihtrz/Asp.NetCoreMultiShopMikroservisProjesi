namespace MultiShop.Basket.LoginServices
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public LoginService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        // GetUserId property' sine bu tanımlamış olduğumuz service sınıfı aracılığıyla, sub keyi aracılığıyla
        // Token'ı yakalayacağız ve o token içindeki ID' yi alıp bunu sepetle ilişkilendireceğiz
        public string GetUserId => _contextAccessor.HttpContext.User.FindFirst("sub").Value;
    }
}
