using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using HourRegistration.DataAccess.Models;
using HourRegistration.DataAccess.Repositories;

namespace HourRegistration.API
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

        [HttpPost]
        
        public async Task<ActionResult<User>> CreateAsync(string name, string password)
        {
            _logger.LogDebug("Create User");
            var user = await _repository.CreateAsync(name, password);

            return user;
        }
    }


}