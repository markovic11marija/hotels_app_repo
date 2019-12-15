namespace HotelsReviewApp.Domain.Model
{
    public class UserFavoriteHotel
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

        public UserFavoriteHotel()
        {
            
        }

        public UserFavoriteHotel(User user, Hotel hotel)
        {
            User = user;
            Hotel = hotel;
        }
    }
}
