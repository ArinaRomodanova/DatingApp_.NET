using DatingApp.Dal.Models;
using DatingApp.Dal.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Mvc.Controllers
{
    public class PhotoController : Controller
    {
        private readonly IPhotoRepo _photoRepo;
        public PhotoController(IPhotoRepo photoRepo)
        {
            _photoRepo = photoRepo;
        }

        internal Photo? GetProfilePhoto(int accountId)
        {
            return _photoRepo.GetPhotoByAccountId(accountId);
        }
        public IActionResult WatchPhoto(int photoId)
        {
            var photo = _photoRepo.Find(photoId);
            return View(photo);
        }

        public IActionResult ProfilePhoto([FromForm(Name = "photoId")] int photoId)
        {
            var photo = _photoRepo.Find(photoId);
            var prevProfilePhoto = GetProfilePhoto(photo.AccountId);
            if (prevProfilePhoto != null)
            {
                prevProfilePhoto.IsAnAvatar = false;
                _photoRepo.Update(prevProfilePhoto);
            }
            photo.IsAnAvatar = true;
            _photoRepo.Update(photo);
            return RedirectToAction("Index", "User");
        }
    }
}
