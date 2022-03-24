using Account.Application.Action;
using Account.Domain.Shared.DataTransfer;
using Account.Domain.ObjectValues.Input;
using Account.Domain.ObjectValues.Output;
using Account.Infrastructure.BoundedContext;
using Account.Infrastructure.ModelQuery;
using System.Threading.Tasks;
using Utils.Exceptions;
using Account.Infrastructure.MappingExtention;
using System.Linq;

namespace Account.Application.ActionAssignment
{
    public class ActionAssignmentService : IActionAssignment
    {
        private readonly ActionService _action = new ActionService();
        private readonly ActionQuery _actionQuery = new ActionQuery();
        private readonly UserAccountQuery _accountQuery = new UserAccountQuery();
        private readonly PermissionQuery _permissionQuery = new PermissionQuery();
        private readonly ActionAssignmentQuery actionAssignmentQuery = new ActionAssignmentQuery();
        private readonly AtomicQuery _atomicQuery = new AtomicQuery();

        public async Task<PagedListOutput<ActionDto>> GetActionByAtomic(int idAtomic, int pageIndex, int pageSize)
        {
            // lấy dữ liệu action theo id atomic
            var dataAction = await actionAssignmentQuery.GetDataByIdAtomic(idAtomic: idAtomic,
                                                                           pageIndex: pageIndex,
                                                                           pageSize: pageSize);
            var dataReturn = new PagedListOutput<ActionDto>
            {
                Items = dataAction.Items.Select(emp =>
                {
                    var dataReturn = MappingData.InitializeAutomapper().Map<ActionDto>(emp);
                    dataReturn.CreateByName = _accountQuery.GetNameAccount(emp.CreateBy);
                    var atomicData = _atomicQuery.GetById(emp.AtomicId);
                    dataReturn.AtomicName = atomicData == null ? "" : atomicData.Name;
                    Domain.Shared.Entitys.Action actionData =
                    emp.ActionBase == null ? null : _actionQuery.GetById(emp.ActionBase);
                    dataReturn.ActionBaseName = actionData == null ? "" : actionData.Name;
                    return dataReturn;
                }).ToList(),
                PageIndex = dataAction.PageIndex,
                PageSize = dataAction.PageSize,
                TotalPages = dataAction.TotalPages,
                TotalCount = dataAction.TotalCount
            };

            return dataReturn;
        }

        public async Task<PagedListOutput<ActionAssignmentDto>> ListActionAssignment(int idPermission, PagedListInput pagedListInput)
        {
            //lấy dữ liệu resource,
            // lấy dữ liệu action
            var dataActionAssignment = actionAssignmentQuery.ListActionAssignmentWithId(idPermission);
            // map data
            return MapPagedListOutput.MapingpagedListOutput(action: null,
                                                            actionAssignments: dataActionAssignment,
                                                            permissionId: idPermission);
        }

        public async Task<int> UpdateOrInsert(ActionAssignmentDto actionAssignmentDto)
        {
            // kieemr tra 
            if (_actionQuery.CountId(actionAssignmentDto.Id) != 1)
            {
                throw new ClientException(400, "Action already exists!");
            }

            if (_permissionQuery.CountId(actionAssignmentDto.PermissionId) != 1)
            {
                throw new ClientException(400, "Permission already exists!");
            }

            var dataResourceAction = actionAssignmentQuery.CheckExistsUnique(actionId: actionAssignmentDto.Id, permissionId: actionAssignmentDto.PermissionId);
            if (dataResourceAction == null)
            {
                actionAssignmentQuery.Insert(new Account.Domain.Shared.Entitys.ActionAssignment
                {
                    ActionId = actionAssignmentDto.Id,
                    PermissionId = actionAssignmentDto.PermissionId,
                    IsActive = true
                });
            }
            else
            {
                dataResourceAction.IsActive = !dataResourceAction.IsActive;

                actionAssignmentQuery.Update(dataResourceAction);
            }
            return 0;
        }
    }
}
