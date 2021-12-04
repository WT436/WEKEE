using Account.Domain.CoreDomain;
using Account.Domain.Entitys;
using Account.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork;
using UnitOfWork.Collections;
using Utils.Auth.Dtos;
using Utils.Exceptions;

namespace Account.Infrastructure.ModelQuery
{
    public class UserAccountQuery
    {
        private readonly IUnitOfWork<AuthorizationContext> unitOfWork =
                           new UnitOfWork<AuthorizationContext>(new AuthorizationContext());
        #region Check
        /// <summary>
        /// kiểm tra tài khoản , email , số điện thoại
        /// </summary>
        public async Task<bool> CheckAccount(string account, string email, string numberPhone)
                     => await unitOfWork.GetRepository<UserAccount>()
                                        .ExistsAsync(m => account.Equals(m.UserName)
                                                       || email.Equals(m.Email)
                                                       || numberPhone.Equals(m.NumberPhone));
        /// <summary>
        /// kiểm tra tài khoản , email , số điện thoại
        /// </summary>
        public async Task<bool> CheckAccount(string email, string numberPhone)
                     => await unitOfWork.GetRepository<UserAccount>()
                                        .ExistsAsync(m => email.Equals(m.Email)
                                                       && numberPhone.Equals(m.NumberPhone));
        /// <summary>
        /// kiểm tra tài khoản id
        /// </summary>
        public async Task<bool> CheckAccountId(int id)
                     => await unitOfWork.GetRepository<UserAccount>()
                                        .ExistsAsync(m => m.UserProfileId == id);
        /// <summary>
        ///  kiểm tra tài khoản  trong db
        /// </summary>
        public async Task<bool> CheckExitsAccount(string Account)
            => await unitOfWork.GetRepository<UserAccount>()
                               .ExistsAsync(m => Account.Equals(m.UserName));

        /// <summary>
        /// kiểm tra email  trong db
        /// </summary>
        public async Task<bool> CheckExitsEmail(string Email)
         => await unitOfWork.GetRepository<UserAccount>()
                               .ExistsAsync(m => Email.Equals(m.Email));

        /// <summary>
        /// kiểm tra số lần đăng nhập fail
        /// </summary>
        /// <param name="userAccount"></param>
        public void CheckLoginFail(UserAccount userAccount)
        {
            var dateTimeNow = DateTime.Now;

            // check thời gian. để chặn đăng nhập
            if (userAccount.LockAccountTime > DateTime.Now)
            {
                userAccount.LockAccountTime = userAccount.LockAccountTime;
                userAccount.LoginFallNumber--;
                unitOfWork.GetRepository<UserAccount>().Update(userAccount);
                unitOfWork.SaveChanges();
                throw new ClientException(400, String.Format("You have logged into the wrong account {0} times. We will block your account until : {1}"
                                   , userAccount.LoginFallNumber - 1, userAccount.LockAccountTime - DateTime.Now));
            }

            // thời gian được nhập lại  5 - 10
            if (userAccount.LoginFallNumber - 1 == 5)
            {
                userAccount.LockAccountTime = dateTimeNow.AddMinutes(5);
                unitOfWork.GetRepository<UserAccount>().Update(userAccount);
                unitOfWork.SaveChanges();

                throw new ClientException(400, String.Format("You have logged into the wrong account {0} times. We will block your account until : {1}"
                                   , userAccount.LoginFallNumber - 1, userAccount.LockAccountTime - DateTime.Now));
            }

            // thời gian được nhập lại  10 - 15
            if (userAccount.LoginFallNumber - 1 == 10)
            {
                userAccount.LockAccountTime = dateTimeNow.AddMinutes(10);
                unitOfWork.GetRepository<UserAccount>().Update(userAccount);
                unitOfWork.SaveChanges();

                throw new ClientException(400, String.Format("You have logged into the wrong account {0} times. We will block your account until : {1}"
                                   , userAccount.LoginFallNumber - 1, userAccount.LockAccountTime - DateTime.Now));
            }

            // thời gian được nhập lại  15 - 19
            if (userAccount.LoginFallNumber - 1 == 15)
            {
                userAccount.LockAccountTime = dateTimeNow.AddMinutes(15);
                unitOfWork.GetRepository<UserAccount>().Update(userAccount);
                unitOfWork.SaveChanges();

                throw new ClientException(400, String.Format("You have logged into the wrong account {0} times. We will block your account until : {1}"
                                   , userAccount.LoginFallNumber - 1, userAccount.LockAccountTime - DateTime.Now));
            }

            if (userAccount.LoginFallNumber == 20)
            {
                // login fail cấp 4
                userAccount.LockAccountTime = new DateTime(9999, 12, 31, 23, 59, 59);
                unitOfWork.GetRepository<UserAccount>().Update(userAccount);
                unitOfWork.SaveChanges();

                throw new ClientException(400, "We need to authenticate you. Please reset your password by registered email email");
            }

            if (userAccount.IsStatus == 3 || userAccount.IsStatus == 5)
            {
                // tài khoản đang gặp vấn đề không cho phép đăng nhập
                throw new ClientException(400, "We-are-temporarily-locking-your-account!");
            }
        }
        #endregion

