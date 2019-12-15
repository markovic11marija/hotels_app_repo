namespace HotelsReviewApp.Domain.Service.Reviews.GetUsersWithReviewReactions.Dtos
{
   public class UserWithReaction
    {
        public string Email { get; set; }
        public string DisplayName { get; set; }

        public UserWithReaction(string email, string displayName)
        {
            Email = email;
            DisplayName = displayName;
        }
    }
}
