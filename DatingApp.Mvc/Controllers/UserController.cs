using DatingApp.Dal.Models;
using DatingApp.Dal.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Mvc.Controllers
{
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IUserRepo _repo;

        public UserController(IUserRepo repo)
        {
            _repo = repo;
        }

        internal User GetUserByLogin(string login)
        {
            return _repo.GetUserByLogin(login);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Autorization(User user)
        {
            var checkUser = GetUserByLogin(user.Login);
            if (checkUser == null)
            {
                return View(nameof(Index));
            }
            if (checkUser.Password == user.Password)
            {
                return View("Success", checkUser);
            }
            ViewBag.IsCorrectData = false;
            return View(nameof(Index));
        }
    }
}
