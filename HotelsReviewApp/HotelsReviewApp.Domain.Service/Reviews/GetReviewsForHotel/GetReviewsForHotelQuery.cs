using System.Collections.Generic;
using HotelsReviewApp.Domain.Model;
using MediatR;

namespace HotelsReviewApp.Domain.Service.Reviews.GetReviewsForHotel
{
    public class GetReviewsForHotelQuery : IRequest<IEnumerable<Review>>
    {
        public int HotelId { get; }

        public GetReviewsForHotelQuery(int hotelId)
        {
            HotelId = hotelId;
        }
    }
}
