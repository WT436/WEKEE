using Account.Domain.Dto;
using Account.Domain.ObjectValues;
using Account.Domain.ObjectValues.Enum;

namespace Account.Application.ResourceAction
{
    public interface IResourceAction
    {
        public PagedListOutput<ResourceActionDto> ResourceActionDtos(int idAction,PagedListInput pagedListInput);

        public void UpdateOrInsertResourceAction(ResourceActionDto resourceActionDto);
    }
}
