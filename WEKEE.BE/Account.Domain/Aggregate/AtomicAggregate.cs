using Account.Domain.Shared.DataTransfer.AtomicDTO;
using Account.Domain.Shared.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Aggregate
{
    public class AtomicAggregate
    {
        public Atomic MapData(AtomicReadDto input, int idAccount)
        {
            var data = new Atomic
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
