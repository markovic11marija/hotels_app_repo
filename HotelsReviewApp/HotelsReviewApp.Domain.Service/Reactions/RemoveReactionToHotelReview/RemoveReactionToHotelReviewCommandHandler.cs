using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HotelsReviewApp.Domain.Model;
using HotelsReviewApp.Domain.Model.Core;
using HotelsReviewApp.Infrastructure.Data;
using MediatR;

namespace HotelsReviewApp.Domain.Service.Reactions.RemoveReactionToHotelReview
{
    public class RemoveReactionToHotelReviewCommandHandler : IRequestHandler<RemoveReactionToHotelReviewCommand,
        CommandResult<CommandEmptyResult>>
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Review> _reviewRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveReactionToHotelReviewCommandHandler(IRepository<User> userRepository, IUnitOfWork unitOfWork,
            IRepository<Review> reviewRepository)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _reviewRepository = reviewRepository;
        }

        public Task<CommandResult<CommandEmptyResult>> Handle(RemoveReactionToHotelReviewCommand request,
            CancellationToken cancellationToken)
        {
            var user = _userRepository.QueryAllIncluding(u => u.ReviewReactions).SingleOrDefault(u => u.Id == request.UserId);
            var reaction = user?.ReviewReactions?.SingleOrDefault(r => r.ReviewId == request.ReviewId && r.ReactionType == request.ReactionType);

            if (user != null && reaction != null)
            {
                user.RemoveReaction(reaction);
                _unitOfWork.SaveChanges();
                return Task.FromResult(CommandResult<CommandEmptyResult>.Success(new CommandEmptyResult()));
            }

            return Task.FromResult(CommandResult<CommandEmptyResult>.Fail("Fail to remove reaction."));
        }
    }
}