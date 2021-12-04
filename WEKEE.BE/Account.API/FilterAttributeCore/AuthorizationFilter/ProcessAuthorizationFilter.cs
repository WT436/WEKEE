using Account.Application.Application;
using Account.Application.Interface;
using Account.Domain.Dto;
using Account.Domain.Entitys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;
using Account.API.SettingUrl.Base;
// xác thực : https://docs.oracle.com/cd/B28196_01/idmanage.1014/b25990/v2authen.htm
namespace Account.API.FilterAttributeCore.AuthorizationFilter
{
    public class ProcessAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // khởi tạo cần thiết : 
            IProcessAccount processAccount = new ProcessAccount();
            ICheckRole checkRole = new CheckRole();
            // lấy thông tin
            var token = context.HttpContext.Request.Headers["Authorization"].ToString();
            var ip = context.HttpContext.Connection.RemoteIpAddress.ToString();
            string url = context.HttpContext.Request.Path.ToString().ToLower();
            // kiểm tra định dạng url
            var urlHome = url.Length == 1 && url.Contains("/");
            var formatUrl = !url.ToLower().Contains(RootUrl.ROOT.ToLower())
                         && !url.ToLower().Contains("/invalid".ToLower());

            if (!urlHome && formatUrl)
            {
                context.Result = new RedirectToRouteResult(
                               new RouteValueDictionary(
                                   new { controller = "Invalid", action = "IndexErrorClient404" }));
                return;
            }

            // kiểm tra đường dẫn lỗi
            if (!url.ToLower().Contains("/invalid".ToLower()))
            {
                // kiểm tra hiệu lực của token
                var tokenValidate = processAccount.ProcessToken(token);
                bool isTokenExpire = tokenValidate.Account_User == null;
                bool isTokenNull = String.IsNullOrEmpty(token);
                if (isTokenExpire) // token hết hạn hoặc không có
                {
                    if (!isTokenNull) //token có nhưng hết hạn. => client phải xóa token
                    {
                        context.Result = new RedirectToRouteResult(
                                new RouteValueDictionary(
                                    new { controller = "Invalid", action = "IndexErrorClient401" }));
                        return;
                    }
                    else // Không có token chỉ cho vào các trang của khách vãng lai
                    {
                        if (!checkRole.ListRole(url, 0)) // nếu đường dãn khác các trang vãng lai
                        {
                            context.Result = new RedirectToRouteResult(
                                 new RouteValueDictionary(
                                     new { controller = "Invalid", action = "IndexErrorClient405" }));
                            return;
                        }
                    }
                }
                else // token có thể xác thực được
                {
                    ICacheSession cacheSession = new CacheSession();
                    var cacheSessionAccount = cacheSession.GetUniqueSession(tokenValidate.Account_User);
                    if (cacheSessionAccount == null) // Trong cache Không có Session User này
                    {
                        // Kiểm tra IP và csdl rồi đăng nhập tự động
                        IProcessIPAccount processIPAccount = new ProcessIPAccount();
                        var ipLst = processIPAccount.GetListIPAccount(tokenValidate.Id);
                        if (ipLst.Any(m => m.Ip == tokenValidate.Ip && m.Ip == ip)) // Ip chính Xác
                        {
                            ILoginAccount account = new LoginAccount();
                            var unitAccount = account.getUserAccount(tokenValidate.Id); // lấy thông tin tài khoản
                            var role = checkRole.RoleDtos(unitAccount.UserProfileId); // lấy quyền tài khoản
                            cacheSession.SetUniqueSession(new SessionCustom
                            {
                                Id_User = unitAccount.UserProfileId,
                                Account_User = unitAccount.UserName,
                                Email = unitAccount.Email,
                                Ip = ip,
                                Role = role,
                            });
                        }
                        else // Xóa Token khi ip không chính xác
                        {
                            context.Result = new RedirectToRouteResult(
                                new RouteValueDictionary(
                                    new { controller = "Invalid", action = "IndexErrorClient401" }));
                            return;
                        }
                    }
                    else // trong cache có User này
                    {
                        if (processAccount.CompareSessionCookie(tokenValidate, cacheSessionAccount, ip))
                        {
                            var role = cacheSessionAccount.Role;
                            if (!checkRole.RoleUrl(url, role))
                            {
                                context.Result = new RedirectToRouteResult(
                                 new RouteValueDictionary(
                                     new { controller = "Invalid", action = "IndexErrorClient405" }));
                                return;
                            }
                        }
                        else
                        {
                            cacheSession.RemoveUniqueSesion(cacheSessionAccount.Id_Session);
                        }
                    }
                }
            }
        }
    }
}
