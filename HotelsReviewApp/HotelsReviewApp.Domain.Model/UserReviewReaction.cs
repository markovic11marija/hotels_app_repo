namespace HotelsReviewApp.Domain.Model
{
  public class UserReviewReaction
    {
        public int ReviewId { get; set; }
        public Review Review { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ReactionType ReactionType { get; set; }

        public int GetPointsForOverallRating()
        {
            return ReactionType == ReactionType.Like ? 1 : -1;
        }
    }
}
