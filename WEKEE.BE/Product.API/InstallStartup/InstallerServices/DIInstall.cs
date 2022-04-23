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
