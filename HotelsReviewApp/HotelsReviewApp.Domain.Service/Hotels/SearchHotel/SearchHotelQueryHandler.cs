using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HotelsReviewApp.Domain.Model;
using HotelsReviewApp.Domain.Model.Extensions;
using HotelsReviewApp.Infrastructure.Data;
using MediatR;

namespace HotelsReviewApp.Domain.Service.Hotels.SearchHotel
{
  public  class SearchHotelQueryHandler : IRequestHandler<SearchHotelQuery, IEnumerable<Hotel>>
    {
        private readonly IRepository<Hotel> _hotelRepository;

        public SearchHotelQueryHandler(IRepository<Hotel> hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<IEnumerable<Hotel>> Handle(SearchHotelQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_hotelRepository.QueryAll().SearchBy(request.Name, request.City));
        }
    }
}
