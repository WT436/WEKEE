using Account.Domain.Shared.DataTransfer.PermisionDTO;
using Account.Domain.Shared.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Aggregate
{
    public class PermissionAggregate
    {
        public Permission MapData(PermissionReadDto input, int idAccount)
        {
            var data = new Permission
            {
                Id = input.Id,
                Name = input.Name,
                Description = input.Description,
                CreateBy = idAccount,
                IsActive = input.IsActive,
                AtomicId = input.AtomicId,
                LevelPermition = input.LevelPermition,
                PermissionId = input.PermissionId,
                UpdatedOnUtc = DateTime.Now
            };
            return data;
        }
    }
}
