using Account.Application.Interface;
using Account.Domain.Aggregate;
using Account.Domain.ObjectValues.ConstProperty;
using Account.Domain.ObjectValues.Input;
using Account.Domain.ObjectValues.Output;
using Account.Domain.Shared.DataTransfer.SubjectDTO;
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
    public class SubjectAdminService : ISubjectAdmin
    {
        private readonly SubjectADO _SubjectADO = new SubjectADO();
        private readonly SubjectEDM _SubjectEDM = new SubjectEDM();

        public async Task<int> DeleteSubject(List<int> ids)
        {
            if (ids != null)
            {
                return await _SubjectEDM.Delete(ids);
            }
            return 0;
        }

        public async Task<int> EditUnitSubject(SubjectLstChangeDto input)
        {
            if ((SubjectProperty)input.Types == SubjectProperty.IS_ACTIVE)
            {
                var data = await _SubjectADO.GetSubjectsById(input.Ids);
                data.ForEach(m => { m.IsActive = !m.IsActive; });
                return await _SubjectEDM.UpdateIsActive(data);
            }
            else
            {
                return 0;
            }
        }

        public async Task<PagedListOutput<SubjectReadDto>> GetSubjectPageList(SearchOrderPageInput input)
        {
            var data = await _SubjectADO.GetAllPageLstExactNotFTS(input);
            //var result = data.Select(m => MappingData.InitializeAutomapper().Map<SubjectReadDto>(m)).ToList();
            var count = (await _SubjectADO.GetCountForGetAllPageLst(input)).FirstOrDefault().TotalCount;
            return new PagedListOutput<SubjectReadDto>
            {
                Items = data,
                PageIndex = input.PageIndex,
                PageSize = input.PageSize,
                TotalPages = (count / input.PageSize),
                TotalCount = count
            };
        }

        public async Task<int> InsertOrUpdateSubject(SubjectReadDto input, int idAccount)
        {
            if (input != null)
            {
                var data = new SubjectAggregate().MapData(input: input, idAccount: idAccount);
                if (data.Id == 0)
                {
                    // insert
                    return await _SubjectEDM.Insert(data);
                }
                else
                {
                    //update
                    return await _SubjectEDM.UpdateFull(data);
                }
            }
            else
            {
                throw new ClientException(404, "");
            }
        }
    }
}
