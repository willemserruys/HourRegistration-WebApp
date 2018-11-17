using Microsoft.AspNetCore.Mvc;
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

            public UserController(UserRepository repository)
            {
                _repository = repository;
            }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllAsync()
        {
            var users = await _repository.GetUsersAsync();

            return users;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Product>> GetByIdAsync(int id)
        {
            var user = await _repository.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }
    }
}