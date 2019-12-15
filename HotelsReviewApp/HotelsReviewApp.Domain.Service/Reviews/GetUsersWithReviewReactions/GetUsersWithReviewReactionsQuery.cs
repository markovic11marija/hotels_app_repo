using System.Collections.Generic;
using HotelsReviewApp.Domain.Model;
using HotelsReviewApp.Domain.Service.Reviews.GetUsersWithReviewReactions.Dtos;
using MediatR;

namespace HotelsReviewApp.Domain.Service.Reviews.GetUsersWithReviewReactions
{
   public class GetUsersWithReviewReactionsQuery: IRequest<IEnumerable<UserWithReactionModel>>
    {
        public int ReviewId { get; }
        public ReactionType ReactionType { get;  }

        public GetUsersWithReviewReactionsQuery(int reviewId, ReactionType reactionType)
        {
            ReviewId = reviewId;
            ReactionType = reactionType;
        }
    }
}
