using System.Collections.Generic;

namespace HotelsReviewApp.Domain.Model
{
  public class Review
    {
        public string Description { get; set; }
        public Hotel ReviewedHotel { get; set; }
        public User ReviewAuthor { get; set; }
        public HotelRating HotelRating { get; set; }
        public IEnumerable<int> ListOfUserLikes { get; set; }
        public IEnumerable<int> ListOfUserDislikes { get; set; }
    }
}
