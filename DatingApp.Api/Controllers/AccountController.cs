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

        [HttpGet("[controller]/[action]", Name ="GetAllAccounts")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [SwaggerResponse(200, "The execution was successful")]
        [SwaggerResponse(400, "The execution was failed")]
        public ActionResult<IEnumerable<Account>> GetAllAccounts()
        {
            return Ok(MainRepo.GetAll());
        }

        [HttpGet("[controller]/[action]/{id?}", Name ="GetAccountById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [SwaggerResponse(200, "The execution was successful")]
        [SwaggerResponse(400, "The execution was failed")]
        public ActionResult<Account> GetAccountById(int? id)
        {
            if (id.HasValue && id.Value > 0)
            {
                return Ok(MainRepo.Find(id.Value));
            }
            return BadRequest();
        }

        /// <summary>
        /// Adds a single record
        /// <remarks>
        /// Sample body:
        /// <pre>
        /// {
        ///     "Id": 1,
        ///     "Name": "Arina",
        ///     "City": "Saint-P",
        ///     "Caption": "lalala",
        ///     "Age": 21
        /// }
        /// </pre>
        /// </remarks>
        /// </summary>
        /// <returns>A new record</returns>
        [HttpPost("[controller]/[action]", Name = "CreateAccount")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [SwaggerResponse(201, "Account was created")]
        [SwaggerResponse(400, "The execution was failed")]
        public ActionResult<Account> CreateAccount(Account? account)
        {
            if (account == null)
            {
                return BadRequest();
            }
            MainRepo.Add(account);
            return CreatedAtAction(nameof(GetAccountById), new {Id = account.Id}, account);
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
