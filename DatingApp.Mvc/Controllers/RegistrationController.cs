using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Mvc.Controllers
{
    [Route("[controller]/[action]")]
    public class RegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
