using System.Collections.Generic;
using System.Threading.Tasks;
using HotelsReviewApp.Domain.Model;
using HotelsReviewApp.Domain.Service.Hotels.GetHotels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelsReviewApp.Api.Controllers
{
    [Route("[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class HotelsController : Controller
    {
        private readonly IMediator _mediator;

        public HotelsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetAll()
        {
            return Ok(await _mediator.Send(new GetHotelsQuery()));
        }
    }
}