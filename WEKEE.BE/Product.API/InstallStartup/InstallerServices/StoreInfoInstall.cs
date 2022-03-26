using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils.Auth.Dtos;
using Utils.Email.Dtos;

namespace Product.API.InstallStartup.InstallerServices
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

            services.Configure<FormOptions>(o => {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
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
