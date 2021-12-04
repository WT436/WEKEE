using Account.Domain.Dto;
using Account.Domain.Entitys;
using AutoMapper;

namespace Account.Infrastructure.MappingExtention
{
    public class PermissionConfig
    {
        public static void CreateMap(IMapperConfigurationExpression cfg)
        {
            // config chuyển đổi từ Resource <=> ResourceDto
            cfg.CreateMap<Resource, ResourceDto>();
            cfg.CreateMap<ResourceDto, Resource>();
            // config chuyển đổi từ Resource <=> ResourceActionDto
            cfg.CreateMap<Resource, ResourceActionDto>();
            cfg.CreateMap<ResourceActionDto, Resource>();
            //config chuyển đổi từ Atomic <=> AtomicDto
            cfg.CreateMap<Atomic, AtomicDto>();
            cfg.CreateMap<AtomicDto, Atomic>();
            //config chuyển đổi từ Action <=> ActionDto
            cfg.CreateMap<Action, ActionDto>();
            cfg.CreateMap<ActionDto, Action>();
            //config chuyển đổi từ Action <=> ActionDto
            cfg.CreateMap<ActionDto, ActionAssignmentDto>();
            cfg.CreateMap<ActionAssignmentDto, ActionDto>();
            //config chuyển đổi từ Permission <=>PermissionDto
            cfg.CreateMap<Permission, PermissionDto>();
            cfg.CreateMap<PermissionDto, Permission>();
            //config chuyển đổi từ Permission <=>PermissionDto
            cfg.CreateMap<Permission, PermissionAssignmentDto>();
            cfg.CreateMap<PermissionAssignmentDto, Permission>();
            //config chuyển đổi từ Role <=>RoleDto
            cfg.CreateMap<Role, RoleDto>();
            cfg.CreateMap<RoleDto, Role>();
            //config chuyển đổi từ Role <=>RoleDto
            cfg.CreateMap<Role, SubjectAssignmentDto>();
            cfg.CreateMap<SubjectAssignmentDto, Role>();
            //config chuyển đổi từ Role <=>RoleDto
            cfg.CreateMap<Subject, SubjectDtos>();
            cfg.CreateMap<SubjectDtos, Subject>();
        }
    }
}
