using System.Collections.Generic;
using HotelsReviewApp.Domain.Model;
using MediatR;

namespace HotelsReviewApp.Domain.Service.Hotels.SearchHotel
{
    public class SearchHotelQuery : IRequest<IEnumerable<Hotel>>
    {
        public string Name { get; }
        public string City { get; }

        public SearchHotelQuery(string name, string city)
        {
            Name = name;
            City = city;
        }
    }
}
