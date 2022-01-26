﻿using System.Threading.Tasks;
using UnitOfWork.Collections;
using Account.Domain.Shared.DataTransfer;
using Account.Domain.ObjectValues;
using Account.Domain.ObjectValues.Input;

namespace Account.Application.AdminAccount
{
    public interface IAdminAccount
    {
        public Task<IPagedList<AccountShowDtos>> GetAllAccount(SearchOrderPageInput orderByPageListInput);
        public Task<bool> ChangStatusAccount(int id_account, int status);
        public Task<bool> RemoveAccount(int id_account);
    }
}
