using Microsoft.AspNetCore.Mvc;

namespace HotelsReviewApp.Api.Controllers
{
    [Route("[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class HotelsController : Controller
    {
        [HttpGet]
        public ActionResult<int> GetAll()
        {
            return Ok(500);
        }

    }
}