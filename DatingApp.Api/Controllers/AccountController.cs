using Azure.Core;
using DatingApp.Dal.Models;
using DatingApp.Dal.Repos.Base;
using DatingApp.Dal.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;

namespace DatingApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : BaseCrudController<Account, AccountController>
    {
        public AccountController(IAccountRepo repo) : base(repo)
        {
        }

        



        [HttpPut("[controller]/[action]/{id?}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [SwaggerResponse(200, "The execution was successful")]
        [SwaggerResponse(400, "The execution was failed")]
        public ActionResult<Account> UpdateAccount(int? id, Account entity)
        {
            if (id.HasValue && id.Value == entity.Id)
            {
                MainRepo.Update(entity);
                return Ok(entity);
            }
            return BadRequest();
        }

        [HttpDelete("[controller]/[action]/{id?}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [SwaggerResponse(200, "The execution was successful")]
        [SwaggerResponse(400, "The execution was failed")]
        public ActionResult DeleteAccount(int? id, Account account)
        {
            if (id.HasValue && id.Value == account.Id)
            {
                MainRepo.Delete(account);
                return Ok();
            }
            return BadRequest();
        }
    }
}
