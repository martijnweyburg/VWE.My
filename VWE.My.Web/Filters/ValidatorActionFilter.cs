using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace VWE.My.Web.Filters
{
    /// <summary>
    /// Filter for returning a result if one of the models in an incoming call does not pass validation.
    /// </summary>
    public class ValidatorActionFilter : IActionFilter
    {
        /// <summary>
        /// executes the check for model validation
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.ModelState.IsValid)
            {
                filterContext.Result = new BadRequestObjectResult(filterContext.ModelState);
            }
        }


        /// <summary>
        /// After action is executed. Neeeded to implement this function according to the interface.
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }
    }
}
