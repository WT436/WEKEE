using Album.Application.Infrastructure.ImageProcess;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Album.Application.Domain.Shared.DataTransfer;
using Album.Application.Controll.Interface;
using Album.Application.Domain.ObjectValues;
using Album.Application.Domain.BoundedContext;

namespace Album.Application.Controll.Application
{
    public class ImageBasicService : IImageBasic
    {
        public async Task<string> SaveAvatarServer(InputFileImageBases files)
        {
            // kiem tra image
            var image = await OpenImage.ConvertIFormFileToBitmap(file: files.Files[0]);
            SaveFile.SaveImage(
                               bitmap: (Bitmap)ResizeImage.ResizeKeepStruct(data: new ResizeImageDto
                               {
                                   Image = image,
                                   ListSizeImages = ConfigSizeImage.ReturnSizeDefault(SizeImage.S180x180),
                                   Quality = ConfigImaging.Low
                               }),
                               name: Path.GetFileName(files.Files[0].FileName),
                               folderSave: FolderSaveExtensions.FolderSave.AVATAR,
                               formatImage: FormatImage.JPEG_JPG,
                               sizeImages: SizeImage.S180x180);

            SaveFile.SaveImage(
                               bitmap: (Bitmap)ResizeImage.ResizeKeepStruct(data: new ResizeImageDto
                               {
                                   Image = image,
                                   ListSizeImages = ConfigSizeImage.ReturnSizeDefault(SizeImage.S300x300),
                                   Quality = ConfigImaging.Low
                               }),
                               name: files.Files[0].FileName,
                               folderSave: FolderSaveExtensions.FolderSave.AVATAR,
                               formatImage: FormatImage.JPEG_JPG,
                               sizeImages: SizeImage.S300x300);

            SaveFile.SaveImage(
                               bitmap: (Bitmap)ResizeImage.ResizeKeepStruct(data: new ResizeImageDto
                               {
                                   Image = image,
                                   ListSizeImages = ConfigSizeImage.ReturnSizeDefault(SizeImage.S600x800),
                                   Quality = ConfigImaging.Low
                               }),
                               name: files.Files[0].FileName,
                               folderSave: FolderSaveExtensions.FolderSave.AVATAR,
                               formatImage: FormatImage.JPEG_JPG,
                               sizeImages: SizeImage.S600x800);

            return SaveFile.SaveImage(
                          bitmap: (Bitmap)ResizeImage.ResizeKeepStruct(data: new ResizeImageDto
                          {
                              Image = image,
                              ListSizeImages = ConfigSizeImage.ReturnSizeDefault(SizeImage.S120x120),
                              Quality = ConfigImaging.Low
                          }),
                          name: files.Files[0].FileName,
                          folderSave: FolderSaveExtensions.FolderSave.AVATAR,
                          formatImage: FormatImage.JPEG_JPG,
                          sizeImages: SizeImage.S120x120);
        }

        public async Task<string> SaveAvatarServer(IFormFile files)
        {
            var image = await OpenImage.ConvertIFormFileToBitmap(file: files);
            return SaveFile.SaveImage(
                         bitmap: (Bitmap)ResizeImage.ResizeKeepStruct(data: new ResizeImageDto
                         {
                             Image = image,
                             ListSizeImages = ConfigSizeImage.ReturnSizeDefault(SizeImage.S120x120),
                             Quality = ConfigImaging.Low
                         }),
                         name: Path.GetFileName(files.FileName),
                         folderSave: FolderSaveExtensions.FolderSave.AVATAR,
                         formatImage: FormatImage.JPEG_JPG,
                         sizeImages: SizeImage.S120x120);
        }

