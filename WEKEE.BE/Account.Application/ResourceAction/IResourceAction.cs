using Account.Domain.Shared.DataTransfer;
using Account.Domain.ObjectValues;
using Account.Domain.ObjectValues.Input;
using Account.Domain.ObjectValues.Output;
using System.Threading.Tasks;

namespace Account.Application.ResourceAction
{
    public interface IResourceAction
    {
        public Task<PagedListOutput<ActionResourceDto>> GetActionFromResourceAction(EntitySearchInput input);
        public Task<PagedListOutput<ResourceActionDto>> GetResourceFromResourceAction(EntitySearchInput input);
        public Task<int> UpdateOrInsertResourceAction(ActionResourceUpdateDto actionResourceUpdateDto);
    }
}
