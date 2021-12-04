using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Account.API.FilterAttributeCore.ActionFilters
{
    public class ValidationFilterAttribute : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // tham số truyền vào không được có ký tự đặc biệt
            //var Arguments = context.ActionArguments;
            //string values = String.Empty;
            //foreach (var item in Arguments)
            //{
            //    values = item.Value.ToString().ToLower();
            //}
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}
