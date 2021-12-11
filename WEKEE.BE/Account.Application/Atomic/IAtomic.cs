using System.Collections.Generic;
using System.Threading.Tasks;
using Account.Domain.Dto;
using Account.Domain.ObjectValues;

namespace Account.Application.Atomic
{
    public interface IAtomic
    {
        List<AtomicDto> GetAll();
        Task<List<AtomicDto>> GetAllAsync();
        Task<bool> Insert(AtomicDto atomicDto);
        Task<int> Insert(List<AtomicDto> atomicDto);
    }
}
