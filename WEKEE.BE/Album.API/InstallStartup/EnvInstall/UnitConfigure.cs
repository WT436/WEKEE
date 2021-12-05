using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Album.API.InstallStartup.EnvInstall
{
    public class UnitConfigure : IConfigureInstaller
    {
        public void InstallService(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            app.UseMvc();
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseRouting();
        }
    }
}
