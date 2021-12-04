using Album.Application.Interface;
using Album.Domain.BoundedContext;
using Album.Domain.Dtos;
using Album.Domain.ObjectValues;
using Album.Infrastructure.ImageProcess;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

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
                               folderSave: FolderSave.avatar,
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
                               folderSave: FolderSave.avatar,
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
                               folderSave: FolderSave.avatar,
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
                          folderSave: FolderSave.avatar,
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
                         folderSave: FolderSave.avatar,
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
                         folderSave: FolderSave.icon,
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
                         folderSave: FolderSave.product,
                         formatImage: FormatImage.JPEG_JPG,
                         sizeImages: Domain.ObjectValues.SizeImage.S120x120);
        }

        public async Task<string> SavePostServer(IFormFile files)
        {
            var image = await OpenImage.ConvertIFormFileToBitmap(file: files);
            return SaveFile.SaveImage(
                         bitmap: image,
                         name: Path.GetFileName(files.FileName),
                         folderSave: FolderSave.post);
        }

        public async Task<string> SaveRootServer(IFormFile files)
        {
            var image = await OpenImage.ConvertIFormFileToBitmap(file: files);
            return SaveFile.SaveImage(
                         bitmap: image,
                         name: Path.GetFileName(files.FileName),
                         folderSave: FolderSave.rootImage);
        }

        public Task<string> SaveRootEvaluates(List<IFormFile> formFiles)
        {
            throw new System.NotImplementedException();
        }
    }
}
