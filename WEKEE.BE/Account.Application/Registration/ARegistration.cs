
using Account.Domain.CoreDomain;
using Account.Domain.Shared.DataTransfer;
using Account.Domain.Shared.Entitys;
using Account.Infrastructure.MappingExtention;
using Account.Infrastructure.ModelQuery;
using System;
using System.Threading.Tasks;

namespace Account.Application.Registration
{
    public class ARegistration : IRegistration
    {
        private readonly CheckStatusAccount checkStatusAccount = new CheckStatusAccount();
        private readonly UserAccountIpQuery userAccountIpQuery = new UserAccountIpQuery();
        private readonly CheckAccountDomain checkAccountDomain = new CheckAccountDomain();
        private readonly UserProfileQuery userProfileQuery = new UserProfileQuery();
        private readonly UserAccountQuery userAccountQuery = new UserAccountQuery();
        private readonly UserAccountStatusQuery userAccountStatusQuery = new UserAccountStatusQuery();
        private readonly SubjectQuery subjectQuery = new SubjectQuery();
        private readonly SubjectAssignmentQuery subjectAssignment = new SubjectAssignmentQuery();

        public string CreateAccount(AccountDtos accountDto, string ipUser, string userAgent)
        {
           throw new NotImplementedException();
        }

        public async Task<string> CreateAccountAsync(AccountDtos accountDto, string ipUser, string userAgent)
        {
            // Kiem tra kiểu tài khoản
            checkAccountDomain.CheckInputAccount(accountDto);
            // Kiểm tra tồn tại 
            checkStatusAccount.CheckExitsAccount(await userAccountQuery.CheckExitsAccount(accountDto.Account));
            checkStatusAccount.CheckExitsEmail(await userAccountQuery.CheckExitsEmail(accountDto.Email));

            // kiểm tra tài khoản đã đăng ký mà chưa xác thực
            // Add account            
            var user_profile = MappingData.InitializeAutomapper().Map<UserProfile>(accountDto);

            // Tạo [User_Profile] để lấy id và auth v2
            var ID_Profile = await userProfileQuery.InsertAsync(user_profile);

            // Tạo [User_Account_Status]
            var iD_UserAccStatus = userAccountStatusQuery.Insert(new UserAccountStatus());

            // Tạo tài khoản [User_Account]
            var user_account = MappingData.InitializeAutomapper().Map<UserLogin>(accountDto);
            user_account.Id = ID_Profile;
            user_account.CreatedAt = DateTime.Now;
            user_account.IsOnline = true;
            var id_user_account = await userAccountQuery.InsertAsync(user_account);
            // tao mootj danh sach ip
            await userAccountIpQuery.InsertAsync(new UserAccountIp { AccountId = user_profile.Id,UserAgent = userAgent, Ipv4 = ipUser });
            // tạo một [Subject] đại diện với quyền default
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
            return "Tài Khoản đã được khởi tạo!";
        }
    }
}
