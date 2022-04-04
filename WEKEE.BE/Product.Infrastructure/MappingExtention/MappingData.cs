using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Infrastructure.MappingExtention
{
    public static class MappingData
    {
        public static IMapper InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                ProductConfig.CreateMap(cfg);
            });
            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}
