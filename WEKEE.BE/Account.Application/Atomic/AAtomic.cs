
using Account.Domain.BoundedContext;
using Account.Domain.Dto;
using Account.Domain.ObjectValues.Enum;
using Account.Infrastructure.MappingExtention;
using Account.Infrastructure.ModelQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Exceptions;

namespace Account.Application.Atomic
{
    public class AAtomic : IAtomic
    {
        private readonly AtomicQuery atomicQuery = new AtomicQuery();
        private readonly UserAccountQuery accountQuery = new UserAccountQuery();

        public async Task<PagedListOutput<AtomicDto>> ListAtomicBasicAsync(SearchOrderPageInput searchOrderPageInput)
        {
            var listData = await atomicQuery.GetAllListPageAsync(searchOrderPageInput);
            return MapPagedListOutput.MapingpagedListOutput(listData);
        }

        public async Task<int> InsertAtomicAsync(AtomicDto atomic)
        {
            if (atomic.TypesRsc == null || !Enum.IsDefined(typeof(TYPES_RESOURCE), atomic.TypesRsc.ToUpper()))
            {
                throw new ClientException(400, "Invalid Types!");
            }
            if (atomicQuery.CountNameAndTypesExact(atomic.Name, atomic.TypesRsc) != 0)
            {
                throw new ClientException(400, "Url already exists!");
            }
            var data = MappingData.InitializeAutomapper().Map<Domain.Entitys.Atomic>(atomic);
            return await atomicQuery.InsertAsync(data);
        }

        public int RemoveAtomic(List<int> ids)
        {
            return atomicQuery.Delete(ids);
        }

        public int UpdateAtomic(List<int> ids)
        {
            var dsada = atomicQuery.GetAllLstById(ids).Select(m => { m.IsActive = !m.IsActive; return m; }).ToList();
            return atomicQuery.Update(dsada);
        }

        public int EditAtomic(AtomicDto atomicDto)
        {
            if (string.IsNullOrEmpty(atomicDto.Name) || string.IsNullOrEmpty(atomicDto.TypesRsc))
            {
                throw new ClientException(400, "Invalid Types!");
            }
            var atomic = MappingData.InitializeAutomapper().Map<Domain.Entitys.Atomic>(atomicDto);
            atomic.UpdatedAt = DateTime.Now;
            return atomicQuery.Update(atomic);
        }
    }
}
