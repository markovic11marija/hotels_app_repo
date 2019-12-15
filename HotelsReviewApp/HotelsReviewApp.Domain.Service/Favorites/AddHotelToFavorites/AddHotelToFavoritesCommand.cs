using HotelsReviewApp.Domain.Model.Core;
using MediatR;

namespace HotelsReviewApp.Domain.Service.Favorites.AddHotelToFavorites
{
    public class AddHotelToFavoritesCommand : IRequest<CommandResult<CommandEmptyResult>>
    {
        public int UserId { get; }
        public int HotelId { get; }

        public AddHotelToFavoritesCommand(int userId, int hotelId)
        {
            UserId = userId;
            HotelId = hotelId;
        }
    }
}
