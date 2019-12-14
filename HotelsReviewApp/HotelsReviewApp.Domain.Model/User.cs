using System.Collections;
using System.Collections.Generic;

namespace HotelsReviewApp.Domain.Model
{
   public class User
    {
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public bool IsAdministrator { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
        public IEnumerable<Hotel> FavouriteHotels { get; set; }
    }
}
