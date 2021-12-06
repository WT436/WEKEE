using AutoMapper;
using Product.Domain.Dto;
using Product.Domain.Entitys;
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

                cfg.CreateMap<CategoryProduct, CategoryDto>();
                cfg.CreateMap<CategoryDto, CategoryProduct>();

                cfg.CreateMap<CategoryBreadcrumbDtos, CategoryProduct>();
                cfg.CreateMap<CategoryProduct, CategoryBreadcrumbDtos>();

                cfg.CreateMap<SpecificationsCategoryDtos, SpecificationsCategory>();
                cfg.CreateMap<SpecificationsCategory, SpecificationsCategoryDtos>();

                cfg.CreateMap<ImageProductCardDtos, ImageProduct>();
                cfg.CreateMap<ImageProduct, ImageProductCardDtos>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}
