using DatingApp.Dal.Models;
using DatingApp.Dal.Models.Base;
using DatingApp.Dal.Repos;
using DatingApp.Dal.Repos.Base;
using DatingApp.Dal.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseCrudController<User, UserController>
    {
        public UserController(IUserRepo userRepo): base(userRepo) 
        {
            
        }

        [HttpGet("[controller]/[action]", Name ="GetAllUsers")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [SwaggerResponse(200, "The execution was successful")]
        [SwaggerResponse(400, "The execution was failed")]
        public ActionResult<IEnumerable<User>> GetALlUsers() 
        {
            return Ok(MainRepo.GetAll());
        }

        [HttpGet("[controller]/[action]/{id?}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [SwaggerResponse(200, "The execution was successful")]
        [SwaggerResponse(400, "The execution was failed")]
        public ActionResult<User> GetUserById(int? id)
        {
            if (id.HasValue && id.Value > 0)
            {
                return Ok(MainRepo.Find(id.Value));
            }
            return BadRequest();
        }
    }
}
