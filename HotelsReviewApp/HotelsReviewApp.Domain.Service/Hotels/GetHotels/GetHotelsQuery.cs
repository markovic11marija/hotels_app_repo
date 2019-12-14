using System.Collections.Generic;
using HotelsReviewApp.Domain.Model;
using MediatR;

namespace HotelsReviewApp.Domain.Service.Hotels.GetHotels
{
    public class GetHotelsQuery : IRequest<IEnumerable<Hotel>>
    {
    }
}
