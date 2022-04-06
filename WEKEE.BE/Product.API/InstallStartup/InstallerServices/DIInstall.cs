#region
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Product.Application.Application;
using Product.Application.Interface;
using System.Application.Application;
using System.Application.Interface;
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
using Utils.Auth;
using Utils.Cache;
using Utils.Email;
using Supplier.Application.Application;
using Supplier.Application.Interface;
using Album.Application.Controll.Application;
using Album.Application.Controll.Interface;
#endregion

namespace Product.API.InstallStartup.InstallerServices
{
    public class DIInstall : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            #region default - common
            services.AddTransient<IJwtHandler, JwtHandler>();
            services.AddTransient<IMailService, MailService>();
            services.AddSingleton<ICacheBase, CacheMemoryHelper>();
            services.AddSingleton<ILogTextLog4Net, LogTextLog4NetService>();
            #endregion

            #region Account
            // DI Account User
            services.AddTransient<IRegistration, RegistrationService>();
            services.AddTransient<ILoginAccount, LoginAccountService>();
            services.AddTransient<IChangePassword, ChangePasswordService>();
            services.AddTransient<ICheckRole, CheckRoleService>();
            services.AddTransient<IProcessAccount, ProcessAccountService>();
            services.AddTransient<IProcessIPAccount, ProcessIPAccountService>();
            services.AddTransient<ICacheSession, CacheSessionService>();
            services.AddTransient<IInfomationUser, InfomationUserService>();

            // DI Role
            services.AddTransient<IResource, ResourceService>();
            services.AddTransient<IAtomic, AtomicService>();
            services.AddTransient<IAction, ActionService>();
            services.AddTransient<IPermission, PermissionService>();
            services.AddTransient<IRole, RoleService>();
            services.AddTransient<IResourceAction, ResourceActionService>();
            services.AddTransient<IActionAssignment, ActionAssignmentService>();
            services.AddTransient<IPermissionAssignment, PermissionAssignmentService>();
            services.AddTransient<IAccountAdminProcess, AccountAdminProcessService>();

            // DI Account 
            services.AddTransient<IAdminAccount, AdminAccountService>();
            services.AddTransient<ISubjectAssignment, SubjectAssignmentService>();
            services.AddTransient<ISubject, SubjectService>();
            #endregion

            #region Supperlier 
            services.AddSingleton<IProcessSupplier, ProcessSupplierService>();
            services.AddSingleton<ISupplier, SupplierService>();
            #endregion

            #region Upload
            services.AddTransient<IImageBasic, ImageBasicService>();
            services.AddTransient<IImageAvatarDefault, AImageAvatarDefault>();
            services.AddTransient<IReadInfoFile, ReadInfoFileService>();
            #endregion

            #region Product
            services.AddTransient<ICategoryProduct, CategoryProductService>();
            services.AddTransient<ISpecificationAttribute, SpecificationAttributeService>();
            services.AddTransient<IProductAttribute, ProductAttributeService>();
            services.AddTransient<IProductTag, ProductTagService>();
            services.AddTransient<IProductContainer, ProductContainerService>();
            services.AddTransient<IProductAlbum, ProductAlbumService>();
            #endregion
        }
    }

}
