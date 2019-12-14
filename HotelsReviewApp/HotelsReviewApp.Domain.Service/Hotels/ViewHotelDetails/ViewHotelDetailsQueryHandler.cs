using System.Threading;
using System.Threading.Tasks;
using HotelsReviewApp.Domain.Model;
using HotelsReviewApp.Infrastructure.Data;
using MediatR;

namespace HotelsReviewApp.Domain.Service.Hotels.ViewHotelDetails
{
   public class ViewHotelDetailsQueryHandler : IRequestHandler<ViewHotelDetailsQuery, Hotel>
    {
        private readonly IRepository<Hotel> _hotelRepository;

        public ViewHotelDetailsQueryHandler(IRepository<Hotel> hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<Hotel> Handle(ViewHotelDetailsQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_hotelRepository.FindById(request.HotelId));
        }
    }
}
