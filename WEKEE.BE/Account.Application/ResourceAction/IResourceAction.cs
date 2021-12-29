using Account.Domain.Dto;
using Account.Domain.ObjectValues;
using Account.Domain.ObjectValues.Enum;

namespace Account.Application.ResourceAction
{
    public interface IResourceAction
    {
        public PagedListOutput<ActionResourceDto> ResourceActionDtos(int idAction,PagedListInput pagedListInput);

        public void UpdateOrInsertResourceAction(ActionResourceDto resourceActionDto);
    }
}
