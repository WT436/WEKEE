using Account.Application.Interface;
using Account.Domain.CoreDomain;
using Account.Domain.Dto;
using Account.Domain.Entitys;
using Account.Infrastructure.ModelQuery;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.Application
{
    public class AAccountAdminProcess : IAccountAdminProcess
    {
        private readonly CheckStatusAccount checkStatusAccount = new CheckStatusAccount();
        private readonly UserAccountIpQuery userAccountIpQuery = new UserAccountIpQuery();
        private readonly UserAccountQuery userAccountQuery = new UserAccountQuery();
        private readonly UserProfileQuery userProfileQuery = new UserProfileQuery();
        private readonly UserAccountStatusQuery userAccountStatusQuery = new UserAccountStatusQuery();
        private readonly SubjectQuery subjectQuery = new SubjectQuery();
        private readonly SubjectAssignmentQuery subjectAssignment = new SubjectAssignmentQuery();
        private readonly AddressQuery address = new AddressQuery();
        private readonly InfomationUserQuery infomationUser = new InfomationUserQuery();
        public async Task InsertOrUpdateAccount(AccountAdminCreate accountAdminCreate, string ipUser, string userAgent)
        {
            if (accountAdminCreate.Id == 0)
            {
                await InsertAccount(accountAdminCreate: accountAdminCreate,
                                    ipUser: ipUser,
                                    userAgent: userAgent);
            }
            else
            {
                await UpdateAccount(accountAdminCreate: accountAdminCreate,
                                    ipUser: ipUser,
                                    userAgent: userAgent);
            }
            // kiểm tra id . xác nhận xem nên tạo mới hay update
        }
        private async Task InsertAccount(AccountAdminCreate accountAdminCreate, string ipUser, string userAgent)
        {
            // kiểm tra user name , sdt , email
            checkStatusAccount.CheckExits(await userAccountQuery.CheckAccount(account: accountAdminCreate.UserName,
                                                                              email: accountAdminCreate.Email,
                                                                              numberPhone: accountAdminCreate.NumberPhone));

            // Tạo [User_Profile] để lấy id và auth v2
            var idProfile = await userProfileQuery.CreateDefault(new UserProfile
            {
                FirstName = accountAdminCreate.FirstName,
                LastName = accountAdminCreate.LastName,
                FullName = accountAdminCreate.FirstName + " " + accountAdminCreate.LastName,
                AcceptTermOfService = accountAdminCreate.AcceptTermOfService,
                TimeZone = accountAdminCreate.TimeZone
            });
            // Tạo [User_Account_Status]
            var idUserAccStatus = await userAccountStatusQuery.Create();
            // Tạo tài khoản [User_Account]
            var id_user_account = await userAccountQuery.Create(new UserAccount
            {
                UserProfileId = idProfile,
                UserName = accountAdminCreate.UserName,
                Email = accountAdminCreate.Email,
                NumberPhone = accountAdminCreate.NumberPhone,
                StatusId = idUserAccStatus,
                IsStatus = accountAdminCreate.IsStatus,
                DateCreate = DateTime.Now,
                IsOnline = true,
            });
            // Address
            await address.InsertAsync(new Address
            {
                AdressLine1 = accountAdminCreate.AdressLine1,
                AdressLine2 = accountAdminCreate.AdressLine2,
                AdressLine3 = accountAdminCreate.AdressLine3,
                Description = accountAdminCreate.DescriptionAdress,
                IsActive = accountAdminCreate.IsActive,
                UserAccountId = idProfile
            });
            // Infomation User
            await infomationUser.InsertAsync(new InfomationUser
            {
                Coordinates = accountAdminCreate.Coordinates,
                Picture = accountAdminCreate.Picture,
                Gender = accountAdminCreate.Gender,
                Description = accountAdminCreate.Description,
                IsActive = accountAdminCreate.IsActive,
                UserAccountId = idProfile
            });
            // tao mootj danh sach ip
            await userAccountIpQuery.CreateUserAccountIp(id_user_account, ipUser, userAgent);
            bool checkExists = await subjectQuery.CheckExists(id_user_account);
            int id_subject;
            if (!checkExists)
            {
                id_subject = await subjectQuery.Create(id_user_account);
            }
            else
            {
                id_subject = await subjectQuery.ReadId(id_user_account);
            }
            // gán quyền [role] default vào bảng [SubjectAssignment]
            await subjectAssignment.CreateDefault(id_subject);
            // gửi mã code xác nhận [User_Account_Status]

            // thông báo Thành công và yêu cầu người dùng kích hoạt
        }

        private async Task UpdateAccount(AccountAdminCreate accountAdminCreate, string ipUser, string userAgent)
        {
            // kiểm tra user name , sdt , email
            checkStatusAccount.CheckExits(await userAccountQuery.CheckAccount(email: accountAdminCreate.Email,
                                                                              numberPhone: accountAdminCreate.NumberPhone));
            checkStatusAccount.CheckExits(await userAccountQuery.CheckAccountId(id: accountAdminCreate.Id));

            // Tạo [User_Profile] để lấy id và auth v2
            userProfileQuery.UpdateDefault(new UserProfile
            {
                Id = accountAdminCreate.Id,
                FirstName = accountAdminCreate.FirstName,
                LastName = accountAdminCreate.LastName,
                FullName = accountAdminCreate.FirstName + " " + accountAdminCreate.LastName,
                AcceptTermOfService = accountAdminCreate.AcceptTermOfService,
                TimeZone = accountAdminCreate.TimeZone,
                DateCreate = DateTime.Now
            });
            // lấy thông tin [User_Account]
            var account = await userAccountQuery.GetAccountInIdAsync(id: accountAdminCreate.Id);
            // Tạo [User_Account_Status]
            var idUserAccStatus = await userAccountStatusQuery.GetStatusWithId(id: account.StatusId);
            // Tạo tài khoản [User_Account]
            userAccountQuery.UpdateAccount(new UserAccount
            {
                UserProfileId = accountAdminCreate.Id,
                UserName = accountAdminCreate.UserName,
                Email = accountAdminCreate.Email,
                NumberPhone = accountAdminCreate.NumberPhone,
                Password = account.Password,
                PasswordSalt = account.PasswordSalt,
                PasswordHashAlgorithm = account.PasswordHashAlgorithm,
                LoginFallNumber = account.LoginFallNumber,
                LockAccountTime = account.LockAccountTime,
                StatusId = idUserAccStatus.Id,
                IsOnline = account.IsOnline,
                IsStatus = account.IsStatus,
                DateCreate = DateTime.Now,
            });
            // Address
            var addressData = await address.GetUniqueAsync(id: account.UserProfileId);
            address.Update(new Address
            {
                Id = addressData.Id,
                AdressLine1 = accountAdminCreate.AdressLine1,
                AdressLine2 = accountAdminCreate.AdressLine2,
                AdressLine3 = accountAdminCreate.AdressLine3,
                Description = accountAdminCreate.DescriptionAdress,
                IsActive = accountAdminCreate.IsActive,
                DateEdit = DateTime.Now,
                UserAccountId = account.UserProfileId
            });
            // Infomation User
            var infomationUserData =await infomationUser.GetUniqueAsync(id: account.UserProfileId);
            infomationUser.Update(new InfomationUser
            {
                Id = infomationUserData.Id,
                Coordinates = accountAdminCreate.Coordinates,
                Picture = accountAdminCreate.Picture,
                Gender = accountAdminCreate.Gender,
                Description = accountAdminCreate.Description,
                IsActive = accountAdminCreate.IsActive,
                DateCreate = infomationUserData.DateCreate,
                DateEdit = DateTime.Now,
                UserAccountId = infomationUserData.UserAccountId
            });
            // tao mootj danh sach ip
            await userAccountIpQuery.CreateUserAccountIp(account.UserProfileId, ipUser, userAgent);            
        }
    }
}
