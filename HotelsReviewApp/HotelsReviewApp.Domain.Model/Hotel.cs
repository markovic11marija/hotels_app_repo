using System.Collections.Generic;
using System.Linq;

namespace HotelsReviewApp.Domain.Model
{
    public class Hotel : Entity
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public Image Image { get; set; }
        public string Description { get; set; }
        public GeoLocation GeoLocation { get; set; }
        public double OverallRating => Reviews.Any() ? Reviews.Sum(r => r.CalculateRatingFromReview()) / Reviews.Count() : 0 ;
        public IEnumerable<Review> Reviews { get; set; }

        public Hotel()
        {
            Reviews = new List<Review>();
            Address = new Address();
            Image = new Image();
            GeoLocation = new GeoLocation();
        }

        public Hotel(string name, Address address, Image image, string description, GeoLocation geoLocation)
        {
            Name = name;
            Address = address ?? new Address();
            Image = image ?? new Image();
            Description = description;
            GeoLocation = geoLocation ?? new GeoLocation();
        }

        public void UpdateFrom(string name, Address address, Image image, string description, GeoLocation geoLocation)
        {
            Name = name;
            Address = address ?? new Address();
            Image = image ?? new Image();
            Description = description;
            GeoLocation = geoLocation ?? new GeoLocation();
        }

    }
}
