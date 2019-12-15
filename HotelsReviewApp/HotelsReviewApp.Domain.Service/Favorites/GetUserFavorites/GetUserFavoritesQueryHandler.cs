using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HotelsReviewApp.Domain.Model;
using HotelsReviewApp.Domain.Service.Favorites.GetUserFavorites.Dtos;
using HotelsReviewApp.Domain.Service.Reviews.GetUsersWithReviewReactions.Dtos;
using HotelsReviewApp.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HotelsReviewApp.Domain.Service.Favorites.GetUserFavorites
{
  public  class GetUserFavoritesQueryHandler:IRequestHandler<GetUserFavoritesQuery, IEnumerable<FavoriteHotelModel>>
  {
      private readonly IRepository<User> _userRepository;

      public GetUserFavoritesQueryHandler(IRepository<User> userRepository)
      {
          _userRepository = userRepository;
      }

      public async Task<IEnumerable<FavoriteHotelModel>> Handle(GetUserFavoritesQuery request, CancellationToken cancellationToken)
        {
            var result = _userRepository.QueryAll().Include(u => u.FavoriteHotels)
                .ThenInclude(r => r.Hotel)
                .FirstOrDefault(o => o.Id == request.UserId)?
                .FavoriteHotels?
                .Select(re => new FavoriteHotelModel(re.Hotel.Name, re.Hotel.Description, re.Hotel.OverallRating))
                .ToList();
            return await Task.FromResult(result);
        }
    }
}
