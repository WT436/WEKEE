using Account.Domain.ObjectValues.Input;
using Account.Domain.ObjectValues.Output;
using Account.Domain.Shared.DataTransfer.ResourceDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Account.Application.Interface
{
    public interface IResourceAdmin
    {
        Task<PagedListOutput<ResourceReadDto>> GetResourcePageList(SearchOrderPageInput input);
        Task<int> DeleteResource(List<int> ids);
        Task<int> EditUnitResource(ResourceLstChangeDto input);
        Task<int> InsertOrUpdateResource(ResourceReadDto input, int idAccount);
    }
}
