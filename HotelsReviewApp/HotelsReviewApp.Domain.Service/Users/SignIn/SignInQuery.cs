using HotelsReviewApp.Domain.Model;
using MediatR;

namespace HotelsReviewApp.Domain.Service.Users.SignIn
{
  public  class SignInQuery : IRequest<User>
    {
        public string Email { get; }
        public string Password { get; }

        public SignInQuery(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
