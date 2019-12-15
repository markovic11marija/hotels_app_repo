namespace HotelsReviewApp.Domain.Service.Favorites.GetUserFavorites.Dtos
{
   public class FavoriteHotelModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double OverallRating { get; set; }

        public FavoriteHotelModel(string name, string description, double overallRating)
        {
            Name = name;
            Description = description;
            OverallRating = overallRating;
        }
    }
}
