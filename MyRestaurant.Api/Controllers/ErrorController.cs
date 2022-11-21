using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace MyRestaurant.Api.Controllers
{
    public class ErrorController : ControllerBase
    {
        [Route("error")]
        public IActionResult Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            return Problem(statusCode: StatusCodes.Status500InternalServerError, title: exception?.Message);
        }
    }
}
