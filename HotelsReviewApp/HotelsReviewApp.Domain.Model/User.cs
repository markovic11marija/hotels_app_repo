using System.Collections.Generic;

namespace HotelsReviewApp.Domain.Model
{
    public class User : Entity
    {
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public bool IsAdministrator { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
        public IList<UserFavoriteHotel> FavoriteHotels { get; set; } = new List<UserFavoriteHotel>();
        public IList<UserReviewReaction> ReviewReactions { get; set; } = new List<UserReviewReaction>();

        public User()
        {
            Reviews = new List<Review>();
        }

        public User(string email, string displayName, string password, bool isAdministrator)
        {
            Email = email;
            DisplayName = displayName;
            Password = password;
            IsAdministrator = isAdministrator;
        }

        public void AddReaction(UserReviewReaction reaction)
        {
            ReviewReactions.Add(reaction);
        }
        public void RemoveReaction(UserReviewReaction reaction)
        {
            ReviewReactions.Remove(reaction);
        }

        public void AddHotelToFavorites(UserFavoriteHotel favoriteHotel)
        {
            FavoriteHotels.Add(favoriteHotel);
        }

        public void RemoveHotelFromFavorites(UserFavoriteHotel favoriteHotel)
        {
            FavoriteHotels.Remove(favoriteHotel);
        }
    }
}
