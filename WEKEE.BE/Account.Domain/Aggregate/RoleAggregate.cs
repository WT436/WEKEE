using Account.Domain.Shared.DataTransfer.RoleDTO;
using Account.Domain.Shared.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Aggregate
{
    public class RoleAggregate
    {
        public Role MapData(RoleReadDto input, int idAccount)
        {
            var data = new Role
            {
                Id = input.Id,
                Name = input.Name,
                Description = input.Description,
                CreateBy = idAccount,
                IsActive = input.IsActive,
                UpdatedOnUtc = DateTime.Now,
                LevelRole = input.LevelRole,
                RoleManageId = input.RoleManageId,
                IsDelete = input.IsDelete
            };
            return data;
        }
    }
}
