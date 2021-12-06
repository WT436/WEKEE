using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace System.Infrastructure.MappingExtention
{
    public static  class MappingData
    {
        public static IMapper InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                ErrorServerConfig.CreateMap(cfg);
            });
            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}
