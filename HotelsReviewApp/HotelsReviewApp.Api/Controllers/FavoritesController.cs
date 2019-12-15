using System.Collections.Generic;
using System.Threading.Tasks;
using HotelsReviewApp.Domain.Model.Core;
using HotelsReviewApp.Domain.Service;
using HotelsReviewApp.Domain.Service.Favorites.AddHotelToFavorites;
using HotelsReviewApp.Domain.Service.Favorites.GetUserFavorites;
using HotelsReviewApp.Domain.Service.Favorites.GetUserFavorites.Dtos;
using HotelsReviewApp.Domain.Service.Favorites.RemoveHotelFromFavorites;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelsReviewApp.Api.Controllers
{
    [Route("[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FavoritesController : Controller
    {
        private readonly IMediator _mediator;

        public FavoritesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("{userId}/add-to-favorite/{hotelId}")]
        public async Task<ActionResult<CommandResult<CommandEmptyResult>>> AddToFavorite(int userId, int hotelId)
        {
            var result = await _mediator.Send(new AddHotelToFavoritesCommand(userId, hotelId));

            if (result.IsSuccess)
                return Ok(result.Payload);

            return BadRequest(result.FailureReason);
        }

        [HttpDelete]
        [Route("{userId}/remove-from-favorites/{hotelId}")]
        public async Task<ActionResult<CommandResult<CommandEmptyResult>>> RemoveFromFavorite(int userId, int hotelId)
        {
            var result = await _mediator.Send(new RemoveHotelFromFavoritesCommand(userId, hotelId));

            if (result.IsSuccess)
                return Ok(result.Payload);

            return BadRequest(result.FailureReason);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<FavoriteHotelModel>>> GetAllForUser(int userId)
        {
            return Ok(await _mediator.Send(new GetUserFavoritesQuery(userId)));
        }
    }
}