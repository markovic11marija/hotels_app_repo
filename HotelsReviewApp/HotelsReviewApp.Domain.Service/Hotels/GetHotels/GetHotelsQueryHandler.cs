using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HotelsReviewApp.Domain.Model;
using HotelsReviewApp.Infrastructure.Data;
using MediatR;

namespace HotelsReviewApp.Domain.Service.Hotels.GetHotels
{
  public class GetHotelsQueryHandler : IRequestHandler<GetHotelsQuery, IEnumerable<Hotel>>
    {
        private readonly IRepository<Hotel> _hotelRepository;

        public GetHotelsQueryHandler(IRepository<Hotel> hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
     
        public async Task<IEnumerable<Hotel>> Handle(GetHotelsQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_hotelRepository.QueryAll().OrderBy(h => h.Name));
        }
    }
}
