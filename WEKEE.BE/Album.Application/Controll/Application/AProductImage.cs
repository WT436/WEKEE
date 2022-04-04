using Album.Application.Controll.Interface;
using Album.Application.Domain.BoundedContext;
using Album.Application.Domain.ObjectValues;
using Album.Application.Domain.Shared.DataTransfer;
using Album.Application.Infrastructure.ImageProcess;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Album.Application.Controll.Application
{

    public class AProductImage : IProductImage
    {
        public async Task<ProductDtos> SaveUrl(string url)
        {
            Image image = await OpenImage.OpenImageAsync(url);
            // vuông ảnh     
            var image1 = SquareImage.ConvertSquareImage(imageItem: image);
            // khai báo biến 
            return new ProductDtos
            {
                ImageRoot = url,
                Image220x220 = "",
                Image340x340 = SaveFile.SaveImage(
                                          bitmap: (Bitmap)ResizeImage.ResizeKeepStruct(data: new ResizeImageDto
                                          {
                                              Image = image1,
                                              ListSizeImages = ConfigSizeImage.ReturnSizeDefault(Domain.ObjectValues.SizeImage.S300x300),
                                              Quality = ConfigImaging.Low
                                          }),
                                          name: Path.GetFileName(url[url.LastIndexOf("album/rootImage/")..]),
                                          folderSave: FolderSaveExtensions.FolderSave.PRODUCT,
                                          formatImage: Domain.ObjectValues.FormatImage.JPEG_JPG,
                                          sizeImages: Domain.ObjectValues.SizeImage.S340x340),
                Image1360x1360 = SaveFile.SaveImage(
                                          bitmap: (Bitmap)ResizeImage.ResizeKeepStruct(data: new ResizeImageDto
                                          {
                                              Image = image1,
                                              ListSizeImages = ConfigSizeImage.ReturnSizeDefault(Domain.ObjectValues.SizeImage.S1360x540),
                                              Quality = ConfigImaging.Low
                                          }),
                                          name: Path.GetFileName(url[url.LastIndexOf("album/rootImage/")..]),
                                          folderSave: FolderSaveExtensions.FolderSave.PRODUCT,
                                          formatImage: Domain.ObjectValues.FormatImage.JPEG_JPG,
                                          sizeImages: Domain.ObjectValues.SizeImage.S1360x540),
                Image80x80 = SaveFile.SaveImage(
                                          bitmap: (Bitmap)ResizeImage.ResizeKeepStruct(data: new ResizeImageDto
                                          {
                                              Image = image1,
                                              ListSizeImages = ConfigSizeImage.ReturnSizeDefault(Domain.ObjectValues.SizeImage.S640x360),
                                              Quality = ConfigImaging.Low
                                          }),
                                          name: Path.GetFileName(url[url.LastIndexOf("album/rootImage/")..]),
                                          folderSave: FolderSaveExtensions.FolderSave.PRODUCT,
                                          formatImage: Domain.ObjectValues.FormatImage.JPEG_JPG,
                                          sizeImages: Domain.ObjectValues.SizeImage.S80x80),
            };
        }

        public async Task<ProductDtos> SaveUrl80And340(string url)
        {
            Image image = await OpenImage.OpenImageAsync(url);
            // vuông ảnh     
            var image1 = SquareImage.ConvertSquareImage(imageItem: image);
            // khai báo biến 
            return new ProductDtos
            {
                ImageRoot = url,
                Image220x220 = "",
                Image340x340 = SaveFile.SaveImage(
                                          bitmap: (Bitmap)ResizeImage.ResizeKeepStruct(data: new ResizeImageDto
                                          {
                                              Image = image1,
                                              ListSizeImages = ConfigSizeImage.ReturnSizeDefault(Domain.ObjectValues.SizeImage.S300x300),
                                              Quality = ConfigImaging.Low
                                          }),
                                          name: Path.GetFileName(url[url.LastIndexOf("album/rootImage/")..]),
                                          folderSave: FolderSaveExtensions.FolderSave.PRODUCT,
                                          formatImage: Domain.ObjectValues.FormatImage.JPEG_JPG,
                                          sizeImages: Domain.ObjectValues.SizeImage.S340x340),
                Image1360x1360 = "",
                Image80x80 = SaveFile.SaveImage(
                                          bitmap: (Bitmap)ResizeImage.ResizeKeepStruct(data: new ResizeImageDto
                                          {
                                              Image = image1,
                                              ListSizeImages = ConfigSizeImage.ReturnSizeDefault(Domain.ObjectValues.SizeImage.S640x360),
                                              Quality = ConfigImaging.Low
                                          }),
                                          name: Path.GetFileName(url[url.LastIndexOf("album/rootImage/")..]),
                                          folderSave: FolderSaveExtensions.FolderSave.PRODUCT,
                                          formatImage: Domain.ObjectValues.FormatImage.JPEG_JPG,
                                          sizeImages: Domain.ObjectValues.SizeImage.S80x80),
            };

        }

        public async Task<ProductDtos> SaveUrlCover(string url)
        {
            Image image = await OpenImage.OpenImageAsync(url);
            // vuông ảnh 
            var image1 = SquareImage.ConvertSquareImage(imageItem: image);
            return new ProductDtos
            {
                ImageRoot = url,
                Image220x220 = SaveFile.SaveImage(
                                        bitmap: (Bitmap)ResizeImage.ResizeKeepStruct(data: new ResizeImageDto
                                        {
                                            Image = image1,
                                            ListSizeImages = ConfigSizeImage.ReturnSizeDefault(Domain.ObjectValues.SizeImage.S220x220),
                                            Quality = ConfigImaging.Low
                                        }),
                                        name: Path.GetFileName(url[url.LastIndexOf("album/rootImage/")..]),
                                        folderSave: FolderSaveExtensions.FolderSave.PRODUCT,
                                        formatImage: Domain.ObjectValues.FormatImage.JPEG_JPG,
                                        sizeImages: Domain.ObjectValues.SizeImage.S220x220),
                Image1360x1360 = "",
                Image80x80 = "",
                Image340x340 = ""
            };
        }
    }
}
