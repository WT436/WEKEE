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
                     => await unitOfWork.GetRepository<UserLogin>()
                                        .ExistsAsync(m => account.Equals(m.UserName)
                                                       || email.Equals(m.Email)
                                                       || numberPhone.Equals(m.NumberPhone));
        /// <summary>
        /// kiểm tra tài khoản , email , số điện thoại
        /// </summary>
        public async Task<bool> CheckAccount(string email, string numberPhone)
                     => await unitOfWork.GetRepository<UserLogin>()
                                        .ExistsAsync(m => email.Equals(m.Email)
                                                       && numberPhone.Equals(m.NumberPhone));
        /// <summary>
        /// kiểm tra tài khoản id
        /// </summary>
        public async Task<bool> CheckAccountId(int id)
                     => await unitOfWork.GetRepository<UserLogin>()
                                        .ExistsAsync(m => m.Id == id);
        /// <summary>
        ///  kiểm tra tài khoản  trong db
        /// </summary>
        public async Task<bool> CheckExitsAccount(string Account)
            => await unitOfWork.GetRepository<UserLogin>()
                               .ExistsAsync(m => Account.Equals(m.UserName));

        /// <summary>
        /// kiểm tra email  trong db
        /// </summary>
        public async Task<bool> CheckExitsEmail(string Email)
         => await unitOfWork.GetRepository<UserLogin>()
                               .ExistsAsync(m => Email.Equals(m.Email));

        /// <summary>
        /// kiểm tra số lần đăng nhập fail
        /// </summary>
        /// <param name="UserLogin"></param>
        public void CheckLoginFail(UserLogin userAccount)
        {
            var dateTimeNow = DateTime.Now;

            // check thời gian. để chặn đăng nhập
            if (userAccount.LockAccountTime > DateTime.Now)
            {
                userAccount.LockAccountTime = userAccount.LockAccountTime;
                userAccount.LoginFallNumber--;
                unitOfWork.GetRepository<UserLogin>().Update(userAccount);
                unitOfWork.SaveChanges();
                throw new ClientException(400, String.Format("You have logged into the wrong account {0} times. We will block your account until : {1}"
                                   , userAccount.LoginFallNumber - 1, userAccount.LockAccountTime - DateTime.Now));
            }

            // thời gian được nhập lại  5 - 10
            if (userAccount.LoginFallNumber - 1 == 5)
            {
                userAccount.LockAccountTime = dateTimeNow.AddMinutes(5);
                unitOfWork.GetRepository<UserLogin>().Update(userAccount);
                unitOfWork.SaveChanges();

                throw new ClientException(400, String.Format("You have logged into the wrong account {0} times. We will block your account until : {1}"
                                   , userAccount.LoginFallNumber - 1, userAccount.LockAccountTime - DateTime.Now));
            }

            // thời gian được nhập lại  10 - 15
            if (userAccount.LoginFallNumber - 1 == 10)
            {
                userAccount.LockAccountTime = dateTimeNow.AddMinutes(10);
                unitOfWork.GetRepository<UserLogin>().Update(userAccount);
                unitOfWork.SaveChanges();

                throw new ClientException(400, String.Format("You have logged into the wrong account {0} times. We will block your account until : {1}"
                                   , userAccount.LoginFallNumber - 1, userAccount.LockAccountTime - DateTime.Now));
            }

            // thời gian được nhập lại  15 - 19
            if (userAccount.LoginFallNumber - 1 == 15)
            {
                userAccount.LockAccountTime = dateTimeNow.AddMinutes(15);
                unitOfWork.GetRepository<UserLogin>().Update(userAccount);
                unitOfWork.SaveChanges();

                throw new ClientException(400, String.Format("You have logged into the wrong account {0} times. We will block your account until : {1}"
                                   , userAccount.LoginFallNumber - 1, userAccount.LockAccountTime - DateTime.Now));
            }

            if (userAccount.LoginFallNumber == 20)
            {
                // login fail cấp 4
                userAccount.LockAccountTime = new DateTime(9999, 12, 31, 23, 59, 59);
                unitOfWork.GetRepository<UserLogin>().Update(userAccount);
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
        public async Task<UserLogin> GetAllAccount(string Account)
            => await unitOfWork.GetRepository<UserLogin>()
                               .GetFirstOrDefaultAsync(predicate: m => m.UserName == Account);

        /// <summary>
        /// Lấy thông tin tài khoản hiện có trong db nếu không có thì để null theo id
        /// </summary>
        public async Task<UserLogin> GetAccountInIdAsync(int id)
            => await unitOfWork.GetRepository<UserLogin>()
                               .GetFirstOrDefaultAsync(predicate: m => m.Id == id);

        /// <summary>
        /// Lấy thông tin tài khoản hiện có trong db nếu không có thì để null theo id
        /// </summary>
        public UserLogin GetAccountInId(int id)
            => unitOfWork.GetRepository<UserLogin>()
                         .GetFirstOrDefault(predicate: m => m.Id == id);

        /// <summary>
        /// Lấy thông tin tài khoản hiện có trong db nếu không có thì để null  theo id
        /// </summary>
        public async Task<UserLogin> GetAllInToken(JwtCustomClaims token)
            => await unitOfWork.GetRepository<UserLogin>()
                                    .GetFirstOrDefaultAsync(predicate: m => m.Id == token.Id
                                                                         && m.UserName == token.Account_User
                                                                         && m.Email == token.Email
                                    // && m.IpUser == token.Ip 
                                    );
        public IQueryable<UserLogin> GetAllAccount()
               => unitOfWork.GetRepository<UserLogin>().GetAll();

        public string GetNameAccount(int? id)
        {
            var data = unitOfWork.GetRepository<UserLogin>()
                                 .GetFirstOrDefault(predicate: m => m.Id == id);
            if (data == null)
            {
                return null;
            }
            return data.UserName;
        }
        #endregion

        #region Support
        public int Count()
               => unitOfWork.GetRepository<UserLogin>().Count();
        #endregion

        #region Tạo mới - Create
        public int Insert(UserLogin userLogin)
        {
            unitOfWork.GetRepository<UserLogin>()
                      .Insert(userLogin);
            return unitOfWork.SaveChanges();
        }
        public int Insert(List<UserLogin> userLogins)
        {
            unitOfWork.GetRepository<UserLogin>()
                      .Insert(userLogins);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> InsertAsync(UserLogin userLogin)
        {
            await unitOfWork.GetRepository<UserLogin>()
                            .InsertAsync(userLogin);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> InsertAsync(List<UserLogin> userLogins)
        {
            await unitOfWork.GetRepository<UserLogin>()
                            .InsertAsync(userLogins);
            return unitOfWork.SaveChanges();
        }
        #endregion

        #region Cập nhật - Update


        /// <summary>
        /// Tăng số lần đăng nhập thất bại 
        /// </summary>
        /// <param name="userAccount"></param>
        public void UpLoginFail(UserLogin userAccount)
        {
            if (userAccount.LoginFallNumber < 20)
            {
                userAccount.LoginFallNumber++;
            }
            unitOfWork.GetRepository<UserLogin>().Update(userAccount);
            unitOfWork.SaveChanges();
        }

        /// <summary>
        /// resert số lần thất bại về 0
        /// </summary>
        /// <param name="userAccount"></param>
        public void ResertLoginFail(UserLogin userAccount)
        {
            userAccount.LoginFallNumber = 0;
            unitOfWork.GetRepository<UserLogin>().Update(userAccount);
            unitOfWork.SaveChanges();
        }
        public int Update(UserLogin userLogin)
        {
            unitOfWork.GetRepository<UserLogin>()
                      .Update(userLogin);
            return unitOfWork.SaveChanges();
        }
        public int Update(List<UserLogin> userLogins)
        {
            unitOfWork.GetRepository<UserLogin>()
                      .Update(userLogins);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> UpdateAsync(UserLogin userLogin)
        {
            unitOfWork.GetRepository<UserLogin>()
                      .Update(userLogin);
            return await unitOfWork.SaveChangesAsync();
        }
        public async Task<int> UpdateAsync(List<UserLogin> userLogins)
        {
            unitOfWork.GetRepository<UserLogin>()
                      .Update(userLogins);
            return await unitOfWork.SaveChangesAsync();
        }
        #endregion

        #region Xóa - Delete
        public int Delete(UserLogin userLogin)
        {
            unitOfWork.GetRepository<UserLogin>()
                      .Delete(userLogin);
            return unitOfWork.SaveChanges();
        }
        public int Delete(List<UserLogin> userLogins)
        {
            unitOfWork.GetRepository<UserLogin>()
                      .Delete(userLogins);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> DeleteAsync(UserLogin userLogin)
        {
            unitOfWork.GetRepository<UserLogin>()
                      .Delete(userLogin);
            return await unitOfWork.SaveChangesAsync();
        }
        public async Task<int> DeleteAsync(List<UserLogin> userLogins)
        {
            unitOfWork.GetRepository<UserLogin>()
                      .Delete(userLogins);
            return await unitOfWork.SaveChangesAsync();
        }
        #endregion
    }
}
