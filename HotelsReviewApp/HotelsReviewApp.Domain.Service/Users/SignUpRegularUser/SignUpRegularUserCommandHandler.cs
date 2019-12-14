using System.Threading;
using System.Threading.Tasks;
using HotelsReviewApp.Domain.Model;
using HotelsReviewApp.Domain.Model.Core;
using HotelsReviewApp.Infrastructure.Data;
using MediatR;

namespace HotelsReviewApp.Domain.Service.Users.SignUpRegularUser
{
    public class SignUpRegularUserCommandHandler : IRequestHandler<SignUpRegularUserCommand, CommandResult<CommandEmptyResult>>
    {
        private readonly IRepository<User> _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SignUpRegularUserCommandHandler(IRepository<User> userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<CommandResult<CommandEmptyResult>> Handle(SignUpRegularUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.Email, request.DisplayName, request.Password, false);
            _userRepository.Add(user);
            _unitOfWork.SaveChanges();

            return Task.FromResult(CommandResult<CommandEmptyResult>.Success(new CommandEmptyResult()));
        }
    }
}
