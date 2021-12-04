using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Account.API.InstallStartup
{
    public static class InstallerExtensions
    {
        public static void InstallServicesInAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            var servicesInstallers = typeof(Startup).Assembly.ExportedTypes
              .Where(x => typeof(InstallerServices.IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
              .Select(Activator.CreateInstance)
              .Cast<InstallerServices.IInstaller>()
              .ToList();
            servicesInstallers.ForEach(ins => ins.InstallService(services,configuration));

            var configurationInstallers = typeof(Startup).Assembly.ExportedTypes
              .Where(x => typeof(InstallerConfigures.IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
              .Select(Activator.CreateInstance)
              .Cast<InstallerConfigures.IInstaller>()
              .ToList();            
            configurationInstallers.ForEach(ins => ins.InstallConfiguration(configuration));
        }
    }
}
