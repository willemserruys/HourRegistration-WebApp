using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiSample.DataAccess.Models;
using WebApiSample.DataAccess.Repositories;

namespace WebApiSample.Api._21.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _repository;
        private readonly ILogger _logger;

            public UserController(UserRepository repository, ILogger<UserController> logger)
            {
                _repository = repository;
            _logger = logger;
            } 

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllAsync()
        {
            _logger.LogDebug("Getting All Users");
            var users = await _repository.GetUsersAsync();

            return users;
        }
    }
}