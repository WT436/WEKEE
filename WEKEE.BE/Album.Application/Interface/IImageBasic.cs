using Album.Domain.Dtos;
using Album.Domain.ObjectValues;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Album.Application.Interface
{
    public interface IImageBasic
    {
        Task<string> SaveAvatarServer(InputFileImageBases files);
        Task<string> SavePostServer(IFormFile files);
        Task<string> SaveAvatarServer(IFormFile files);
        Task<string> SaveIconServer(IFormFile files);
        Task<string> SaveProductServer(IFormFile files);
        Task<string> SaveRootServer(IFormFile files);
        Task<string> SaveRootEvaluates(List<IFormFile> formFiles);
        Task<string> SaveRootCategoryProduct(IFormFile files);
    }
}
