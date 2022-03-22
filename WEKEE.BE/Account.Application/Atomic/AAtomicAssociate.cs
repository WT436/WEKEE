using Account.Domain.ObjectValues.Input;
using Account.Domain.Shared.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.Atomic
{
    public class AAtomicAssociate : IAtomicAssociate
    {
        public async Task<AtomicAssociateDto> GetAtomicByIdAction(PagedListInput pagedListInput)
        {
            throw new NotImplementedException();
        }
    }
}
