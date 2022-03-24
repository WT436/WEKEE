using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Product.API.FilterAttributeCore.AuthorizationFilter
{
    /// <summary>
    /// Xác minh người dùng
    /// Cấp private key nếu là người mới
    /// Tự động đăng nhập
    /// </summary>
    public class ProcessAuthenticationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            throw new NotImplementedException();
        }
    }
}
