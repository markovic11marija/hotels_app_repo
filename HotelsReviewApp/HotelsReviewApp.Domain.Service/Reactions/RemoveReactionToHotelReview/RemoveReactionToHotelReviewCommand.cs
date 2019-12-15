using System;
using System.Collections.Generic;
using System.Text;
using HotelsReviewApp.Domain.Model;
using HotelsReviewApp.Domain.Model.Core;
using MediatR;

namespace HotelsReviewApp.Domain.Service.Reactions.RemoveReactionToHotelReview
{
   public class RemoveReactionToHotelReviewCommand : IRequest<CommandResult<CommandEmptyResult>>
    {
        public int UserId { get; }
        public int ReviewId { get; }
        public ReactionType ReactionType { get; }

        public RemoveReactionToHotelReviewCommand(int userId, int reviewId, ReactionType reactionType)
        {
            UserId = userId;
            ReviewId = reviewId;
            ReactionType = reactionType;
        }
    }
}