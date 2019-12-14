using HotelsReviewApp.Domain.Model.Core;
using MediatR;

namespace HotelsReviewApp.Domain.Service.Users.SignUpRegularUser
{
  public class SignUpRegularUserCommand : IRequest<CommandResult<CommandEmptyResult>>
    {
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
    }
}
