using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Application.Interface;

namespace Product.API.FilterAttributeCore.ResourceFilters
{
    public class IloggingResourceFilter : IResourceFilter
    {
        //log output
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            
        }

        // log input
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            ILogTextLog4Net iLog = context.HttpContext.RequestServices.GetService(typeof(ILogTextLog4Net)) as ILogTextLog4Net;

            var method = context.HttpContext.Request.Method.ToString();
            var controller = context.HttpContext.Request.RouteValues["controller"].ToString();
            var action = context.HttpContext.Request.RouteValues["action"].ToString();
            var parameter = context.HttpContext.Request.QueryString.ToString();
            var path = context.HttpContext.Request.Path.ToString();
            var host = context.HttpContext.Request.Host.Host.ToString();
            var port = context.HttpContext.Request.Host.Port.ToString();

            iLog.LogInformation(String.Format("[{0}] [{1}] [{2}] [{3}] [{4}] [{5}] [{6}]",
                                        host, port, controller, action, method, path, parameter));
        }
    }
}
