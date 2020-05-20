using System.Linq;
using SimpleApi.Controllers.Resources;
using Microsoft.AspNetCore.Mvc;

namespace SimpleApi.Config
{
    public static class InvalidModelStateResponseFactory
    {
        public static IActionResult ErrorResponse(ActionContext context)
        {
            var errors = context.ModelState
                                .SelectMany(m => m.Value.Errors)
                                .Select(m => m.ErrorMessage)
                                .ToList();

            var response = new ErrorResource(messages: errors);
            return new BadRequestObjectResult(response);
        }
    }
}