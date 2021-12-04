using Account.Application.Interface;
using Account.Domain.Dto;
using Account.Infrastructure.MappingExtention;
using Account.Infrastructure.ModelQuery;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.Application
{
    public class Atomic : IAtomic
    {
        private readonly AtomicQuery atomicQuery = new AtomicQuery();
        private readonly ActionQuery actionQuery = new ActionQuery();
        public List<AtomicDto> GetAll()
        {
            List<AtomicDto> atomicDtos = new List<AtomicDto>();
            var data = atomicQuery.GetAll();

            if (data != null || data.Count > 0)
            {
                foreach (var item in data)
                {
                    var itemdata = actionQuery.CountAtomic(item.Id);
                    var atomicDto = MappingData.InitializeAutomapper().Map<AtomicDto>(item);
                    atomicDto.Count = itemdata;
                    atomicDtos.Add(atomicDto);
                }
            }
            return atomicDtos;
        }

        public Task<List<AtomicDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
