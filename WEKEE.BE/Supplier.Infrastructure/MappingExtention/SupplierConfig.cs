using AutoMapper;
using Supplier.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Supplier.Infrastructure.MappingExtention
{
    public class SupplierConfig
    {
        public static void CreateMap(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Domain.Entitys.Supplier, SupplierDtos>();
            cfg.CreateMap<SupplierDtos, Domain.Entitys.Supplier>();
        }
    }
}
