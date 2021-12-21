using Supplier.API.FilterAttributeCore.ActionFilters;
using Supplier.API.FilterAttributeCore.ExceptionFilter;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Supplier.API.FilterAttributeCore.AuthorizationFilter;
using Microsoft.AspNetCore.Builder;
using System.Net;

namespace Supplier.API.InstallStartup.InstallerServices
{
    public class ControllerInstall : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ForwardedHeadersOptions>(op=> {

                op.KnownProxies.Add(IPAddress.Parse("You"));
            });
            services.AddControllers(op=>
            {
                op.Filters.Add(new ValidationFilterAttribute());
                //op.Filters.Add(new ProcessAuthorizationFilter());
                op.Filters.Add(new ExcutionTimeFilterAttribute());
                op.Filters.Add(new ProcessExceptionFilterAttribute());
            });
        }
    }
}
