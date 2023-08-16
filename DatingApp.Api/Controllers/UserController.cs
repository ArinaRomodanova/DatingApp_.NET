using DatingApp.Dal.Models;
using DatingApp.Dal.Models.Base;
using DatingApp.Dal.Repos;
using DatingApp.Dal.Repos.Base;
using DatingApp.Dal.Repos.Interfaces;
using DatingApp.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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

        [HttpGet("[controller]/[action]/{login?}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [SwaggerResponse(200, "The execution was successful")]
        [SwaggerResponse(400, "The execution was failed")]
        public ActionResult GetUserByLogin(string? login)
        {
            if (!login.IsNullOrEmpty())
            {
                return Ok(((IUserRepo)MainRepo).GetUserByLogin(login));
            }
            Logger.LogAppError($"Invalid request to table");
            return BadRequest();
        }
    }
}
