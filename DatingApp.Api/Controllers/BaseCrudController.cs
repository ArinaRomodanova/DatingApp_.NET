using DatingApp.Dal.Models;
using DatingApp.Dal.Models.Base;
using DatingApp.Dal.Repos.Base;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;
using DatingApp.Logging;

namespace DatingApp.Api.Controllers
{
    public class BaseCrudController<TEntity, TController> : ControllerBase where TEntity : BaseModel, new() where TController : class
    {
        protected readonly IRepo<TEntity> MainRepo;
        protected readonly IAppLogger<TController> Logger;
        
        protected BaseCrudController(IRepo<TEntity> repo, IAppLogger<TController> logger)
        {
            MainRepo = repo;
            Logger = logger;
        }

        [HttpGet("[controller]/[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [SwaggerResponse(200, "The execution was successful")]
        [SwaggerResponse(400, "The execution was failed")]
        public ActionResult<IEnumerable<TEntity>> GetAll()
        {
            return Ok(MainRepo.GetAll());
        }

        [HttpGet("[controller]/[action]/{id?}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [SwaggerResponse(200, "The execution was successful")]
        [SwaggerResponse(400, "The execution was failed")]
        public ActionResult<TEntity> GetById(int? id)
        {
            if (id.HasValue && id.Value > 0)
            {
                return Ok(MainRepo.Find(id.Value));
            }
            Logger.LogAppError("Invalid request to table " +typeof(TEntity).Name);
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
        [HttpPost("[controller]/[action]")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [SwaggerResponse(201, "Account was created")]
        [SwaggerResponse(400, "The execution was failed")]
        public ActionResult<TEntity> Create(TEntity? entity)
        {
            if (entity == null)
            {
                Logger.LogAppError($"Value of entity {typeof(TEntity).Name} is NULL");
                return BadRequest();
            }
            MainRepo.Add(entity);
            return CreatedAtAction(nameof(GetById), new { Id = entity.Id }, entity);
        }

        [HttpPut("[controller]/[action]/{id?}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [SwaggerResponse(200, "The execution was successful")]
        [SwaggerResponse(400, "The execution was failed")]
        public ActionResult<TEntity> UpdateAccount(int? id, TEntity entity)
        {
            if (id.HasValue && id.Value == entity.Id)
            {
                MainRepo.Update(entity);
                return Ok(entity);
            }
            Logger.LogAppError($"Invalid request to table {typeof(TEntity).Name}");
            return BadRequest();
        }

        [HttpDelete("[controller]/[action]/{id?}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [SwaggerResponse(200, "The execution was successful")]
        [SwaggerResponse(400, "The execution was failed")]
        public ActionResult DeleteAccount(int? id, TEntity entity)
        {
            if (id.HasValue && id.Value == entity.Id)
            {
                MainRepo.Delete(entity);
                
                return Ok();
            }
            Logger.LogAppError($"Invalid request to table {typeof(TEntity).Name}");
            return BadRequest();
        }
    }
}
