using Account.Application.Interface;
using Account.Domain.Dto;
using Account.Domain.Entitys;
using Account.Domain.ObjectValues;
using Account.Infrastructure.ModelQuery;
using Account.Infrastructure.SqlQuery;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Collections;
using Utils.Exceptions;

namespace Account.Application.Application
{
    public class AAdminAccount : IAdminAccount
    {
        private readonly JoinQuery _joinQuery = new JoinQuery();
        private readonly UserAccountQuery _accountQuery = new UserAccountQuery();
        private readonly SubjectQuery _subjectQuery = new SubjectQuery();
        private readonly SubjectAssignmentQuery _subjectAssignmentQuery = new SubjectAssignmentQuery();
        private readonly AddressQuery _addressQuery = new AddressQuery();
        private readonly UserAccountIpQuery _userAccountIpQuery = new UserAccountIpQuery();
        private readonly InfomationUserQuery _infomationUserQuery = new InfomationUserQuery();
        private readonly UserAccountQuery _userAccountQuery = new UserAccountQuery();
        private readonly UserProfileQuery _userProfileQuery = new UserProfileQuery();

        public async Task<bool> ChangStatusAccount(int id_account, int status)
        {
            var account = await _accountQuery.GetAccountInIdAsync(id: id_account);
            if (status < 0 || status > 5)
            {
                throw new ClientException(100, "Status không tồn tại!");
            }
            if (account != null)
            {
                account.IsStatus = status;
                _accountQuery.UpdateAccount(account);
                return true;
            }
            else
            {
                throw new ClientException(100, "Tài khoản không tồn tại");
            }
        }

        public async Task<IPagedList<AccountShowDtos>> GetAllAccount(SearchOrderPageInput orderByPageListInput)
        {
            int rowBegin = (orderByPageListInput.PageIndex == 0
                            ? 0
                            : orderByPageListInput.PageIndex - 1
                           ) * orderByPageListInput.PageSize;

            var data = await _joinQuery.GetAccountAdmin(pageBegin: rowBegin,
                                                        pageSize: orderByPageListInput.PageSize,
                                                        orderBy: orderByPageListInput.OrderBy,
                                                        property: orderByPageListInput.Property,
                                                        propertySearch: orderByPageListInput.PropertySearch,
                                                        valuesSearch: orderByPageListInput.ValuesSearch);

            return data.MapToPagedList(pageIndex: orderByPageListInput.PageIndex,
                                       pageSize: orderByPageListInput.PageSize,
                                       totalCount: _accountQuery.Count(),
                                       indexFrom: 0);
        }

        // ******** Test CaChe ********
        // xóa subject assigment
        // Xóa subject group
        // Xóa Subject
        // Xóa Address
        // xóa process user
        // xóa User account ip
        // xóa Infomation user
        // xóa user account 
        // xóa user accounmt status
        // xóa user profile 
        // ******** Test CaChe ********  
        public async Task<bool> RemoveAccount(int id_Account)
        {
            if (await _accountQuery.CheckAccountId(id: id_Account))
            {
                // tìm kiếm tất cả subject
                var allSubjectAccount = await _subjectQuery.GetAllWithId(id_Account: id_Account);
                // xóa toàn bộ subject subject assigment
                foreach (var itemInSubjectAssigment in allSubjectAccount)
                {
                    await _subjectAssignmentQuery.Delete(
                          await _subjectAssignmentQuery.GetAllJoinWithIdSubject(itemInSubjectAssigment.Id));
                }
                await _subjectQuery.Delete(subjects: allSubjectAccount);
                await _addressQuery.Delete(idAccount: id_Account);
                await _userAccountIpQuery.Delete(idAccount: id_Account);
                await _infomationUserQuery.Delete(idAccount: id_Account);
                await _userAccountQuery.DeleteAccount(id: id_Account);
                await _userProfileQuery.Delete(id: id_Account);
                // gửi event bus xóa các thành phần liên quan
                return true;
            }
            else
            {
                throw new ClientException(100, "Tài khoản không tồn tại");
            }
        }
    }
}
