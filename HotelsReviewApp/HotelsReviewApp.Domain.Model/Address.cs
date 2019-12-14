using System.Reflection.Metadata;

namespace HotelsReviewApp.Domain.Model
{
   public class Address
    {
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public string HouseNumberAddition { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
