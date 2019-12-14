using System.Collections.Generic;
using System.Linq;

namespace HotelsReviewApp.Domain.Model
{
    public class Review : Entity
    {
        public string Description { get; set; }
        public Hotel ReviewedHotel { get; set; }
        public User ReviewAuthor { get; set; }
        public HotelRating HotelRating { get; set; }
        public IEnumerable<UserReviewReaction> UserReactions { get; set; }

        public Review()
        {
            UserReactions = new List<UserReviewReaction>();
        }

        public double CalculateRatingFromReview()
        {
            var reactionsRating = UserReactions.Any()
                ? UserReactions.Sum(u => u.GetPointsForOverallRating()) / UserReactions.Count()
                : 0;
            return (int)HotelRating + reactionsRating;
        }
    }
}
