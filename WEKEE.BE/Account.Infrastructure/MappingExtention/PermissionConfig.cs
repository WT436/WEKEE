using Account.Domain.ObjectValues.ConstProperty;
using Account.Domain.Shared.DataTransfer.ResourceDTO;
using Account.Domain.Shared.Entitys;
using AutoMapper;

namespace Account.Infrastructure.MappingExtention
{
    public class PermissionConfig
    {
        public static void CreateMap(IMapperConfigurationExpression cfg)
        {
            #region ResourceReadDto <=> ResourceReadDto
            cfg.CreateMap<ResourceReadDto, ResourceReadDto>();
            #endregion
            #region ResourceReadDto <=> Resource
            cfg.CreateMap<Resource, ResourceReadDto>();
            cfg.CreateMap<ResourceReadDto, Resource>();
            #endregion
        }
    }
}
