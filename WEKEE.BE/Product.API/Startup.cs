using Product.API.InstallStartup;
using Product.API.InstallStartup.EnvInstall;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace Product.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
            => Configuration = configuration;
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
            => services.InstallServicesInAssembly(Configuration);
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("CorsPolicy");

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "RootFiles")),
                RequestPath = "/album-resources"
            });

            var swaggerConfigStartup = new SwaggerConfigStartup();
            Configuration.GetSection(nameof(SwaggerConfigStartup)).Bind(swaggerConfigStartup);

            app.UseSwagger(op => { op.RouteTemplate = swaggerConfigStartup.JsonRoute; });
            app.UseSwaggerUI(op =>
            {
                op.EnableDeepLinking();
                op.DocExpansion(docExpansion: Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
                op.SwaggerEndpoint(swaggerConfigStartup.UIEndpoint, swaggerConfigStartup.Description);
            });

            app.InstallConfigureInAssembly(env);
        }
    }
}
