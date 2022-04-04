using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Album.Application.Domain.Shared.DataTransfer;
using Album.Application.Domain.ObjectValues;

namespace Album.Application.Controll.Interface
{
    public interface IImageBasic
    {
        Task<string> SaveAvatarServer(InputFileImageBases files);
        Task<string> SavePostServer(IFormFile files);
        Task<string> SaveAvatarServer(IFormFile files);
        Task<string> SaveIconServer(IFormFile files);
        Task<List<ImageProductProcessDto>> SaveProductServer(List<string> files);
        Task<string> SaveRootServer(IFormFile files);
        Task<string> SaveRootEvaluates(List<IFormFile> formFiles);
        Task<string> SaveRootCategoryProduct(IFormFile files);

        /// <summary>
        /// Lưu ảnh tải lên trong trạng thái chờ
        /// </summary>
        Task<string> SaveAwaitImageProduct(IFormFile files);
    }
}
