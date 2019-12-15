using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HotelsReviewApp.Domain.Model;
using HotelsReviewApp.Domain.Model.Core;
using HotelsReviewApp.Infrastructure.Data;
using MediatR;

namespace HotelsReviewApp.Domain.Service.Favorites.AddHotelToFavorites
{
    public   class AddHotelToFavoritesCommandHandler: IRequestHandler<AddHotelToFavoritesCommand, CommandResult<CommandEmptyResult>>
 {
     private readonly IRepository<User> _userRepository;
     private readonly IRepository<Hotel> _hotelRepository;
     private readonly IUnitOfWork _unitOfWork;

     public AddHotelToFavoritesCommandHandler(IRepository<User> userRepository, IRepository<Hotel> hotelRepository, IUnitOfWork unitOfWork)
     {
         _userRepository = userRepository;
         _hotelRepository = hotelRepository;
         _unitOfWork = unitOfWork;
     }

     public Task<CommandResult<CommandEmptyResult>> Handle(AddHotelToFavoritesCommand request, CancellationToken cancellationToken)
        {
            var user = _userRepository.QueryAllIncluding(u => u.FavoriteHotels).SingleOrDefault(u => u.Id == request.UserId);
            var hotel = _hotelRepository.FindById(request.HotelId);
            if (user == null || hotel == null)
                return Task.FromResult(CommandResult<CommandEmptyResult>.Fail("Fail to add hotel to favorites."));

            if (user.FavoriteHotels.Any(r => r.HotelId == request.HotelId))
                return Task.FromResult(CommandResult<CommandEmptyResult>.Fail("Hotel already added to favorites."));

            user.AddHotelToFavorites(new UserFavoriteHotel(user, hotel));
            _unitOfWork.SaveChanges();
            return Task.FromResult(CommandResult<CommandEmptyResult>.Success(new CommandEmptyResult()));
        }
    }
}
