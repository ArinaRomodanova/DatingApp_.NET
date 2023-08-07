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

    }
}
