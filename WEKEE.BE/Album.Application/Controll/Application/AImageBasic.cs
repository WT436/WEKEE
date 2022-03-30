using Album.Application.Interface;
using Album.Domain.BoundedContext;
using Album.Domain.Shared.DataTransfer;
using Album.Domain.ObjectValues;
using Album.Application.Infrastructure.ImageProcess;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Album.Application.Application
{
    public class AImageBasic : IImageBasic
    {
        public async Task<string> SaveAvatarServer(InputFileImageBases files)
        {
            // kiem tra image
            var image = await OpenImage.ConvertIFormFileToBitmap(file: files.Files[0]);
            SaveFile.SaveImage(
                               bitmap: (Bitmap)ResizeImage.ResizeKeepStruct(data: new ResizeImageDto
                               {
                                   Image = image,
                                   ListSizeImages = ConfigSizeImage.ReturnSizeDefault(Domain.ObjectValues.SizeImage.S180x180),
                                   Quality = ConfigImaging.Low
                               }),
                               name: Path.GetFileName(files.Files[0].FileName),
                               folderSave: FolderSaveExtensions.FolderSave.AVATAR,
                               formatImage: Domain.ObjectValues.FormatImage.JPEG_JPG,
                               sizeImages: Domain.ObjectValues.SizeImage.S180x180);

            SaveFile.SaveImage(
                               bitmap: (Bitmap)ResizeImage.ResizeKeepStruct(data: new ResizeImageDto
                               {
                                   Image = image,
                                   ListSizeImages = ConfigSizeImage.ReturnSizeDefault(Domain.ObjectValues.SizeImage.S300x300),
                                   Quality = ConfigImaging.Low
                               }),
                               name: files.Files[0].FileName,
                               folderSave: FolderSaveExtensions.FolderSave.AVATAR,
                               formatImage: Domain.ObjectValues.FormatImage.JPEG_JPG,
                               sizeImages: Domain.ObjectValues.SizeImage.S300x300);

            SaveFile.SaveImage(
                               bitmap: (Bitmap)ResizeImage.ResizeKeepStruct(data: new ResizeImageDto
                               {
                                   Image = image,
                                   ListSizeImages = ConfigSizeImage.ReturnSizeDefault(Domain.ObjectValues.SizeImage.S600x800),
                                   Quality = ConfigImaging.Low
                               }),
                               name: files.Files[0].FileName,
                               folderSave: FolderSaveExtensions.FolderSave.AVATAR,
                               formatImage: Domain.ObjectValues.FormatImage.JPEG_JPG,
                               sizeImages: Domain.ObjectValues.SizeImage.S600x800);

            return SaveFile.SaveImage(
                          bitmap: (Bitmap)ResizeImage.ResizeKeepStruct(data: new ResizeImageDto
                          {
                              Image = image,
                              ListSizeImages = ConfigSizeImage.ReturnSizeDefault(Domain.ObjectValues.SizeImage.S120x120),
                              Quality = ConfigImaging.Low
                          }),
                          name: files.Files[0].FileName,
                          folderSave: FolderSaveExtensions.FolderSave.AVATAR,
                          formatImage: Domain.ObjectValues.FormatImage.JPEG_JPG,
                          sizeImages: Domain.ObjectValues.SizeImage.S120x120);
        }

        public async Task<string> SaveAvatarServer(IFormFile files)
        {
            var image = await OpenImage.ConvertIFormFileToBitmap(file: files);
            return SaveFile.SaveImage(
                         bitmap: (Bitmap)ResizeImage.ResizeKeepStruct(data: new ResizeImageDto
                         {
                             Image = image,
                             ListSizeImages = ConfigSizeImage.ReturnSizeDefault(Domain.ObjectValues.SizeImage.S120x120),
                             Quality = ConfigImaging.Low
                         }),
                         name: Path.GetFileName(files.FileName),
                         folderSave: FolderSaveExtensions.FolderSave.AVATAR,
                         formatImage: Domain.ObjectValues.FormatImage.JPEG_JPG,
                         sizeImages: Domain.ObjectValues.SizeImage.S120x120);
        }

        public async Task<string> SaveIconServer(IFormFile files)
        {
            var image = await OpenImage.ConvertIFormFileToBitmap(file: files);

            return SaveFile.SaveImage(
                         bitmap: (Bitmap)ResizeImage.ResizeNotKeepStruct(data: new ResizeImageDto
                         {
                             Image = image,
                             ListSizeImages = ConfigSizeImage.ReturnSizeDefault(Domain.ObjectValues.SizeImage.S120x120),
                             Quality = ConfigImaging.Low
                         }),
                         name: Path.GetFileName(files.FileName),
                         folderSave: FolderSaveExtensions.FolderSave.ICON,
                         formatImage: FormatImage.JPEG_JPG,
                         sizeImages: Domain.ObjectValues.SizeImage.S120x120);
        }

        public async Task<string> SaveProductServer(IFormFile files)
        {
            var image = await OpenImage.ConvertIFormFileToBitmap(file: files);
            return SaveFile.SaveImage(
                         bitmap: (Bitmap)ResizeImage.ResizeNotKeepStruct(data: new ResizeImageDto
                         {
                             Image = image,
                             ListSizeImages = ConfigSizeImage.ReturnSizeDefault(Domain.ObjectValues.SizeImage.S120x120),
                             Quality = ConfigImaging.Low
                         }),
                         name: Path.GetFileName(files.FileName),
                         folderSave: FolderSaveExtensions.FolderSave.PRODUCT,
                         formatImage: FormatImage.JPEG_JPG,
                         sizeImages: Domain.ObjectValues.SizeImage.S120x120);
        }

        public async Task<string> SavePostServer(IFormFile files)
        {
            var image = await OpenImage.ConvertIFormFileToBitmap(file: files);
            return SaveFile.SaveImage(
                         bitmap: image,
                         name: Path.GetFileName(files.FileName),
                         folderSave: FolderSaveExtensions.FolderSave.POST);
        }

        public async Task<string> SaveRootServer(IFormFile files)
        {
            var image = await OpenImage.ConvertIFormFileToBitmap(file: files);

            return SaveFile.SaveImage(
                         bitmap: image,
                         name: Path.GetFileName(files.FileName),
                         folderSave: FolderSaveExtensions.FolderSave.ROOT_IMAGE);
        }

        public Task<string> SaveRootEvaluates(List<IFormFile> formFiles)
        {
            throw new System.NotImplementedException();
        }

        public async Task<string> SaveRootCategoryProduct(IFormFile files)
        {
            var image = await OpenImage.ConvertIFormFileToBitmap(file: files);
            return SaveFile.SaveImage(
                         bitmap: (Bitmap)ResizeImage.ResizeNotKeepStruct(data: new ResizeImageDto
                         {
                             Image = image,
                             ListSizeImages = ConfigSizeImage.ReturnSizeDefault(Domain.ObjectValues.SizeImage.S80x80),
                             Quality = ConfigImaging.Low
                         }),
                         name: Path.GetFileName(files.FileName),
                         folderSave: FolderSaveExtensions.FolderSave.ICON,
                         formatImage: FormatImage.JPEG_JPG,
                         sizeImages: Domain.ObjectValues.SizeImage.S80x80);
        }
    }
}
