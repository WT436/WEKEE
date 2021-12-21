using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Supplier.API.FilterAttributeCore.ActionFilters
{
    public class GetIndexedDbFilterAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
