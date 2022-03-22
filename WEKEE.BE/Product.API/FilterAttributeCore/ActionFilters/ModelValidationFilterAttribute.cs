using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;

namespace Product.API.FilterAttributeCore.ActionFilters
{
    public class ModelValidationFilterAttribute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if(context.ModelState.Count>0)
            {
                context.Result = new UnprocessableEntityObjectResult(context.ModelState);
                return;
            }
        }
    }
}