
using Account.Domain.Aggregate;
using Account.Domain.ObjectValues.ConstProperty;
using Account.Domain.ObjectValues.Input;
using Account.Domain.ObjectValues.Output;
using Account.Domain.Shared.DataTransfer.PermisionDTO;
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
    public interface IPermissionAdmin
    {
        Task<PagedListOutput<PermissionReadDto>> GetPermissionPageList(SearchOrderPageInput input);
        Task<int> DeletePermission(List<int> ids);
        Task<int> EditUnitPermission(PermissionLstChangeDto input);
        Task<int> InsertOrUpdatePermission(PermissionReadDto input, int idAccount);
        Task<List<PermissionSummaryReadDto>> GetSummaryPermission(SearchTextInput input);
        Task<int> InsertOrUpdatePermissionFtResource(PermissionFtResourceInsertDto input, int idAccount);
    }

    public class PermissionAdminService : IPermissionAdmin
    {
        private readonly PermissionADO _permissionADO = new PermissionADO();
        private readonly PermissionEDM _permissionEDM = new PermissionEDM();
        private readonly ResourceEDM _resourceEDM = new ResourceEDM();
        public async Task<int> DeletePermission(List<int> ids)
        {
            if (ids != null)
            {
                return await _permissionEDM.Delete(ids);
            }
            return 0;
        }

        public async Task<int> EditUnitPermission(PermissionLstChangeDto input)
        {
            if ((PermissionProperty)input.Types == PermissionProperty.IS_ACTIVE)
            {
                var data = await _permissionADO.GetPermissionsById(input.Ids);
                data.ForEach(m => { m.IsActive = !m.IsActive; });
                return await _permissionEDM.UpdateIsActive(data);
            }
            else
            {
                return 0;
            }
        }

        public async Task<PagedListOutput<PermissionReadDto>> GetPermissionPageList(SearchOrderPageInput input)
        {
            var data = await _permissionADO.GetAllPageLstExactNotFTS(input);
            //var result = data.Select(m => MappingData.InitializeAutomapper().Map<PermissionReadDto>(m)).ToList();
            var count = (await _permissionADO.GetCountForGetAllPageLst(input)).FirstOrDefault().TotalCount;
            return new PagedListOutput<PermissionReadDto>
            {
                Items = data,
                PageIndex = input.PageIndex,
                PageSize = input.PageSize,
                TotalPages = (count / input.PageSize),
                TotalCount = count
            };
        }

        public async Task<List<PermissionSummaryReadDto>> GetSummaryPermission(SearchTextInput input)
        {
            return await _permissionADO.GetSummary(input: input);
        }

        public async Task<int> InsertOrUpdatePermission(PermissionReadDto input, int idAccount)
        {
            if (input != null)
            {
                var data = new PermissionAggregate().MapData(input: input, idAccount: idAccount);
                if (data.Id == 0)
                {
                    // insert
                    return await _permissionEDM.Insert(data);
                }
                else
                {
                    //update
                    return await _permissionEDM.UpdateFull(data);
                }
            }
            else
            {
                throw new ClientException(404, "");
            }
        }

        public async Task<int> InsertOrUpdatePermissionFtResource(PermissionFtResourceInsertDto input, int idAccount)
        {
            // check id permission
            var isAnyPermission = await _permissionEDM.CheckAnyId(input.Id);
            // check full id resource
            var isAnyResources = await _resourceEDM.CheckAnyId(input.ResourceId);
            if (isAnyPermission && isAnyResources)
            {
                // check exsist in table resourceAssement
                var dataByIdPermission = await _permissionADO.GetReourceAssignment(input.Id);
                List<ReourceAssignment> DataInsert = new List<ReourceAssignment>();
                List<ReourceAssignment> DataUpdate = new List<ReourceAssignment>();
                // chuyển tất cả quyền thành false
                dataByIdPermission = dataByIdPermission.Select(m => { m.IsActive = false; return m; }).ToList();
                // lọc quyền
                input.ResourceId.ForEach(m =>
                {
                    //load item resource data
                    var data = dataByIdPermission.FirstOrDefault(n => n.ResourceId == m);
                    if (data != null)// data  tonf taij
                    {
                        data.IsActive = true;
                        data.CreateBy = idAccount;
                        data.UpdatedOnUtc = DateTime.Now;
                        DataUpdate.Add(data);
                    }
                    else // data ko tồn tại
                    {
                        DataInsert.Add(new ReourceAssignment
                        {
                            ResourceId = m,
                            PermissionId = input.Id,
                            IsActive = true,
                            CreateBy = idAccount
                        });
                    }
                    dataByIdPermission.Remove(data);
                });

                if(dataByIdPermission.Count()>0)
                {
                    DataUpdate.AddRange(dataByIdPermission);
                }
                return (await _permissionEDM.InsertReourceAssignment(DataInsert))
                + (await _permissionEDM.UpdateReourceAssignment(DataUpdate));
            }
            else
            {
                throw new ClientException(404, "DATA_ERROR_USER");
            }
        }

    }
}
