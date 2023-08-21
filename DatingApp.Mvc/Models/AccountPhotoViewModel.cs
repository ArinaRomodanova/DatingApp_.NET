namespace DatingApp.Mvc.Models
{
    public class AccountPhotoViewModel
    {
        string Name { get; set; }
        int Age { get; set; }
        string City { get; set; }
        string Caption { get; set; }
        IFormFile Avatar { get; set; }
    }
}
