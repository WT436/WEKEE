using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supplier.API.InstallStartup.EnvInstall
{
    public interface IConfigureInstaller
    {
        void InstallService(IApplicationBuilder app, IWebHostEnvironment env);
    }
}
