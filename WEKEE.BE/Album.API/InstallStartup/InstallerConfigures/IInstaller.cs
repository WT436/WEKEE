using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Album.API.InstallStartup.InstallerConfigures
{
    public interface IInstaller
    {
        void InstallConfiguration(IConfiguration configuration);
    }
}
