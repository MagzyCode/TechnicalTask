using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ServerPart.Models.ErrorModel;
using System.Linq;
using System.Text;

namespace ServerPart.ActionFilters
{
    public class ValidationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var param = context.ActionArguments
                .SingleOrDefault(x => x.Value.ToString().Contains("Dto")).Value;

            if (param == null)
                context.Result = new BadRequestObjectResult(new ErrorDetails()
                {
                    StatusCode = 400,
                    Message = "Incoming DTO model in null."
                });

            if (!context.ModelState.IsValid)
            {
                var errorMessage = new StringBuilder();

                foreach (var error in context.ModelState.Values)
                {
                    error.Errors.Select(x => x.ErrorMessage).ToList().ForEach((message) =>
                    {
                        errorMessage.Append(message + " ");
                    });
                }

                context.Result = new BadRequestObjectResult(new ErrorDetails()
                {
                    StatusCode = 400,
                    Message = errorMessage.ToString()
                });
            }
        }
    }
}
