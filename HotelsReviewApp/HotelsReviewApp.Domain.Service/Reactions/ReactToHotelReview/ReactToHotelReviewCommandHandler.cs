using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HotelsReviewApp.Domain.Model;
using HotelsReviewApp.Domain.Model.Core;
using HotelsReviewApp.Infrastructure.Data;
using MediatR;

namespace HotelsReviewApp.Domain.Service.Reactions.ReactToHotelReview
{
    public class ReactToHotelReviewCommandHandler : IRequestHandler<ReactToHotelReviewCommand, CommandResult<CommandEmptyResult>>
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Review> _reviewRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ReactToHotelReviewCommandHandler(IRepository<User> userRepository, IUnitOfWork unitOfWork, IRepository<Review> reviewRepository)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _reviewRepository = reviewRepository;
        }

        public Task<CommandResult<CommandEmptyResult>> Handle(ReactToHotelReviewCommand request, CancellationToken cancellationToken)
        {
            var user = _userRepository.QueryAllIncluding(u => u.ReviewReactions).SingleOrDefault(u => u.Id == request.UserId);
            var review = _reviewRepository.FindById(request.ReviewId);
            if (user == null || review == null)
                return Task.FromResult(CommandResult<CommandEmptyResult>.Fail("Fail to add reaction to review."));

            if (user.ReviewReactions.Any(r => r.ReviewId == request.ReviewId && r.ReactionType == request.ReactionType))
                return Task.FromResult(CommandResult<CommandEmptyResult>.Fail("Reaction already exists."));

            user.AddReaction(new UserReviewReaction(review, user, request.ReactionType));
            _unitOfWork.SaveChanges();
            return Task.FromResult(CommandResult<CommandEmptyResult>.Success(new CommandEmptyResult()));

        }
    }
}
