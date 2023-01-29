using CQRS_Mediator_EF_Api.CQRS.Commands.Users;
using CQRS_Mediator_EF_Api.CQRS.Queries.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Mediator_EF_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand command) => Ok(await _mediator.Send(command));

        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserCommand command) => Ok(await _mediator.Send(command));

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _mediator.Send(new GetAllUserQuery()));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _mediator.Send(new GetUserByIdQuery { Id = id}));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _mediator.Send(new DeleteUserByIdCommand { Id = id }));
    }
}
