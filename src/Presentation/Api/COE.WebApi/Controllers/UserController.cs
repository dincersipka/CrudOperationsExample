using COE.Application.Features.Commands.UserFeatures.Create;
using COE.Application.Features.Commands.UserFeatures.Delete;
using COE.Application.Features.Commands.UserFeatures.Update;
using COE.Application.Features.Queries.UserFeatures.UserGetAll;
using COE.Application.Features.Queries.UserFeatures.UserGetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace COE.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public UserController(IMediator Mediator)
        {
            _Mediator = Mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _Mediator.Send(new UserGetAllQueryRequest()));
        }

        [HttpGet("{Id:Guid}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            return Ok(await _Mediator.Send(new UserGetByIdQueryRequest() { Id = Id }));
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateCommandRequest Request)
        {
            return Ok(await _Mediator.Send(Request));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserUpdateCommandRequest Request)
        {
            return Ok(await _Mediator.Send(Request));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(UserDeleteCommandRequest Request)
        {
            return Ok(await _Mediator.Send(Request));
        }
    }
}
