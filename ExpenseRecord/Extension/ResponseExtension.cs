using System.Net;
using ExpenseRecord.Models.ResponseItem;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ExpenseRecord.Extension
{
    public static class ResponseExtension
    {
        public static IActionResult ToActionResult<T>(this Response<T> serviceResult,
            ControllerBase controller, ProblemDetailsFactory problemDetailsFactory) where T : class
        {

            switch (serviceResult.StatusCode)
            {
                case HttpStatusCode.OK:
                {
                    return serviceResult.Body != null ? (IActionResult)controller.Ok(serviceResult.Body) : controller.Ok();
                }
                case HttpStatusCode.NoContent:
                {
                    return controller.NoContent();
                }
                case HttpStatusCode.BadRequest:
                case HttpStatusCode.NotFound:
                case HttpStatusCode.InternalServerError:
                {
                    var unsuccessfulServiceResult = serviceResult as UnsuccessfulResponse<T>;
                    return controller.StatusCode((int)serviceResult.StatusCode,
                        problemDetailsFactory.CreateProblemDetails(
                            controller.HttpContext,
                            (int)serviceResult.StatusCode,
                            detail: unsuccessfulServiceResult?.ErrorInfo));
                }
                default:
                {
                    return controller.StatusCode((int)serviceResult.StatusCode, serviceResult.Body);
                }
            }
        }
    }
}
