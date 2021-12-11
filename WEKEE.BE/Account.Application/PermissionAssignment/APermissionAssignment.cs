
using Account.Domain.BoundedContext;
using Account.Domain.Dto;
using Account.Domain.ObjectValues;
using Account.Domain.ObjectValues.Enum;
using Account.Infrastructure.ModelQuery;
using System;
using System.Collections.Generic;
using System.Text;
using Utils.Exceptions;

namespace Account.Application.PermissionAssignment
{
    public class APermissionAssignment : IPermissionAssignment
    {
        private readonly PermissionAssignmentQuery permissionAssignmentQuery = new PermissionAssignmentQuery();
        PermissionQuery permissionQuery = new PermissionQuery();
        RoleQuery roleQuery = new RoleQuery();
        public PagedListOutput<PermissionAssignmentDto> PermissionAssignmentDto(int idRole, PagedListInput pagedListInput)
        {
            //lấy dữ liệu resource,
            var dataPermission = permissionQuery.GetAllListPage(pagedListInput);
            // lấy dữ liệu action
            var dataPermissionAssignment = permissionAssignmentQuery.ListPermissionAssignmentWithId(idRole);
            // map data
            return MapPagedListOutput.MapingpagedListOutput(permission: dataPermission, permissionAssignments: dataPermissionAssignment, roleId: idRole);
        }

        public void UpdateOrInsert(PermissionAssignmentDto permissionAssignmentDto)
        {
            // kieemr tra 
            if (roleQuery.CountId(permissionAssignmentDto.RoleId) != 1)
            {
                throw new ClientException(400, "Role already exists!");
            }

            if (permissionQuery.CountId(permissionAssignmentDto.Id) != 1)
            {
                throw new ClientException(400, "Permission already exists!");
            }

            var dataResourceAction = permissionAssignmentQuery.CheckExistsUnique(permissionId: permissionAssignmentDto.Id, roleId: permissionAssignmentDto.RoleId);
            if (dataResourceAction == null)
            {
                permissionAssignmentQuery.Insert(new Domain.Entitys.PermissionAssignment
                {
                    RoleId = permissionAssignmentDto.RoleId,
                    PermissionId = permissionAssignmentDto.Id,
                    IsActive = true
                });
            }
            else
            {
                dataResourceAction.IsActive = !dataResourceAction.IsActive;

                permissionAssignmentQuery.Update(dataResourceAction);
            }
        }
    }
}
