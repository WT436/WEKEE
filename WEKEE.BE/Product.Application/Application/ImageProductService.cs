using Album.Application.Controll.Application;
using Album.Application.Controll.Interface;
using Product.Application.Interface;
using Product.Domain.Shared.Entitys;
using Product.Infrastructure.ModelQuery;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utils.Any;

namespace Product.Application.Application
{
    public class ImageProductService : IImageProduct
    {
        private readonly IReadInfoFile _readInfoFile = new ReadInfoFileService();
        private readonly ImageProductQuery _imageProduct = new ImageProductQuery();
        public async Task<int> InsertImageCategory(string path, string alt)
        {
            var data = _readInfoFile.ReadInfoImage(path);
            int dataret = _imageProduct.InsertImageProductOutId(new ImageProduct
            {
                IsCover = true,
                AltAttribute = alt,
                TitleAttribute = alt,
                MimeType = data.Extension,
                SeoFilename = LanguageConvert.ConvertVietNamese(alt),
                VirtualPath = path,
                Size = data.Length.ToString(),
                Folder = "icon"
            });
            return dataret;
        }

    }
}
