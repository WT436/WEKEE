using Account.Application.Interface;
using Account.Domain.Aggregate;
using Account.Domain.ObjectValues.ConstProperty;
using Account.Domain.ObjectValues.Input;
using Account.Domain.ObjectValues.Output;
using Account.Domain.Shared.DataTransfer.RoleDTO;
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
    public class RoleAdminService : IRoleAdmin
    {
        private readonly RoleADO _roleADO = new RoleADO();
        private readonly RoleEDM _roleEDM = new RoleEDM();
        private readonly PermissionADO _permissionADO = new PermissionADO();
        private readonly PermissionEDM _permissionEDM = new PermissionEDM();
        public async Task<int> DeleteRole(List<int> ids)
        {
            if (ids != null)
            {
                return await _roleEDM.Delete(ids);
            }
            return 0;
        }

        public async Task<int> EditUnitRole(RoleLstChangeDto input)
        {
            if ((RoleProperty)input.Types == RoleProperty.IS_ACTIVE)
            {
                var data = await _roleADO.GetRolesById(input.Ids);
                data.ForEach(m => { m.IsActive = !m.IsActive; });
                return await _roleEDM.UpdateIsActive(data);
            }
            else
            {
                return 0;
            }
        }

        public async Task<PagedListOutput<PermissionFtRoleReadDto>> GetRoleFtPermissionPageList(SearchOrderPageInput input)
        {
            int idRole = Convert.ToInt32(input.ValuesSearch[0]);
            input.PropertySearch = null;
            input.ValuesSearch = null;
            // data Permission
            var data = await _permissionADO.GetAllPageLstExactNotFTS(input);
            var count = (await _permissionADO.GetCountForGetAllPageLst(input)).FirstOrDefault().TotalCount;
            // get RoleFtpermission
            var dataRoleFtResource = await _permissionADO.GetAllPrmissionByIdRole(idRole);

            var result = data.Select(m =>
            {
                var item = MappingData.InitializeAutomapper().Map<PermissionFtRoleReadDto>(m);
                item.IsGranted = dataRoleFtResource.Any(n => n.PermissionId == m.Id && n.IsActive == true);
                return item;
            }).ToList();

            return new PagedListOutput<PermissionFtRoleReadDto>
            {
                Items = result,
                PageIndex = input.PageIndex,
                PageSize = input.PageSize,
                TotalPages = (count / input.PageSize),
                TotalCount = count
            };
        }

        public async Task<PagedListOutput<RoleReadDto>> GetRolePageList(SearchOrderPageInput input)
        {
            var data = await _roleADO.GetAllPageLstExactNotFTS(input);
            //var result = data.Select(m => MappingData.InitializeAutomapper().Map<RoleReadDto>(m)).ToList();
            var count = (await _roleADO.GetCountForGetAllPageLst(input)).FirstOrDefault().TotalCount;
            return new PagedListOutput<RoleReadDto>
            {
                Items = data,
                PageIndex = input.PageIndex,
                PageSize = input.PageSize,
                TotalPages = (count / input.PageSize),
                TotalCount = count
            };
        }

        public async Task<List<RoleSummaryReadDto>> GetSummaryRole(SearchTextInput input)
        {
            return await _roleADO.GetSummary(input: input);
        }

        public async Task<int> InsertOrUpdateRoleFtpermission(RoleFtPermissionInsertDto input, int idAccount)
        {
            // check id role
            var isAnyPermission = await _roleEDM.CheckAnyId(input.Id);
            // check full id resource
            var isAnyResources = await _permissionEDM.CheckAnyId(input.PermissionId);
            if (isAnyPermission && isAnyResources)
            {
                // check exsist in table resourceAssement
                var dataByIdPermission = await _roleADO.GetPermissionAssignment(input.Id);
                List<PermissionAssignment> DataInsert = new List<PermissionAssignment>();
                List<PermissionAssignment> DataUpdate = new List<PermissionAssignment>();
                // chuyển tất cả quyền thành false
                dataByIdPermission = dataByIdPermission.Select(m => { m.IsActive = false; return m; }).ToList();
                // lọc quyền
                input.PermissionId.ForEach(m =>
                {
                    //load item resource data
                    var data = dataByIdPermission.FirstOrDefault(n => n.PermissionId == m);
                    if (data != null)// data  tonf taij
                    {
                        data.IsActive = true;
                        data.CreateBy = idAccount;
                        data.UpdatedOnUtc = DateTime.Now;
                        DataUpdate.Add(data);
                    }
                    else // data ko tồn tại
                    {
                        DataInsert.Add(new PermissionAssignment
                        {
                            PermissionId = m,
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
                return (await _permissionEDM.InsertPermissionAssignment(DataInsert))
                + (await _permissionEDM.UpdatePermissionAssignment(DataUpdate));
            }
            else
            {
                throw new ClientException(404, "DATA_ERROR_USER");
            }
        }

        public async Task<int> InsertOrUpdateRole(RoleReadDto input, int idAccount)
        {
            if (input != null)
            {
                var data = new RoleAggregate().MapData(input: input, idAccount: idAccount);
                if (data.Id == 0)
                {
                    // insert
                    return await _roleEDM.Insert(data);
                }
                else
                {
                    //update
                    return await _roleEDM.UpdateFull(data);
                }
            }
            else
            {
                throw new ClientException(404, "");
            }
        }
    }
}
