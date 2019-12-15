using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HotelsReviewApp.Domain.Model;
using HotelsReviewApp.Infrastructure.Data;
using MediatR;

namespace HotelsReviewApp.Domain.Service.Reviews.GetReviewsForHotel
{
    public class GetReviewsForHotelQueryHandler : IRequestHandler<GetReviewsForHotelQuery, IEnumerable<Review>>
    {
        private readonly IRepository<Review> _reviewRepository;

        public GetReviewsForHotelQueryHandler(IRepository<Review> reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<IEnumerable<Review>> Handle(GetReviewsForHotelQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_reviewRepository.QueryAll().Where(r => r.ReviewedHotel.Id == request.HotelId));
        }
    }
}
