using Account.Domain.Dto;
using Account.Domain.ObjectValues;
using Account.Domain.ObjectValues.Enum;
using System.Threading.Tasks;

namespace Account.Application.ResourceAction
{
    public interface IResourceAction
    {
        public Task<PagedListOutput<ActionResourceDto>> GetActionFromResourceAction(EntitySearchInput input);
        public Task<PagedListOutput<ResourceActionDto>> GetResourceFromResourceAction(EntitySearchInput input);
        public void UpdateOrInsertResourceAction(ActionResourceDto resourceActionDto);
    }
}
