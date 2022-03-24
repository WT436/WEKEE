using Account.Application.AccountAdminProcess;
using Account.Application.Action;
using Account.Application.ActionAssignment;
using Account.Application.AdminAccount;
using Account.Application.Atomic;
using Account.Application.CacheSession;
using Account.Application.ChangePassword;
using Account.Application.CheckRole;
using Account.Application.InfomationUser;
using Account.Application.LoginAccount;
using Account.Application.Permission;
using Account.Application.PermissionAssignment;
using Account.Application.ProcessAccount;
using Account.Application.ProcessIPAccount;
using Account.Application.Registration;
using Account.Application.Resource;
using Account.Application.ResourceAction;
using Account.Application.Role;
using Account.Application.Subject;
using Account.Application.SubjectAssignment;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Utils.Auth;
using Utils.Cache;
using Utils.Email;

namespace Account.API.InstallStartup.InstallerServices
{
    public class DIInstall : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            // DI default - common
            services.AddTransient<IJwtHandler, JwtHandler>();
            services.AddTransient<IMailService, MailService>();
            services.AddTransient<ICacheBase, CacheMemoryHelper>();

           

        }
    }

}
