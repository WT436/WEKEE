using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Infrastructure.MappingExtention
{
    public static class MappingData
    {
        public static IMapper InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                EvaluatesConfig.CreateMap(cfg);
            });
            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}
