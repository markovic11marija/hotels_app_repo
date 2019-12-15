using System.Collections.Generic;
using System.Threading.Tasks;
using HotelsReviewApp.Domain.Model;
using HotelsReviewApp.Domain.Model.Core;
using HotelsReviewApp.Domain.Service;
using HotelsReviewApp.Domain.Service.Reviews.CreateHotelReview;
using HotelsReviewApp.Domain.Service.Reviews.GetReviewsForHotel;
using HotelsReviewApp.Domain.Service.Reviews.GetUsersWithReviewReactions;
using HotelsReviewApp.Domain.Service.Reviews.GetUsersWithReviewReactions.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelsReviewApp.Api.Controllers
{
    [Route("[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ReviewsController : Controller
    {
        private readonly IMediator _mediator;

        public ReviewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("{userId}/create-review/{hotelId}")]
        public async Task<ActionResult<CommandResult<CommandEmptyResult>>> Add(int userId, int hotelId, [FromBody]CreateHotelReviewCommand command)
        {
            var request = command;
            request.UserId = userId;
            request.HotelId = hotelId;

            var result = await _mediator.Send(request);

            if (result.IsSuccess)
                return Ok(result.Payload);

            return BadRequest(result.FailureReason);
        }

        [HttpGet("for-hotel/{hotelId}")]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviewsFor(int hotelId)
        {
            return Ok(await _mediator.Send(new GetReviewsForHotelQuery(hotelId)));
        }

        [HttpGet("{reviewId}/liked-by")]
        public async Task<ActionResult<IEnumerable<UserWithReactionModel>>> ReviewLikedBy(int reviewId)
        {
            return Ok(await _mediator.Send(new GetUsersWithReviewReactionsQuery(reviewId, ReactionType.Like)));
        }

        [HttpGet("{reviewId}/disliked-by")]
        public async Task<ActionResult<IEnumerable<UserWithReactionModel>>> ReviewDislikedBy(int reviewId)
        {
            return Ok(await _mediator.Send(new GetUsersWithReviewReactionsQuery(reviewId, ReactionType.Dislike)));
        }
    }
}