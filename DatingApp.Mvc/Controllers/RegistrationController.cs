using DatingApp.Dal.Models;
using DatingApp.Dal.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DatingApp.Mvc.Controllers
{
    [Route("[controller]/[action]")]
    public class RegistrationController : Controller
    {
        private readonly IAccountRepo _accountRepo;
        private readonly IUserRepo _userRepo;

        public RegistrationController(IAccountRepo accountRepo, IUserRepo userRepo)
        {
            _accountRepo = accountRepo;
            _userRepo = userRepo; 
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NextRegStep(Account account)
        {
            TempData["AccountInfo"] = JsonSerializer.Serialize(account);
            return View("IndexUserSave");
        }

        public IActionResult Registrate(User user)
        {
            var accountInfo = JsonSerializer.Deserialize<Account>((string)TempData["AccountInfo"]);
            _accountRepo.Add(accountInfo);
            user.AccountId = accountInfo.Id;
            _userRepo.Add(user);
            return RedirectToAction("Index", "User");
        }
    }
}
