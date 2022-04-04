using Album.Application.Controll.Application;
using Album.Application.Controll.Interface;
using Product.Domain.Shared.DataTransfer.ImageProductDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Product.Infrastructure.EventBus
{
    public class ImageProcessBus
    {
        private readonly IImageBasic _imageBasic = new ImageBasicService();

        public async Task<List<ImageProductProcessDto>> ImageProcessRabbitMQ(List<string> input)
        {
            var data = await _imageBasic.SaveProductServer(input);
            return data.ToList().Select(m => new ImageProductProcessDto
            {
                NameUpload = m.NameUpload,
                ImageNameRoot = m.ImageNameRoot,
                ImageNameSizeS120x120 = m.ImageNameSizeS120x120,
                ImageNameSizeS1360x540 = m.ImageNameSizeS1360x540,
                ImageNameSizeS180x180 = m.ImageNameSizeS180x180,
                ImageNameSizeS80x80 = m.ImageNameSizeS80x80,
                ImageNameSizeS220x220 = m.ImageNameSizeS220x220,
                ImageNameSizeS340x340 = m.ImageNameSizeS340x340,
            }).ToList();
        }
    }
}
