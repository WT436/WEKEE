using AutoMapper;
using System;
using System.Collections.Generic;
using System.Domain.Dtos;
using System.Domain.Entitys;
using System.Text;

namespace System.Infrastructure.MappingExtention
{
    public class ErrorServerConfig
    {
        public static void CreateMap(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<ExceptionLog, ExceptionDtos>();
            cfg.CreateMap<ExceptionDtos, ExceptionLog>();
        }
    }
}
