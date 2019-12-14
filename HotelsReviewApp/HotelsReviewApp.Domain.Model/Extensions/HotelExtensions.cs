using System.Collections.Generic;
using System.Linq;

namespace HotelsReviewApp.Domain.Model.Extensions
{
    public static class HotelExtensions
    {
        public static IEnumerable<Hotel> SearchBy(this IEnumerable<Hotel> query, string name, string city)
        {
           return query.Where(h => (string.IsNullOrEmpty(name) || h.Name == name) &&
                                   (string.IsNullOrEmpty(city) || h.Address?.City == city));
        }
    }
}
