using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Product.Application.Application;
using Product.Application.Interface;
using Utils.Auth;
using Utils.Cache;
using Utils.Email;

namespace Product.API.InstallStartup.InstallerServices
{
    public class DIInstall : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            // DI default - common
            services.AddTransient<IJwtHandler, JwtHandler>();
            services.AddTransient<IMailService, MailService>();
            services.AddSingleton<ICacheBase, CacheMemoryHelper>();
            
            // CategoryProduct
            services.AddTransient<ICategoryProduct, CategoryProductService>();
        }
    }

}
