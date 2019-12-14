using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HotelsReviewApp.Domain.Model;
using HotelsReviewApp.Infrastructure.Data;
using MediatR;

namespace HotelsReviewApp.Domain.Service.Users.SignIn
{
    public class SignInQueryHandler : IRequestHandler<SignInQuery, User>
    {
        private readonly IRepository<User> _userRepository;
        public SignInQueryHandler(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(SignInQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_userRepository.QueryAll().FirstOrDefault(u => u.Email == request.Email && u.Password == request.Password));
        }
    }
}
