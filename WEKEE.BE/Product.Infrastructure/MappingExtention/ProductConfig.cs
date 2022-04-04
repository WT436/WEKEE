using AutoMapper;
using Product.Domain.Shared.DataTransfer.ProductDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Infrastructure.MappingExtention
{
    public class ProductConfig
    {
        public static void CreateMap(IMapperConfigurationExpression cfg)
        {
            #region ProductInsertDto <=> Domain.Shared.Entitys.Product
            cfg.CreateMap<ProductInsertDto, Domain.Shared.Entitys.Product>();
            cfg.CreateMap<Domain.Shared.Entitys.Product, ProductInsertDto>();
            #endregion
        }
    }
}
