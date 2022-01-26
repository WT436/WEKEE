using Account.Domain.Shared.DataTransfer;
using Account.Domain.Shared.Entitys;
using Account.Domain.ObjectValues.Output;
using Account.Infrastructure.MappingExtention;
using System.Collections.Generic;
using System.Linq;
using UnitOfWork.Collections;

namespace Account.Infrastructure.BoundedContext
{
    public static class MapPagedListOutput
    {
        public static PagedListOutput<AtomicDto> MapingpagedListOutput(IPagedList<Atomic> listData)
        {
            return new PagedListOutput<AtomicDto>
            {
                Items = listData.Items.Select(emp => MappingData.InitializeAutomapper()
                                                                .Map<AtomicDto>(emp)).ToList(),
                PageIndex = listData.PageIndex,
                PageSize = listData.PageSize,
                TotalCount = listData.TotalCount,
                TotalPages = listData.TotalPages
            };
        }

        public static PagedListOutput<ActionDto> MapingpagedListOutput(IPagedList<Action> listData)
        {
            return new PagedListOutput<ActionDto>
            {
                Items = listData.Items.Select(emp => MappingData.InitializeAutomapper()
                                                                .Map<ActionDto>(emp)).ToList(),
                PageIndex = listData.PageIndex,
                PageSize = listData.PageSize,
                TotalCount = listData.TotalCount,
                TotalPages = listData.TotalPages
            };
        }

        public static PagedListOutput<PermissionDto> MapingpagedListOutput(IPagedList<Permission> listData)
        {
            return new PagedListOutput<PermissionDto>
            {
                Items = listData.Items.Select(emp => MappingData.InitializeAutomapper()
                                                                .Map<PermissionDto>(emp)).ToList(),
                PageIndex = listData.PageIndex,
                PageSize = listData.PageSize,
                TotalCount = listData.TotalCount,
                TotalPages = listData.TotalPages
            };
        }

        public static PagedListOutput<ActionAssignmentDto> MapingpagedListOutput(PagedListOutput<ActionDto> action,
                                                                                 List<ActionAssignment> actionAssignments,
                                                                                 int permissionId)
        {
            List<ActionAssignmentDto> resourceActionDtos = new List<ActionAssignmentDto>();

            foreach (var item in action.Items)
            {
                var dto = MappingData.InitializeAutomapper().Map<ActionAssignmentDto>(item);
                dto.IsCheck = actionAssignments.Any(m => m.ActionId == item.Id);
                dto.PermissionId = permissionId;
                resourceActionDtos.Add(dto);
            }

            return new PagedListOutput<ActionAssignmentDto>
            {
                Items = resourceActionDtos,
                PageIndex = action.PageIndex,
                PageSize = action.PageSize,
                TotalCount = action.TotalCount,
                TotalPages = action.TotalPages
            };
        }

        public static PagedListOutput<PermissionAssignmentDto> MapingpagedListOutput(IPagedList<Permission> permission,
                                                                                 List<PermissionAssignment> permissionAssignments,
                                                                                 int roleId)
        {
            List<PermissionAssignmentDto> resourceActionDtos = new List<PermissionAssignmentDto>();

            foreach (var item in permission.Items)
            {
                var dto = MappingData.InitializeAutomapper().Map<PermissionAssignmentDto>(item);
                dto.IsCheck = permissionAssignments.Any(m => m.PermissionId == item.Id);
                dto.RoleId = roleId;
                resourceActionDtos.Add(dto);
            }

            return new PagedListOutput<PermissionAssignmentDto>
            {
                Items = resourceActionDtos,
                PageIndex = permission.PageIndex,
                PageSize = permission.PageSize,
                TotalCount = permission.TotalCount,
                TotalPages = permission.TotalPages
            };
        }

        public static List<SubjectAssignmentDto> MapingpagedListOutput(List<SubjectAssignment> subjectAssignments,
                                                                                     List<Role> roles
                                                                                     )
        {
            List<SubjectAssignmentDto> resourceActionDtos = new List<SubjectAssignmentDto>();

            foreach (var item in roles)
            {
                var dto = MappingData.InitializeAutomapper().Map<SubjectAssignmentDto>(item);
                dto.IsCheck = subjectAssignments.Any(m => m.RoleId == item.Id) && subjectAssignments.Any(m=>m.IsActive==true);
                resourceActionDtos.Add(dto);
            }
            return resourceActionDtos;
        }

    }
}
