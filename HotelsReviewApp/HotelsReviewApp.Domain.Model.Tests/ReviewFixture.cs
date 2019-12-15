using System.Collections.Generic;
using FluentAssertions;
using Xunit;


namespace HotelsReviewApp.Domain.Model.Tests
{
  public  class ReviewFixture
    {
        [Fact]
        public void Review_CalculateRating()
        {
            var hotel = new Hotel("name1", new Address(), new Image(), "desc 1", new GeoLocation());
            var user1 = new User("nsas@gmail.com", "sasa", "sasas", false);
            var user2 = new User("hdsauiuisd@gmail.com", "jjkdsa", "jkdsakk", false);
            var user3 = new User("jalaA@gmail.com", "dsasdas", "sdasaa", false);

            var review = new Review(new User("mail@gmail.com", "displ", "passs", false), hotel, "descript", HotelRating.FourStars);
           
            var reactions = new List<UserReviewReaction>()
            {
                new UserReviewReaction(review, user1, ReactionType.Like),
                new UserReviewReaction(review, user2, ReactionType.Like),
                new UserReviewReaction(review, user3, ReactionType.Dislike)
            };

            review.UserReactions = reactions;

            review.CalculateRatingFromReview().Should().Be(4.0);
        }
    }
}
