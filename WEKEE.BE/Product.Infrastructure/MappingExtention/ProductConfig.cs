using AutoMapper;
using Product.Domain.ObjectValues.ConstProperty;
using Product.Domain.Shared.DataTransfer.CategoryHomePageDTO;
using Product.Domain.Shared.DataTransfer.CategoryProductDTO;
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
            #region CategoryHomePageReadDto <=> CategoryProductReadDto
            cfg.CreateMap<CategoryHomePageReadDto, CategoryProductReadDto>();
            cfg.CreateMap<CategoryProductReadDto, CategoryHomePageReadDto>()
               .ForMember(
                        dest => dest.IsComponent,
                        opt => opt.MapFrom(src => ConvertPropertyCategoryHomePage.CONVERT_TYPE_ISCOMPONENT_ENUM_TEXT(0))
                        );
            #endregion
        }
    }
}
