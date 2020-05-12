using API.Error;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("errorredirect/{code}")]
    [ApiExplorerSettings(IgnoreApi= true)]
    public class ErrorRedirectController : BaseController
    {
        public IActionResult RedirectResponse(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}