        #region Lấy dữ liệu
        /// <summary> 
        /// Lấy thông tin tài khoản hiện có trong db nếu không có thì để null theo account
        /// </summary>
        public async Task<UserAccount> GetAllAccount(string Account)
            => await unitOfWork.GetRepository<UserAccount>()
                               .GetFirstOrDefaultAsync(predicate: m => m.UserName == Account);

        /// <summary>
        /// Lấy thông tin tài khoản hiện có trong db nếu không có thì để null theo id
        /// </summary>
        public async Task<UserAccount> GetAccountInIdAsync(int id)
            => await unitOfWork.GetRepository<UserAccount>()
                               .GetFirstOrDefaultAsync(predicate: m => m.UserProfileId == id);

        /// <summary>
        /// Lấy thông tin tài khoản hiện có trong db nếu không có thì để null theo id
        /// </summary>
        public UserAccount GetAccountInId(int id)
            => unitOfWork.GetRepository<UserAccount>()
                         .GetFirstOrDefault(predicate: m => m.UserProfileId == id);

        /// <summary>
        /// Lấy thông tin tài khoản hiện có trong db nếu không có thì để null  theo id
        /// </summary>
        public async Task<UserAccount> GetAllInToken(JwtCustomClaims token)
            => await unitOfWork.GetRepository<UserAccount>()
                                    .GetFirstOrDefaultAsync(predicate: m => m.UserProfileId == token.Id
                                                                         && m.UserName == token.Account_User
                                                                         && m.Email == token.Email
                                    // && m.IpUser == token.Ip 
                                    );

        public IQueryable<UserAccount> GetAllAccount()
               => unitOfWork.GetRepository<UserAccount>().GetAll();

        #endregion

        #region Insert và Update và delete
        /// <summary>
        /// Tạo mới tài khoản
        /// </summary>
        public async Task<int> Create(UserAccount userAccount)
        {
            ShiningAccount shiningAccount = new ShiningAccount();
            var accountReady = shiningAccount.SetupAccount(userAccount);

            await unitOfWork.GetRepository<UserAccount>().InsertAsync(accountReady);
            unitOfWork.SaveChanges();
            return accountReady.UserProfileId;
        }

        /// <summary>
        /// Cập nhật tài khoản
        /// </summary>
        /// <param name="userAccount"></param>
        /// <returns></returns>
        public bool UpdateAccount(UserAccount userAccount)
        {
            unitOfWork.GetRepository<UserAccount>()
                                  .Update(userAccount);
            return true;
        }

        /// <summary>
        /// Tăng số lần đăng nhập thất bại 
        /// </summary>
        /// <param name="userAccount"></param>
        public void UpLoginFail(UserAccount userAccount)
        {
            if (userAccount.LoginFallNumber < 20)
            {
                userAccount.LoginFallNumber++;
            }
            unitOfWork.GetRepository<UserAccount>().Update(userAccount);
            unitOfWork.SaveChanges();
        }

        /// <summary>
        /// resert số lần thất bại về 0
        /// </summary>
        /// <param name="userAccount"></param>
        public void ResertLoginFail(UserAccount userAccount)
        {
            userAccount.LoginFallNumber = 0;
            unitOfWork.GetRepository<UserAccount>().Update(userAccount);
            unitOfWork.SaveChanges();
        }
        /// <summary>
        /// Xóa tài khoản
        /// </summary>
        public async Task DeleteAccount(int id)
        {
            unitOfWork.GetRepository<UserAccount>().Delete(id);
            unitOfWork.SaveChanges();
        }
        #endregion

        #region Support
        public int Count()
               => unitOfWork.GetRepository<UserAccount>().Count();
        #endregion
    }
}
