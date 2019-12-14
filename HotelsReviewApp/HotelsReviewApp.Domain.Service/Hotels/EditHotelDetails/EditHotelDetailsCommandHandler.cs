using System.Threading;
using System.Threading.Tasks;
using HotelsReviewApp.Domain.Model;
using HotelsReviewApp.Domain.Model.Core;
using HotelsReviewApp.Infrastructure.Data;
using MediatR;

namespace HotelsReviewApp.Domain.Service.Hotels.EditHotelDetails
{
  public  class EditHotelDetailsCommandHandler : IRequestHandler<EditHotelDetailsCommand, CommandResult<CommandEmptyResult>>
    {
        private readonly IRepository<Hotel> _hotelRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EditHotelDetailsCommandHandler(IRepository<Hotel> hotelRepository, IUnitOfWork unitOfWork)
        {
            _hotelRepository = hotelRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<CommandResult<CommandEmptyResult>> Handle(EditHotelDetailsCommand request, CancellationToken cancellationToken)
        {
            var hotel = _hotelRepository.FindById(request.HotelId);
            hotel.UpdateFrom(request.Name, request.Address, request.Image, request.Description, request.GeoLocation);
            _unitOfWork.SaveChanges();
            return Task.FromResult(CommandResult<CommandEmptyResult>.Success(new CommandEmptyResult()));
        }
    }
}
