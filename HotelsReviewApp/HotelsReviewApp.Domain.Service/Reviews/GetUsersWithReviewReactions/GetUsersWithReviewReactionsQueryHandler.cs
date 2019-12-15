using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HotelsReviewApp.Domain.Model;
using HotelsReviewApp.Domain.Service.Reviews.GetUsersWithReviewReactions.Dtos;
using HotelsReviewApp.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HotelsReviewApp.Domain.Service.Reviews.GetUsersWithReviewReactions
{
    public class GetUsersWithReviewReactionsQueryHandler:IRequestHandler<GetUsersWithReviewReactionsQuery, IEnumerable<UserWithReactionModel>>
    {
        private readonly IRepository<Review> _reviewRepository;

        public GetUsersWithReviewReactionsQueryHandler(IRepository<Review> reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<IEnumerable<UserWithReactionModel>> Handle(GetUsersWithReviewReactionsQuery request, CancellationToken cancellationToken)
        {
            var result = _reviewRepository.QueryAll().Include(u => u.UserReactions)
                .ThenInclude(r => r.User)
                .FirstOrDefault(o => o.Id == request.ReviewId)?
                .UserReactions?
                .Where(ur => ur.ReactionType == request.ReactionType)
                .Select(re => new UserWithReactionModel(re.User.Email, re.User.DisplayName))
                .ToList();
            return await Task.FromResult(result);
        }
    }
}
