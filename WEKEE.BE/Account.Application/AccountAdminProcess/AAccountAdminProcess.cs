using Account.Domain.CoreDomain;
using Account.Domain.Shared.DataTransfer;
using Account.Domain.Shared.Entitys;
using Account.Infrastructure.ModelQuery;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.AccountAdminProcess
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
            UserProfile userProfile = new UserProfile
            {
                TimeZone = accountAdminCreate.TimeZone
            };
            await userProfileQuery.InsertAsync(userProfile);
            // Tạo [User_Account_Status]
            var idUserAccStatus = await userAccountStatusQuery.InsertAsync(new UserAccountStatus());
            // Tạo tài khoản [User_Account]
            var userLogin = new UserLogin
            {
                Id = userProfile.Id,
                UserName = accountAdminCreate.UserName,
                Email = accountAdminCreate.Email,
                NumberPhone = accountAdminCreate.NumberPhone,
                IsStatus = idUserAccStatus,
                CreatedAt = DateTime.Now,
                IsOnline = true,
            };
            ShiningAccount shiningAccount = new ShiningAccount();
            var accountReady = shiningAccount.SetupAccount(userLogin);
            await userAccountQuery.InsertAsync(userLogin);
            // Address
            var adress = new Address
            {
                AdressLine1 = accountAdminCreate.AdressLine1,
                AdressLine2 = accountAdminCreate.AdressLine2,
                AdressLine3 = accountAdminCreate.AdressLine3,
                Description = accountAdminCreate.DescriptionAdress,
                IsActive = accountAdminCreate.IsActive,
                Id = userProfile.Id
            };
            await address.InsertAsync(adress);
            // Infomation User
            await infomationUser.InsertAsync(new Domain.Shared.Entitys.InfomationUser
            {
                Coordinates = accountAdminCreate.Coordinates,
                Picture = accountAdminCreate.Picture,
                Description = accountAdminCreate.Description,
                IsActive = accountAdminCreate.IsActive,
                Id = userProfile.Id
            });
            // tao mootj danh sach ip
            var userAccountIp = new UserAccountIp
            {
                Ipv4 = ipUser,
                UserAgent = userAgent,
                AccountId = userLogin.Id
            };

            await userAccountIpQuery.InsertAsync(userAccountIp);
            bool checkExists = await subjectQuery.CheckExists(userProfile.Id);
            int id_subject;
            if (!checkExists)
            {
                id_subject = await subjectQuery.Create(userProfile.Id);
            }
            else
            {
                id_subject = await subjectQuery.ReadId(userProfile.Id);
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
            await userProfileQuery.UpdateAsync(new UserProfile
            {
                Id = accountAdminCreate.Id,
                TimeZone = accountAdminCreate.TimeZone,
                CreatedAt = DateTime.Now
            });
            // lấy thông tin [User_Account]
            var account = await userAccountQuery.GetAccountInIdAsync(id: accountAdminCreate.Id);
            // Tạo [User_Account_Status]
            var idUserAccStatus = await userAccountStatusQuery.GetStatusWithId(id: account.Id);
            // Tạo tài khoản [User_Account]
            await userAccountQuery.UpdateAsync(new UserLogin
            {
                Id = accountAdminCreate.Id,
                UserName = accountAdminCreate.UserName,
                Email = accountAdminCreate.Email,
                NumberPhone = accountAdminCreate.NumberPhone,
                Password = account.Password,
                PasswordSalt = account.PasswordSalt,
                PasswordHashAlgorithm = account.PasswordHashAlgorithm,
                LoginFallNumber = account.LoginFallNumber,
                LockAccountTime = account.LockAccountTime,
                IsOnline = account.IsOnline,
                IsStatus = account.IsStatus,
                CreatedAt = DateTime.Now,
            });
            // Address
            var addressData = await address.GetUniqueAsync(id: account.Id);
            address.Update(new Address
            {
                Id = addressData.Id,
                AdressLine1 = accountAdminCreate.AdressLine1,
                AdressLine2 = accountAdminCreate.AdressLine2,
                AdressLine3 = accountAdminCreate.AdressLine3,
                Description = accountAdminCreate.DescriptionAdress,
                IsActive = accountAdminCreate.IsActive,
                UpdatedAt = DateTime.Now,
                AccountId = account.Id
            });
            // Infomation User
            var infomationUserData = await infomationUser.GetUniqueAsync(id: account.Id);
            infomationUser.Update(new Domain.Shared.Entitys.InfomationUser
            {
                Id = infomationUserData.Id,
                Coordinates = accountAdminCreate.Coordinates,
                Picture = accountAdminCreate.Picture,
                Description = accountAdminCreate.Description,
                IsActive = accountAdminCreate.IsActive,
                CreatedAt = infomationUserData.CreatedAt,
                UpdatedAt = DateTime.Now,
                AccountId = infomationUserData.Id
            });
            // tao mootj danh sach ip
            await userAccountIpQuery.InsertAsync(new UserAccountIp
            {
                Ipv4 = ipUser,
                UserAgent = userAgent,
                AccountId = account.Id
            });
        }
    }
}
