using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleApi.Controllers.Resources;
using SimpleApi.Domain.Commands.Users;
using SimpleApi.Domain.Communication;
using SimpleApi.Domain.Models;
using SimpleApi.Domain.Queries.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SimpleApi.Controllers
{
    [Route("api/users")]
    [Produces("application/json")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _mediator.Send(new ListUsersQuery());
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(User), 200)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var user = await _mediator.Send(new GetUserQuery(id));
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(typeof(User), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] UserResource resource)
        {
            var user = await _mediator.Send(new CreateUserCommand(resource.Name, resource.Age));
            return Created($"/api/users/{user.Id}", user);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Response<User>), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UserResource resource)
        {
            var response = await _mediator.Send(new UpdateUserCommand(id, resource.Name, resource.Age));
            return ProduceUserResponse(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Response<User>), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var response = await _mediator.Send(new DeleteUserCommand(id));
            return ProduceUserResponse(response);
        }

        private IActionResult ProduceUserResponse(Response<User> response)
        {
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.Data);
        }
    }
}