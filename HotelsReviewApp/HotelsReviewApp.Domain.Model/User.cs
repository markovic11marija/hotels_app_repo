﻿using System.Collections.Generic;

namespace HotelsReviewApp.Domain.Model
{
    public class User : Entity
    {
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public bool IsAdministrator { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
        public IEnumerable<UserFavoriteHotel> FavoriteHotels { get; set; }
        public IEnumerable<UserReviewReaction> ReviewReactions { get; set; }

        public User()
        {
            Reviews = new List<Review>();
            FavoriteHotels = new List<UserFavoriteHotel>();
            ReviewReactions = new List<UserReviewReaction>();
        }

        public User(string email, string displayName, string password, bool isAdministrator)
        {
            Email = email;
            DisplayName = displayName;
            Password = password;
            IsAdministrator = isAdministrator;
        }
    }
}
