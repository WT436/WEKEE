using Account.Domain.Dto;
using Account.Domain.ObjectValues;

namespace Account.Application.Interface
{
    public interface IResourceAction
    {
        public PagedListOutput<ResourceActionDto> ResourceActionDtos(int idAction,PagedListInput pagedListInput);

        public void UpdateOrInsertResourceAction(ResourceActionDto resourceActionDto);
    }
}
