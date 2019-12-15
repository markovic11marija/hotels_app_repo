using System.Collections.Generic;
using System.Threading.Tasks;
using HotelsReviewApp.Domain.Model;
using HotelsReviewApp.Domain.Model.Core;
using HotelsReviewApp.Domain.Service;
using HotelsReviewApp.Domain.Service.Hotels.AddHotel;
using HotelsReviewApp.Domain.Service.Hotels.EditHotelDetails;
using HotelsReviewApp.Domain.Service.Hotels.Filters;
using HotelsReviewApp.Domain.Service.Hotels.GetHotels;
using HotelsReviewApp.Domain.Service.Hotels.SearchHotel;
using HotelsReviewApp.Domain.Service.Hotels.ViewHotelDetails;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> Get(int id)
        {
            return Ok(await _mediator.Send(new ViewHotelDetailsQuery(id)));
        }

        [HttpGet]
        [Route("search")]
        public async Task<ActionResult<IEnumerable<Hotel>>> Search(string name, string city)
        {
            return Ok(await _mediator.Send(new SearchHotelQuery(name, city)));
        }

        [HttpPost("{userId}")]
        [UserHasAdminRightsFilter]
        public async Task<ActionResult<CommandResult<CommandEmptyResult>>> Add(int userId, [FromBody]AddHotelCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsSuccess)
                return Ok(result.Payload);

            return BadRequest(result.FailureReason);
        }

        [HttpPut("{userId}/edit/{id}")]
        [UserHasAdminRightsFilter]
        public async Task<ActionResult<CommandResult<CommandEmptyResult>>> Edit(int userId, int id, [FromBody]EditHotelDetailsCommand command)
        {
            var request = command;
            request.HotelId = id;
            var result = await _mediator.Send(request);

            if (result.IsSuccess)
                return Ok(result.Payload);

            return BadRequest(result.FailureReason);
        }
    }
}