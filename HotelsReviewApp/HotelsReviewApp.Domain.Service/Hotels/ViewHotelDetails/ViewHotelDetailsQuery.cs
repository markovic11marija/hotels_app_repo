using HotelsReviewApp.Domain.Model;
using MediatR;

namespace HotelsReviewApp.Domain.Service.Hotels.ViewHotelDetails
{
  public class ViewHotelDetailsQuery : IRequest<Hotel>
    {
        public int HotelId { get; }

        public ViewHotelDetailsQuery(int hotelId)
        {
            HotelId = hotelId;
        }
    }
}
