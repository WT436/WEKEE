using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.InstallStartup.EnvInstall
{
    public class RouterConfigure : IConfigureInstaller
    {
        public void InstallService(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                       name: "Product.API.Src.CategoryProductAPI",
                       template: "{controller=CategoryProduct}/{action=Index}/{id?}",
                new string[] { "Product.API.Src.CategoryProductAPI" });

                routes.MapRoute(
                        name: "Default",
                        template: "{controller=Invalid}/{action=Index}/{id?}",
                 new string[] { "Album.API.Src.Controllers" });
            });
        }
    }
}
