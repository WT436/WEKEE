using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.InstallStartup.InstallerConfigures
{
    public interface IInstaller
    {
        void InstallConfiguration(IConfiguration configuration);
    }
}
