using HotelsReviewApp.Domain.Model;
using HotelsReviewApp.Domain.Model.Core;
using MediatR;

namespace HotelsReviewApp.Domain.Service.Reactions.ReactToHotelReview
{
    public class ReactToHotelReviewCommand : IRequest<CommandResult<CommandEmptyResult>>
    {
        public int UserId { get; }
        public int ReviewId { get; }
        public ReactionType ReactionType { get; set; }

        public ReactToHotelReviewCommand(int userId, int reviewId, ReactionType reactionType)
        {
            UserId = userId;
            ReviewId = reviewId;
            ReactionType = reactionType;
        }
    }
}
