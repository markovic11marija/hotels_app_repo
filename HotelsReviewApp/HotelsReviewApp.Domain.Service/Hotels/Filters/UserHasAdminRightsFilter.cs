using System.Linq;
using HotelsReviewApp.Domain.Model;
using HotelsReviewApp.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HotelsReviewApp.Domain.Service.Hotels.Filters
{
  public  class UserHasAdminRightsFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var model = context.ActionArguments.Select(x => x.Value).OfType<int>().First();
            var userRepository = (IRepository<User>)context.HttpContext.RequestServices.GetService(typeof(IRepository<User>));

            var user = userRepository.FindById(model);

            if (user == null || !user.IsAdministrator)
            {
                context.ModelState.AddModelError("Unauthorized", "Unauthorized for this action");
                context.Result = new UnauthorizedObjectResult(context.ModelState);
                return;
            }
        }
    }

}

