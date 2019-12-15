using System.Threading.Tasks;
using HotelsReviewApp.Domain.Model;
using HotelsReviewApp.Domain.Model.Core;
using HotelsReviewApp.Domain.Service;
using HotelsReviewApp.Domain.Service.Users.SignIn;
using HotelsReviewApp.Domain.Service.Users.SignUpRegularUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelsReviewApp.Api.Controllers
{
    [Route("[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class AccountsController : Controller
    {
        private readonly IMediator _mediator;

        public AccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("sign-up")]
        public async Task<ActionResult<CommandResult<CommandEmptyResult>>> SignUp([FromBody]SignUpRegularUserCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsSuccess)
                return Ok(result.Payload);

            return BadRequest(result.FailureReason);
        }

        [HttpGet]
        [Route("sign-in")]
        public async Task<ActionResult<User>> Search(string email, string password)
        {
            return Ok(await _mediator.Send(new SignInQuery(email, password)));
        }
    }
}