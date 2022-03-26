using Album.Application.Application;
using Album.Application.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Product.Application.Application;
using Product.Application.Interface;
using System.Application.Application;
using System.Application.Interface;
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
            services.AddSingleton<ILogTextLog4Net, LogTextLog4NetService>();

            // Upload

            services.AddTransient<IImageBasic, AImageBasic>();
            services.AddTransient<IImageAvatarDefault, AImageAvatarDefault>();
            // CategoryProduct
            services.AddTransient<ICategoryProduct, CategoryProductService>();
        }
    }

}
