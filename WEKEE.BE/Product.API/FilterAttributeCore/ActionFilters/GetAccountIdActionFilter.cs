using Account.Domain.BoundedContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Product.API.FilterAttributeCore.ActionFilters
{
    public class GetAccountIdActionFilter : IActionFilter
    {
        //lọc JWT và trích xuất Id Account => chuyển vào 
        //I need to determine which domain the method called is associated with
        public void OnActionExecuting(ActionExecutingContext context)
        {
        //    TokenToJWT tokenToJWT = new TokenToJWT();
        //    var token = context.HttpContext.Request.Headers["Authorization"].ToString();
        //    var idAccount = tokenToJWT.DecryptionToken(token).Id;

        //    var controller = (ControllerBase)context.Controller;
        //    controller.HttpContext.Items.Add("idAccount", idAccount);
        }
        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
