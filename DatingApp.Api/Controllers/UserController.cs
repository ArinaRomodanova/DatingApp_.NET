using DatingApp.Dal.Models;
using DatingApp.Dal.Models.Base;
using DatingApp.Dal.Repos;
using DatingApp.Dal.Repos.Base;
using DatingApp.Dal.Repos.Interfaces;
using DatingApp.Logging;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseCrudController<User, UserController>
    {
        public UserController(IUserRepo userRepo, IAppLogger<UserController> logger): base(userRepo, logger) 
        {
            
        }
    }
}
