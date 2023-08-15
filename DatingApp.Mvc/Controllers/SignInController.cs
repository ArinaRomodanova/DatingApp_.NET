using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Mvc.Controllers
{
    [Route("[controller]/[action]")]
    public class SignInController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
