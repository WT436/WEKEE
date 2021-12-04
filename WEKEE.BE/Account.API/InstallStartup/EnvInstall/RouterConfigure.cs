using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Account.API.InstallStartup.EnvInstall
{
    public class RouterConfigure : IConfigureInstaller
    {
        public void InstallService(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                        name: "AccountAreas",
                        template: "{controller=LoginAccount}/{action=Index}/{id?}",
                 new string[] { "Account.API.Src.AccountAreas" });

                routes.MapRoute(
                        name: "Default",
                        template: "{controller=Invalid}/{action=Index}/{id?}",
                 new string[] { "Account.API.Src.Controllers" });
            });
        }
    }
}
