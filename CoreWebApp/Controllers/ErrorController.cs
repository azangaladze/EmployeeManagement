using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CoreWebApp.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            this.logger = logger;
        }

        [Route("Error/{statuscode}")]
        public IActionResult HttpStatusCodeHandler(int statuscode)
        {
            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            switch (statuscode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry the page you requested was not found";
                    logger.LogWarning($"404 Error occured {statusCodeResult.OriginalPath} " +
                        $"and QueryString = {statusCodeResult.OriginalQueryString}");

                    break;
            }
            return View("NotFound");
        }

        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error() 
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            logger.LogError($"The path {exceptionDetails.Path} threw an exception {exceptionDetails.Error}");

            return View("Error");

        }
    }


}
