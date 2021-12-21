using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.API.InstallStartup.EnvInstall
{
    public static class ConfigureExtensions
    {
        public static void InstallConfigureInAssembly(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            var installers = typeof(Startup).Assembly.ExportedTypes
              .Where(x => typeof(IConfigureInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
              .Select(Activator.CreateInstance)
              .Cast<IConfigureInstaller>()
              .ToList();

            installers.ForEach(ins => ins.InstallService(app, env));
        }
    }
}