        public async Task<string> SaveIconServer(IFormFile files)
        {
            var image = await OpenImage.ConvertIFormFileToBitmap(file: files);

            return SaveFile.SaveImage(
                         bitmap: (Bitmap)ResizeImage.ResizeNotKeepStruct(data: new ResizeImageDto
                         {
                             Image = image,
                             ListSizeImages = ConfigSizeImage.ReturnSizeDefault(SizeImage.S120x120),
                             Quality = ConfigImaging.Low
                         }),
                         name: Path.GetFileName(files.FileName),
                         folderSave: FolderSaveExtensions.FolderSave.ICON,
                         formatImage: FormatImage.JPEG_JPG,
                         sizeImages: SizeImage.S120x120);
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
                             ListSizeImages = ConfigSizeImage.ReturnSizeDefault(SizeImage.S80x80),
                             Quality = ConfigImaging.Low
                         }),
                         name: Path.GetFileName(files.FileName),
                         folderSave: FolderSaveExtensions.FolderSave.ICON,
                         formatImage: FormatImage.JPEG_JPG,
                         sizeImages: SizeImage.S80x80);
        }

        public async Task<string> SaveAwaitImageProduct(IFormFile files)
        {
            var image = await OpenImage.ConvertIFormFileToBitmap(file: files);
            return SaveFile.SaveImage(
                         bitmap: image,
                         name: Path.GetFileName(files.FileName),
                         folderSave: FolderSaveExtensions.FolderSave.AWAIT,
                         formatImage: FormatImage.JPEG_JPG);
        }

        public async Task<List<ImageProductProcessDto>> SaveProductServer(List<string> files)
        {
            var retu = new List<ImageProductProcessDto>();

            if (files.Count > 0)
            {
                foreach (var file in files)
                {
                    if (string.IsNullOrEmpty(file)) continue;
                    var image = OpenImage.ConvertIFormFileToBitmap(file, FolderSaveExtensions.FolderSave.AWAIT);
                    if (image != null)
                    {
                        retu.Add(new ImageProductProcessDto
                        {
                            NameUpload = file,
                            ImageNameRoot = SaveFile.SaveImage(
                                                             bitmap:image,
                                                             name: Path.GetFileName(file),
                                                             folderSave: FolderSaveExtensions.FolderSave.PRODUCT,
                                                             formatImage: FormatImage.JPEG_JPG),
                            ImageNameSizeS120x120 = SaveFile.SaveImage(
                                                             bitmap: ResizeImage.ResizeKeepStruct(data: new ResizeImageDto
                                                             {
                                                                 Image = image,
                                                                 ListSizeImages = ConfigSizeImage.ReturnSizeDefault(SizeImage.S120x120),
                                                                 Quality = ConfigImaging.Low
                                                             }) as Bitmap,
                                                             name: Path.GetFileName(file),
                                                             folderSave: FolderSaveExtensions.FolderSave.PRODUCT,
                                                             formatImage: FormatImage.JPEG_JPG,
                                                             sizeImages: SizeImage.S120x120),
                            ImageNameSizeS1360x540 = SaveFile.SaveImage(
                                                             bitmap: ResizeImage.ResizeKeepStruct(data: new ResizeImageDto
                                                             {
                                                                 Image = image,
                                                                 ListSizeImages = ConfigSizeImage.ReturnSizeDefault(SizeImage.S1360x540),
                                                                 Quality = ConfigImaging.Low
                                                             }) as Bitmap,
                                                             name: Path.GetFileName(file),
                                                             folderSave: FolderSaveExtensions.FolderSave.PRODUCT,
                                                             formatImage: FormatImage.JPEG_JPG,
                                                             sizeImages: SizeImage.S1360x540),
                            ImageNameSizeS180x180 = SaveFile.SaveImage(
                                                             bitmap: ResizeImage.ResizeKeepStruct(data: new ResizeImageDto
                                                             {
                                                                 Image = image,
                                                                 ListSizeImages = ConfigSizeImage.ReturnSizeDefault(SizeImage.S180x180),
                                                                 Quality = ConfigImaging.Low
                                                             }) as Bitmap,
                                                             name: Path.GetFileName(file),
                                                             folderSave: FolderSaveExtensions.FolderSave.PRODUCT,
                                                             formatImage: FormatImage.JPEG_JPG,
                                                             sizeImages: SizeImage.S180x180),
                            ImageNameSizeS220x220 = SaveFile.SaveImage(
                                                             bitmap: ResizeImage.ResizeKeepStruct(data: new ResizeImageDto
                                                             {
                                                                 Image = image,
                                                                 ListSizeImages = ConfigSizeImage.ReturnSizeDefault(SizeImage.S220x220),
                                                                 Quality = ConfigImaging.Low
                                                             }) as Bitmap,
                                                             name: Path.GetFileName(file),
                                                             folderSave: FolderSaveExtensions.FolderSave.PRODUCT,
                                                             formatImage: FormatImage.JPEG_JPG,
                                                             sizeImages: SizeImage.S220x220),
                            ImageNameSizeS340x340 = SaveFile.SaveImage(
                                                             bitmap: ResizeImage.ResizeKeepStruct(data: new ResizeImageDto
                                                             {
                                                                 Image = image,
                                                                 ListSizeImages = ConfigSizeImage.ReturnSizeDefault(SizeImage.S340x340),
                                                                 Quality = ConfigImaging.Low
                                                             }) as Bitmap,
                                                             name: Path.GetFileName(file),
                                                             folderSave: FolderSaveExtensions.FolderSave.PRODUCT,
                                                             formatImage: FormatImage.JPEG_JPG,
                                                             sizeImages: SizeImage.S340x340),
                            ImageNameSizeS80x80 = SaveFile.SaveImage(
                                                             bitmap: ResizeImage.ResizeKeepStruct(data: new ResizeImageDto
                                                             {
                                                                 Image = image,
                                                                 ListSizeImages = ConfigSizeImage.ReturnSizeDefault(SizeImage.S80x80),
                                                                 Quality = ConfigImaging.Low
                                                             }) as Bitmap,
                                                             name: Path.GetFileName(file),
                                                             folderSave: FolderSaveExtensions.FolderSave.PRODUCT,
                                                             formatImage: FormatImage.JPEG_JPG,
                                                             sizeImages: SizeImage.S80x80)
                        });
                    }
                    else
                    {
                        retu.Add(new ImageProductProcessDto { ImageNameRoot = file });
                    }
                }
            }
            return retu;
        }
    }
}
