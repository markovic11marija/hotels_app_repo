using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace HotelsReviewApp.Domain.Model.Tests
{
    public class HotelFixture
    {
        [Fact]
        public void UpdateHotel_Test()
        {
            var hotel = new Hotel("name1", new Address(), new Image(), "desc 1", new GeoLocation());
            hotel.UpdateFrom("name2", new Address{Street = "street1", HouseNumber = 12}, new Image(), "decription2", new GeoLocation());
            hotel.Address.Street.Should().Be("street1");
            hotel.Name.Should().Be("name2");
            hotel.Description.Should().Be("decription2");
            hotel.Image.Should().NotBe(null);
        }

        [Fact]
        public void UpdateHotel_WithNullsForObjects()
        {
            var hotel = new Hotel("name1", new Address(), new Image(), "desc 1", new GeoLocation());
            hotel.UpdateFrom("name2", null, null, "decription2", new GeoLocation());
            hotel.Address.Should().NotBe(null);
            hotel.Name.Should().Be("name2");
            hotel.Description.Should().Be("decription2");
            hotel.Image.Should().NotBe(null);
        }

        [Fact]
        public void Hotel_CalculateOverall()
        {
            var hotel = new Hotel("name1", new Address(), new Image(), "desc 1", new GeoLocation());

            var user1 = new User("nsas@gmail.com", "sasa", "sasas", false);
            var review1 = new Review(new User("mail@gmail.com", "displ", "passs", false), hotel, "descript", HotelRating.FourStars );
            var user2 = new User("hdsauiuisd@gmail.com", "jjkdsa", "jkdsakk", false);
          
            var reviewReactions1 = new List<UserReviewReaction>()
            {
                new UserReviewReaction(review1, user1, ReactionType.Like),
                new UserReviewReaction(review1, user2, ReactionType.Like)
            };

            review1.UserReactions = reviewReactions1;

            var review2 = new Review(new User("hhsahdkksa@gmail.com", "displ", "passs", false), hotel, "jhksada", HotelRating.TwoStars);

            var reviewReactions2 = new List<UserReviewReaction>()
            {
                new UserReviewReaction(review2, user1, ReactionType.Dislike),
                new UserReviewReaction(review2, user2, ReactionType.Like)
            };

            review2.UserReactions = reviewReactions2;

            var reviewList = new List<Review>()
            {
                review1,
                review2
            };

            hotel.Reviews = reviewList;

            hotel.OverallRating.Should().Be(3.5);
        }
    }
}
  