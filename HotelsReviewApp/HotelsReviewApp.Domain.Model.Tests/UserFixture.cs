using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;

namespace HotelsReviewApp.Domain.Model.Tests
{
   public class UserFixture
    {
        [Fact]
        public void User_Reactions()
        {
            var hotel1 = new Hotel("name1", new Address(), new Image(), "desc 1", new GeoLocation());
            var hotel2 = new Hotel("name2", new Address(), new Image(), "desc 2", new GeoLocation());

            var user = new User("nsas@gmail.com", "sasa", "sasas", false);
            var review1 = new Review(user, hotel1, "dewdewhu duweihidwe", HotelRating.OneStar);
            var review2 = new Review(user, hotel2, "njnjdsnkn njdfnksds", HotelRating.ZeroStar);
            var reaction1 = new UserReviewReaction(review1, user, ReactionType.Like);
            var reaction2 = new UserReviewReaction(review2, user, ReactionType.Dislike);
         
            user.AddReaction(reaction1);
            user.AddReaction(reaction2);
            user.ReviewReactions.Count.Should().Be(2);
            user.RemoveReaction(reaction1);
            user.ReviewReactions.Count.Should().Be(1);
        }

        [Fact]
        public void User_Favorites()
        {
            var hotel1 = new Hotel("name1", new Address(), new Image(), "desc 1", new GeoLocation());
            var hotel2 = new Hotel("name2", new Address(), new Image(), "desc 2", new GeoLocation());

            var user = new User("nsas@gmail.com", "sasa", "sasas", false);
            var favorite1 = new UserFavoriteHotel(user, hotel1);
            var favorite2 = new UserFavoriteHotel(user, hotel2);

            user.AddHotelToFavorites(favorite1);
            user.AddHotelToFavorites(favorite2);
            user.FavoriteHotels.Count.Should().Be(2);
            user.RemoveHotelFromFavorites(favorite2);
            user.FavoriteHotels.Count.Should().Be(1);
        }
    }
}
