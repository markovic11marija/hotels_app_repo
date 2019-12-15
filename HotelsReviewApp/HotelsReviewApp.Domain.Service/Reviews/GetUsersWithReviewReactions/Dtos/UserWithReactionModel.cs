namespace HotelsReviewApp.Domain.Service.Reviews.GetUsersWithReviewReactions.Dtos
{
   public class UserWithReactionModel
    {
        public string Email { get; set; }
        public string DisplayName { get; set; }

        public UserWithReactionModel(string email, string displayName)
        {
            Email = email;
            DisplayName = displayName;
        }
    }
}
