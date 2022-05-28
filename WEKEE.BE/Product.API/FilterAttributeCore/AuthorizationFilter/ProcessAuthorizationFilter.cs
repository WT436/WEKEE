using Account.Application.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Linq;
using Utils.Cache;
using Account.Domain.ObjectValues.Enum;
// xác thực : https://docs.oracle.com/cd/B28196_01/idmanage.1014/b25990/v2authen.htm
namespace Product.API.FilterAttributeCore.AuthorizationFilter
{
    /// <summary>
    /// Xác thực tài nguyên người dùng có thể truy cập.
    /// Cấp quyền cho người dùng
    /// </summary>
    public class ProcessAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var _processToken = context.HttpContext.RequestServices.GetService<IProcessToken>();

            // get data token
            var token = context.HttpContext.Request.Headers["_attk"].ToString();
            var validateToken = context.HttpContext.Request.Headers["_actk"].ToString();
            var method = context.HttpContext.Request.Method.ToString();
            var controller = context.HttpContext.Request.RouteValues["controller"].ToString();
            var action = context.HttpContext.Request.RouteValues["action"].ToString();

            // kiểm tra định dạng url
            var urlFail = controller.ToLower() == "Invalid".ToLower();
            var resultToken = _processToken.ValidateToken(token: token, validateToken: validateToken);
            if (urlFail) return;
            //if (resultToken != ErrorOauth.SUCCESS)
            //{
            //    context.Result = new RedirectToRouteResult(
            //                   new RouteValueDictionary(
            //                       new { controller = "Invalid", action = "IndexErrorClient401" }));
            //    return;
            //}

            // check token
            if (token == null)
            {

            }
            else
            {

            }
            // check role
            // check data
        }
    }
}
