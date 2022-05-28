
using Account.Domain.Aggregate;
using Account.Domain.ObjectValues.ConstProperty;
using Account.Domain.ObjectValues.Input;
using Account.Domain.ObjectValues.Output;
using Account.Domain.Shared.DataTransfer.RoleDTO;
using Account.Domain.Shared.DataTransfer.SubjectDTO;
using Account.Domain.Shared.Entitys;
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
    public interface ISubjectAdmin
    {
        Task<PagedListOutput<SubjectReadDto>> GetSubjectPageList(SearchOrderPageInput input);
        Task<int> DeleteSubject(List<int> ids);
        Task<int> EditUnitSubject(SubjectLstChangeDto input);
        Task<int> InsertOrUpdateSubject(SubjectReadDto input, int idAccount);
        Task<PagedListOutput<SubjectFtRoleReadDto>> GetSubjectFtRolePageList(SearchOrderPageInput input);
        Task<int> InsertOrUpdateSubjectFtRole(SubjectFtRoleInsertDto input, int idAccount);
    }

    public class SubjectAdminService : ISubjectAdmin
    {
        private readonly SubjectADO _SubjectADO = new SubjectADO();
        private readonly SubjectEDM _SubjectEDM = new SubjectEDM();
        private readonly RoleADO _roleADO = new RoleADO();
        private readonly RoleEDM _roleEDM = new RoleEDM();


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

        public async Task<PagedListOutput<SubjectFtRoleReadDto>> GetSubjectFtRolePageList(SearchOrderPageInput input)
        {
            int idSubject = Convert.ToInt32(input.ValuesSearch[0]);
            input.PropertySearch = null;
            input.ValuesSearch = null;
            // data Role
            var data = await _roleADO.GetAllPageLstExactNotFTS(input);
            var count = (await _roleADO.GetCountForGetAllPageLst(input)).FirstOrDefault().TotalCount;
            // get SubjectFtRole
            var dataRoleFtResource = await _SubjectADO.GetSubjectAssignmentByIdSubject(idSubject);

            var result = data.Select(m =>
            {
                var item = MappingData.InitializeAutomapper().Map<SubjectFtRoleReadDto>(m);
                item.IsGranted = dataRoleFtResource.Any(n => n.RoleId == m.Id && n.IsActive == true);
                return item;
            }).ToList();

            return new PagedListOutput<SubjectFtRoleReadDto>
            {
                Items = result,
                PageIndex = input.PageIndex,
                PageSize = input.PageSize,
                TotalPages = (count / input.PageSize),
                TotalCount = count
            };
        }

        public async Task<int> InsertOrUpdateSubjectFtRole(SubjectFtRoleInsertDto input, int idAccount)
        {
            // check id subject
            var isAnyPermission = await _SubjectEDM.CheckAnyId(input.Id);
            // check full id resource
            var isAnyResources = await _roleEDM.CheckAnyId(input.RoleId);
            if (isAnyPermission && isAnyResources)
            {
                // check exsist in table resourceAssement
                var dataByIdPermission = await _SubjectADO.GetSubjectAssignmentByIdSubject(input.Id);
                List<SubjectAssignment> DataInsert = new List<SubjectAssignment>();
                List<SubjectAssignment> DataUpdate = new List<SubjectAssignment>();
                // chuyển tất cả quyền thành false
                dataByIdPermission = dataByIdPermission.Select(m => { m.IsActive = false; return m; }).ToList();
                // lọc quyền
                input.RoleId.ForEach(m =>
                {
                    //load item resource data
                    var data = dataByIdPermission.FirstOrDefault(n => n.RoleId == m);
                    if (data != null)// data  tonf taij
                    {
                        data.IsActive = true;
                        data.CreateBy = idAccount;
                        data.UpdatedOnUtc = DateTime.Now;
                        DataUpdate.Add(data);
                    }
                    else // data ko tồn tại
                    {
                        DataInsert.Add(new SubjectAssignment
                        {
                            SubjectId = m,
                            RoleId = input.Id,
                            IsActive = true,
                            CreateBy = idAccount
                        });
                    }
                    dataByIdPermission.Remove(data);
                });

                if (dataByIdPermission.Count() > 0)
                {
                    DataUpdate.AddRange(dataByIdPermission);
                }
                return (await _SubjectEDM.InsertSubjectAssignment(DataInsert))
                + (await _SubjectEDM.UpdateSubjectAssignment(DataUpdate));
            }
            else
            {
                throw new ClientException(404, "DATA_ERROR_USER");
            }
        }
    }
}
