using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace TestApplication.Controllers
{
    [Route("[controller]")]
    public class InvalidController : Controller
    {
        public IActionResult Invalid()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

            if (context == null) return View();

           // var stackTrace = context.Error.StackTrace;
             
            return Problem(context.Error.Message,"NULL",500,"Invalid Id","Request Error");
        }
    }
}
