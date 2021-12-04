using Account.Application.Application;
using Account.Application.Interface;
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

            // DI Account User
            services.AddTransient<IRegistration, Registration>();
            services.AddTransient<ILoginAccount, LoginAccount>();
            services.AddTransient<IChangePassword, ChangePassword>();
            services.AddTransient<ICheckRole, CheckRole>();
            services.AddTransient<IProcessAccount, ProcessAccount>();
            services.AddTransient<IProcessIPAccount, ProcessIPAccount>();
            services.AddTransient<ICacheSession, CacheSession>();
            services.AddTransient<IInfomationUser, AInfomationUser>();

            // DI Role
            services.AddTransient<IResource, Resource>();
            services.AddTransient<IAtomic, Atomic>();
            services.AddTransient<IAction, Action>();
            services.AddTransient<IPermission, Permission>();
            services.AddTransient<IRole, Role>();
            services.AddTransient<IResourceAction, AResourceAction>();
            services.AddTransient<IActionAssignment, AActionAssignment>();
            services.AddTransient<IPermissionAssignment, APermissionAssignment>();
            services.AddTransient<IAccountAdminProcess, AAccountAdminProcess>();

            // DI Account 
            services.AddTransient<IAdminAccount, AAdminAccount>();
            services.AddTransient<ISubjectAssignment, ASubjectAssignment>();
            services.AddTransient<ISubject, ASubject>();

        }
    }

}
