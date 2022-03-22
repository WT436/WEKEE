using Account.Domain.ObjectValues.Input;
using Account.Domain.Shared.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.Atomic
{
    public interface IAtomicAssociate
    {
        /// <summary>
        /// get atomic by id action
        /// </summary>
        /// <param name="pagedListInput"></param>
        /// <returns></returns>
        Task<AtomicAssociateDto> GetAtomicByIdAction(PagedListInput pagedListInput); 
    }
}
