using Account.Domain.Shared.DataTransfer.SubjectDTO;
using Account.Domain.Shared.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Aggregate
{
    public class SubjectAggregate
    {
        public Subject MapData(SubjectReadDto input, int idAccount)
        {
            var data = new Subject
            {
                Id = input.Id,
                CreateBy = idAccount,
                UserId = input.UserId,
                GorupId = input.GorupId,
                IsActive = input.IsActive,
                UpdatedOnUtc = DateTime.Now
            };
            return data;
        }
    }
}
