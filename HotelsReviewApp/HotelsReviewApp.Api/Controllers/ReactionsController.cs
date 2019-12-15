using System.Threading.Tasks;
using HotelsReviewApp.Domain.Model;
using HotelsReviewApp.Domain.Model.Core;
using HotelsReviewApp.Domain.Service;
using HotelsReviewApp.Domain.Service.Reactions.ReactToHotelReview;
using HotelsReviewApp.Domain.Service.Reactions.RemoveReactionToHotelReview;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelsReviewApp.Api.Controllers
{
    [Route("[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ReactionsController : Controller
    {
        private readonly IMediator _mediator;

        public ReactionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut("{userId}/liked/{reviewId}")]
        public async Task<ActionResult<CommandResult<CommandEmptyResult>>> Like(int userId, int reviewId)
        {
            var result = await _mediator.Send(new ReactToHotelReviewCommand(userId, reviewId, ReactionType.Like));

            if (result.IsSuccess)
                return Ok(result.Payload);

            return BadRequest(result.FailureReason);
        }

        [HttpPut("{userId}/dislike/{reviewId}")]
        public async Task<ActionResult<CommandResult<CommandEmptyResult>>> Dislike(int userId, int reviewId)
        {
            var result = await _mediator.Send(new ReactToHotelReviewCommand(userId, reviewId, ReactionType.Dislike));

            if (result.IsSuccess)
                return Ok(result.Payload);

            return BadRequest(result.FailureReason);
        }


        [HttpDelete("{userId}/remove-like/{reviewId}")]
        public async Task<ActionResult<CommandResult<CommandEmptyResult>>> RemoveLike(int userId, int reviewId)
        {
            var result = await _mediator.Send(new RemoveReactionToHotelReviewCommand(userId, reviewId, ReactionType.Dislike));

            if (result.IsSuccess)
                return Ok(result.Payload);

            return BadRequest(result.FailureReason);
        }

        [HttpDelete("{userId}/remove-dislike/{reviewId}")]
        public async Task<ActionResult<CommandResult<CommandEmptyResult>>> RemoveDislike(int userId, int reviewId)
        {
            var result = await _mediator.Send(new RemoveReactionToHotelReviewCommand(userId, reviewId, ReactionType.Dislike));

            if (result.IsSuccess)
                return Ok(result.Payload);

            return BadRequest(result.FailureReason);
        }
    }
}