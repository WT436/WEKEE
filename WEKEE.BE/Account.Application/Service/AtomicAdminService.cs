using Account.Application.Interface;
using Account.Domain.Aggregate;
using Account.Domain.ObjectValues.ConstProperty;
using Account.Domain.ObjectValues.Input;
using Account.Domain.ObjectValues.Output;
using Account.Domain.Shared.DataTransfer.AtomicDTO;
using Account.Infrastructure.ADOQuery;
using Account.Infrastructure.EDMQuery;
using Account.Infrastructure.MappingExtention;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Exceptions;

namespace Account.Application.Service
{
    public class AtomicAdminService : IAtomicAdmin
    {
        private readonly AtomicADO _AtomicADO = new AtomicADO();
        private readonly AtomicEDM _AtomicEDM = new AtomicEDM();

        public async Task<int> DeleteAtomic(List<int> ids)
        {
            if (ids != null)
            {
                return await _AtomicEDM.Delete(ids);
            }
            return 0;
        }

        public async Task<int> EditUnitAtomic(AtomicLstChangeDto input)
        {
            if ((AtomicProperty)input.Types == AtomicProperty.IS_ACTIVE)
            {
                var data = await _AtomicADO.GetAtomicsById(input.Ids);
                data.ForEach(m => { m.IsActive = !m.IsActive; });
                return await _AtomicEDM.UpdateIsActive(data);
            }
            else
            {
                return 0;
            }
        }

        public async Task<PagedListOutput<AtomicReadDto>> GetAtomicPageList(SearchOrderPageInput input)
        {
            var data = await _AtomicADO.GetAllPageLstExactNotFTS(input);
            var result = data.Select(m => MappingData.InitializeAutomapper().Map<AtomicReadDto>(m)).ToList();
            var count = (await _AtomicADO.GetCountForGetAllPageLst(input)).FirstOrDefault().TotalCount;
            return new PagedListOutput<AtomicReadDto>
            {
                Items = data,
                PageIndex = input.PageIndex,
                PageSize = input.PageSize,
                TotalPages = (count / input.PageSize),
                TotalCount = count
            };
        }

        public async Task<List<AtomicSummaryReadDto>> GetSummaryAtomic()
        {
            return await _AtomicADO.GetSummary();
        }

        public async Task<int> InsertOrUpdateAtomic(AtomicReadDto input, int idAccount)
        {
            if (input != null)
            {
                var data = new AtomicAggregate().MapData(input: input, idAccount: idAccount);
                if (data.Id == 0)
                {
                    // insert
                    return await _AtomicEDM.Insert(data);
                }
                else
                {
                    //update
                    return await _AtomicEDM.UpdateFull(data);
                }
            }
            else
            {
                throw new ClientException(404, "");
            }
        }
    }
}
