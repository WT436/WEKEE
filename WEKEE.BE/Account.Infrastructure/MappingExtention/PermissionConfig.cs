using Account.Domain.Shared.DataTransfer.AtomicDTO;
using Account.Domain.Shared.DataTransfer.PermisionDTO;
using Account.Domain.Shared.DataTransfer.ResourceDTO;
using Account.Domain.Shared.DataTransfer.RoleDTO;
using Account.Domain.Shared.DataTransfer.SubjectDTO;
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
            #region AtomicReadDto <=> AtomicReadDto
            cfg.CreateMap<AtomicReadDto, AtomicReadDto>();
            #endregion
            #region AtomicReadDto <=> Atomic
            cfg.CreateMap<Atomic, AtomicReadDto>();
            cfg.CreateMap<AtomicReadDto, Atomic>();
            #endregion
            #region RoleReadDto <=> Role
            cfg.CreateMap<Role, RoleReadDto>();
            cfg.CreateMap<RoleReadDto, Role>();
            #endregion
            #region SubjectReadDto <=> Subject
            cfg.CreateMap<Subject, SubjectReadDto>();
            cfg.CreateMap<SubjectReadDto, Subject>();
            #endregion
            #region FtPermissionReadDto <=> ResourceReadDto
            cfg.CreateMap<ResourceReadDto, FtPermissionReadDto>();
            cfg.CreateMap<FtPermissionReadDto, ResourceReadDto>();
            #endregion
            #region FtPermissionReadDto <=> ResourceReadDto
            cfg.CreateMap<PermissionReadDto, PermissionFtRoleReadDto>();
            cfg.CreateMap<PermissionFtRoleReadDto, PermissionReadDto>();
            #endregion
        }
    }
}
