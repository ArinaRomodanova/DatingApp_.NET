using DatingApp.Dal.Models;
using DatingApp.Dal.Models.Base;
using DatingApp.Dal.Repos;
using DatingApp.Dal.Repos.Base;
using DatingApp.Dal.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatingApp.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : BaseCrudController<User, UserController>
    {
        public UserController(IUserRepo userRepo): base(userRepo) 
        {
            
        }

        /// <summary>
        /// Return all users in DB
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<User>> GetALl() 
        {
            return Ok(MainRepo.GetAll());
        }

    }
}
