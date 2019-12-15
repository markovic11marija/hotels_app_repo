using HotelsReviewApp.Domain.Model.Core;
using MediatR;

namespace HotelsReviewApp.Domain.Service.Favorites.RemoveHotelFromFavorites
{
   public class RemoveHotelFromFavoritesCommand : IRequest<CommandResult<CommandEmptyResult>>
    {
        public int UserId { get; }
        public int HotelId { get; }

        public RemoveHotelFromFavoritesCommand(int userId, int hotelId)
        {
            UserId = userId;
            HotelId = hotelId;
        }
    }
}
