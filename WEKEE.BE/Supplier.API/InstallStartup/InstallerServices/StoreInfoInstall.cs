using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils.Auth.Dtos;
using Utils.Email.Dtos;

namespace Supplier.API.InstallStartup.InstallerServices
{
    public class StoreInfoInstall : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ExternalClientJsonConfiguration>(configuration.GetSection("ExternalClientServer"));
            services.Configure<MailSettings>(configuration.GetSection("MailSettings"));

            services.AddCors(option =>
            {
                option.AddPolicy("CorsPolicy", builder => builder.WithOrigins("http://localhost:7000/")
                      .AllowAnyHeader()
                      .AllowAnyMethod()
                      .AllowCredentials()
                      .SetIsOriginAllowed((host) => true));
            });

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(86400);
                options.Cookie.Name = "Weekee_sc";
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
        }
    }
}
