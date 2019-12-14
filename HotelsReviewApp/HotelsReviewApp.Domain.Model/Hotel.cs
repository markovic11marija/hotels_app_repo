using System.Collections.Generic;

namespace HotelsReviewApp.Domain.Model
{
    public class Hotel: Entity
    {
        public string Name { get; set; }
        //public Address Address { get; set; }
        //public Image Image { get; set; }
        public string Description { get; set; }
        //public GeoLocation GeoLocation { get; set; }
        //public double OverallRating { get; set; } //TODO: should be calculated field
        //public IEnumerable<Review> Reviews { get; set; }

    }
}
