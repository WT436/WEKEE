using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.API.InstallStartup.InstallerServices
{
    public class CultureServices : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
        }
    }
}
