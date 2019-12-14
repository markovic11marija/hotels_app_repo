using System.Threading;
using System.Threading.Tasks;
using HotelsReviewApp.Domain.Model;
using HotelsReviewApp.Domain.Model.Core;
using HotelsReviewApp.Infrastructure.Data;
using MediatR;

namespace HotelsReviewApp.Domain.Service.Hotels.AddHotel
{
    public class AddHotelCommandHandler : IRequestHandler<AddHotelCommand, CommandResult<CommandEmptyResult>>
    {
        private readonly IRepository<Hotel> _hotelRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddHotelCommandHandler(IRepository<Hotel> hotelRepository, IUnitOfWork unitOfWork)
        {
            _hotelRepository = hotelRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<CommandResult<CommandEmptyResult>> Handle(AddHotelCommand request, CancellationToken cancellationToken)
        {
            var hotel = new Hotel(request.Name, request.Address, request.Image, request.Description, request.GeoLocation);
            _hotelRepository.Add(hotel);
            _unitOfWork.SaveChanges();

            return Task.FromResult(CommandResult<CommandEmptyResult>.Success(new CommandEmptyResult()));
        }
    }
}
