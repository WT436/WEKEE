#region
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Product.Application.Application;
using Product.Application.Interface;
using System.Application.Application;
using System.Application.Interface;
using Utils.Auth;
using Utils.Cache;
using Utils.Email;
using Supplier.Application.Application;
using Supplier.Application.Interface;
using Album.Application.Controll.Application;
using Album.Application.Controll.Interface;
using Account.Application.Interface;
using Account.Application.Service;
#endregion

namespace Product.API.InstallStartup.InstallerServices
{
    public class DIInstall : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            // Scoped: Kiểu 1:1 Service bị hủy thì nó sẽ hủy toàn bộ,
            // 1 Scoped sinh ra thì tất cả những yêu cầu từ phía 1 HTTP nhưng dùng nhiều view or controller
            // Singleton : Khởi tạo 1 lần cho cả hệ thống. Chỉ 1 object dùng chung cho hệ thống
            // Transient : Khởi tạo object mỗn lần khi được yêu cầu - riêng lẻ

            #region default - common
            services.AddTransient<IJwtHandler, JwtHandler>();
            services.AddTransient<IMailService, MailService>();
            services.AddSingleton<ICacheBase, CacheMemoryHelper>();
            services.AddSingleton<ILogTextLog4Net, LogTextLog4NetService>();
            #endregion

            #region Account and Permission
            services.AddTransient<IAdminResource, AdminResourceService>();
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
            services.AddTransient<IProductAttributeValues, ProductAttributeValuesService>();
            services.AddTransient<IProduct, ProductService>();
            services.AddTransient<ICategoryDisplay, CategoryDisplayService>();
            #endregion
        }
    }

}
