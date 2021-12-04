using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UnitOfWork;

namespace Account.API.InstallStartup.InstallerServices
{
    public class UnitOfWorkInstall : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {         
            //services.AddDbContext<DbSystemContext>(opt =>
            //{
            //    opt.UseSqlServer(configuration["ConnectionStrings:DbSystemDbContextStr"]);
            //})
            //        .AddUnitOfWork<DbSystemContext>()
            //;
        }
    }
}
