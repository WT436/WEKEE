using Product.API.FilterAttributeCore.ActionFilters;
using Product.API.FilterAttributeCore.ExceptionFilter;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Product.API.FilterAttributeCore.AuthorizationFilter;
using Microsoft.AspNetCore.Builder;
using System.Net;
using Product.API.FilterAttributeCore.ResourceFilters;

namespace Product.API.InstallStartup.InstallerServices
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
                //AuthorizationFilter
                op.Filters.Add(new ProcessAuthenticationFilter());
                //ResourceFilters
                //op.Filters.Add(new CacheResourceFilter());
                //ActionFilters
                op.Filters.Add(new ValidationFilterAttribute());
                op.Filters.Add(new ExcutionTimeFilterAttribute());
                op.Filters.Add(new ModelValidationFilterAttribute());
                //ExceptionFilter
                op.Filters.Add(new ProcessExceptionFilterAttribute());
            });
        }
    }
}
