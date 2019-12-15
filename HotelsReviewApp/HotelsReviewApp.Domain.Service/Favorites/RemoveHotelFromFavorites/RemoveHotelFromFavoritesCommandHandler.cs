using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HotelsReviewApp.Domain.Model;
using HotelsReviewApp.Domain.Model.Core;
using HotelsReviewApp.Infrastructure.Data;
using MediatR;

namespace HotelsReviewApp.Domain.Service.Favorites.RemoveHotelFromFavorites
{
  public  class RemoveHotelFromFavoritesCommandHandler : IRequestHandler<RemoveHotelFromFavoritesCommand, CommandResult<CommandEmptyResult>>
    {
        private readonly IRepository<User> _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveHotelFromFavoritesCommandHandler(IRepository<User> userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<CommandResult<CommandEmptyResult>> Handle(RemoveHotelFromFavoritesCommand request, CancellationToken cancellationToken)
        {
            var user = _userRepository.QueryAllIncluding(u => u.FavoriteHotels).SingleOrDefault(u => u.Id == request.UserId);
            var favorite = user?.FavoriteHotels.SingleOrDefault(f => f.HotelId == request.HotelId);
            if (user != null && favorite != null)
            {
                user.RemoveHotelFromFavorites(favorite);
                _unitOfWork.SaveChanges();
                return Task.FromResult(CommandResult<CommandEmptyResult>.Success(new CommandEmptyResult()));
            }

            return Task.FromResult(CommandResult<CommandEmptyResult>.Fail("Fail to remove hotel from favorites."));
        }
    }
}