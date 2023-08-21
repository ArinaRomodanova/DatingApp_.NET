using DatingApp.Dal.Models;
using DatingApp.Dal.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text.Json;
using System.IO;
using System.Web;

namespace DatingApp.Mvc.Controllers
{
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IUserRepo _repo;
        private readonly IAccountRepo _accountRepo;
        private readonly IPhotoRepo _photoRepo;

        public UserController(IUserRepo repo, IAccountRepo accountRepo, IPhotoRepo photoRepo)
        {
            _repo = repo;
            _accountRepo = accountRepo;
            _photoRepo = photoRepo;
        }

        internal User GetUserByLogin(string login)
        {
            return _repo.GetUserByLogin(login);
        }

        internal User GetUserById(int id)
        {
            return _repo.Find(id);
        }

        public IActionResult Index()
        {
            byte[] data = null;
            
            if (HttpContext.Session.TryGetValue("CurrentUserId", out data) == false)
            {
                return View();
            }
            int? userId = HttpContext.Session.GetInt32("CurrentUserId");
            var user = GetUserById((int)userId);
            var account = _accountRepo.Find(user.AccountId);
            return View("Success", account);
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
                HttpContext.Session.SetInt32("CurrentUserId", checkUser.Id);
                var account = _accountRepo.Find(checkUser.AccountId);
                return View("Success", account);
            }
            ViewBag.IsCorrectSignInData = false;
            return View(nameof(Index));
        }

        [HttpGet]
        public IActionResult Exit()
        {
            HttpContext.Session.Remove("CurrentUserId");
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult ChangePhoto(IFormFile uploadImage)
        {
            byte[] imageData = null;
            using (var binReader = new BinaryReader(uploadImage.OpenReadStream()))
            {
                imageData = binReader.ReadBytes((int)uploadImage.Length);
            }
            var userId = HttpContext.Session.GetInt32("CurrentUserId");
            var user = GetUserById((int)userId);
            Photo avatar = new Photo { AccountId = user.AccountId, Avatar = imageData };
            _photoRepo.Add(avatar);
            return RedirectToAction(nameof(Index));
        }
    }
}
