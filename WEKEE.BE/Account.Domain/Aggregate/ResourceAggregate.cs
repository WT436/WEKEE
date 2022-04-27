using Account.Domain.Shared.DataTransfer.ResourceDTO;
using Account.Domain.Shared.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Aggregate
{
    public class ResourceAggregate
    {
        public Resource MapData(ResourceReadDto input, int idAccount)
        {
            var data = new Resource
            {
                Id = input.Id,
                Name = input.Name,
                Description = input.Description,
                CreateBy = idAccount,
                IsActive = input.IsActive,
                TypesRsc = input.TypesRsc,
                UpdatedOnUtc = DateTime.Now
            };
            return data;
        }
    }
}
