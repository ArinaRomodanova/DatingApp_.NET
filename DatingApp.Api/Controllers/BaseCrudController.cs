using DatingApp.Dal.Models.Base;
using DatingApp.Dal.Repos.Base;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Api.Controllers
{
    public class BaseCrudController<TEntity, TController> : ControllerBase where TEntity : BaseModel, new() where TController : class
    {
        protected readonly IRepo<TEntity> MainRepo;
        
        protected BaseCrudController(IRepo<TEntity> repo)
        {
            MainRepo = repo;
        }

    }
}
