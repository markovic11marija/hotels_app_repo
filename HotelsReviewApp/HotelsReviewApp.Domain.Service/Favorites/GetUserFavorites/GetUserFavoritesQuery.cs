using System.Collections.Generic;
using HotelsReviewApp.Domain.Service.Favorites.GetUserFavorites.Dtos;
using MediatR;

namespace HotelsReviewApp.Domain.Service.Favorites.GetUserFavorites
{
    public class GetUserFavoritesQuery : IRequest<IEnumerable<FavoriteHotelModel>>
    {
        public int UserId { get; set; }

        public GetUserFavoritesQuery(int userId)
        {
            UserId = userId;
        }
    }
}
