using Account.Application.Interface;
using Account.Domain.BoundedContext;
using Account.Domain.CoreDomain;
using Account.Domain.ObjectValues.ConstProperty;
using Account.Domain.Shared.DataTransfer.UserProfileDTO;
using Account.Domain.Shared.Entitys;
using Account.Infrastructure.ADOQuery;
using Account.Infrastructure.EDMQuery;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Any;
using Utils.Auth.Dtos;
using Utils.Cache;
using Utils.Exceptions;

namespace Account.Application.Service
{
    public class UserAccountService : IUserAccount
    {
        private readonly UserProfileEDM _userProfileEDM = new UserProfileEDM();
        private readonly AddressEDM _addressEDM = new AddressEDM();
        private readonly UserPasswordEDM _userPasswordEDM = new UserPasswordEDM();
        private readonly UserStatusEDM _userStatusEDM = new UserStatusEDM();
        private readonly SubjectEDM _subjectEDM = new SubjectEDM();
        private readonly UserIpEDM _userIpEDM = new UserIpEDM();
        private readonly InfomationUserEDM _infomationUserEDM = new InfomationUserEDM();
        private readonly UserProfileADO _userProfileADO = new UserProfileADO();
        private readonly PermissionADO _permissionADO = new PermissionADO();
        private readonly static MemoryCache myCache = new MemoryCache(new MemoryCacheOptions());
        private ICacheBase _cache => new CacheMemoryHelper(myCache);

        public async Task<AuthenticationResult> LoginAccount(AuthenticationInput input, List<string> IpV4, List<string> IpV6)
        {
            // kiểm tra tài khoản và lấy thông tin tài khoản
            var dataAccount = (await _userProfileADO.GetAccountLogin(input.Account)).FirstOrDefault();
            if (dataAccount == null)
            {
                throw new ClientException(404, "ACCOUNT_OR_PASSWORD_NOT_EXIST");
            }

            // kiểm tra ip
            if (!IpConvertBC.IpCheck(dataAccount.Ipv4, IpV4) || !IpConvertBC.IpCheck(dataAccount.Ipv6, IpV6))
            {
                throw new ClientException(404, "UNABLE_TO_IDENTIFY_USER");
            }

            // kiểm tra online - quẳng vào kho một thông báo 
            //if (dataAccount.IsOnline)
            //{
            //    throw new ClientException(404, "ACCOUNT_ONLINE");
            //}
            // kiểm tra status
            //if (dataAccount.IsStatus == (int)UserProfileStatus.ACTIVE)
            //{
            //    throw new ClientException(404, "ACCOUNT_NEEDS_CONFIRMATION");
            //}

            // kiểm tra đăng nhập thất bại
            if (dataAccount.LoginFallNumber != 0 && dataAccount.LockAccountTime > DateTime.Now)
            {
                return new AuthenticationResult
                {
                    Status = 404,
                    Message = dataAccount.LockAccountTime.ToString("dd/MM/yyyy HH-mm-ss"),
                    Data = null
                };
            }
            var data = (await _userProfileADO.GetAccount(dataAccount.UserName)).FirstOrDefault();

            // kiểm tra mật khẩu
            if (!new ShiningAccount().CheckPassword(dataAccount, input.Password))
            {
                // lấy thông tin tài khoản và update lại số lần fail
                data = new ProcsssLoginPassword().ProcessLoginFail(data);
                await _userProfileEDM.Update(data);
                throw new ClientException(404, "ACCOUNT_OR_PASSWORD_NOT_EXIST");
            }
            else
            {
                data = new ProcsssLoginPassword().ProsessLoginSussce(data);
                await _userProfileEDM.Update(data);
            }

            // get permission
            var dataPermission = await _permissionADO.GetPermissionByUserName(dataAccount.UserName);
            ICheckRole checkRole = new CheckRoleService();

            var roleClient = await checkRole.GetRoleClient(dataPermission);
            var roleServer = await checkRole.GetRoleServer(dataPermission);
            // GUID cache 
            string guidCache = Guid.NewGuid().ToString();
            // lấy thông tin tài khoản
            var claims = new JwtCustomClaims
            {
                Id = guidCache,
                UserName = dataAccount.UserName,
                Email = dataAccount.Email
            };

            // xác thực token
            var token = new TokenToJWT().CreateTokenAccountUserJWT(claims);
            _cache.Add<string>(JsonConvert.SerializeObject(dataPermission), guidCache);

            // nhả token
            return new AuthenticationResult
            {
                Status = 200,
                Message = String.Empty,
                Data = new Data
                {
                    FullName = dataAccount.FirsName + " " + dataAccount.LastName,
                    Picture = dataAccount.Picture,
                    Tokens = token.Token
                }

            };

        }

        public async Task<bool> RegistrationAccount(UserProfileInsertDto input, string IpV4, string IpV6)
        {
            if (await _userProfileEDM.CheckEmailNumberPhoneUserName(email: input.Email, userName: input.UserName, numberPhone: input.NumberPhone))
            {
                throw new ClientException(404, "ACCOUNT_EXIST");
            }
            else
            {
                var dataUserProfile = new UserProfile
                {
                    UserName = input.UserName,
                    Email = input.Email,
                    NumberPhone = input.NumberPhone,
                    IsOnline = true,
                    IsStatus = 6,
                    LoginFallNumber = 0,
                    LockAccountTime = null,
                    CreateBy = 2
                };
                await _userProfileEDM.Insert(dataUserProfile);

                if (dataUserProfile.Id == 0)
                {
                    throw new ClientException(404, "ERROR_SYSTEM");
                }

                _userPasswordEDM.Insert(new ShiningAccount().SetupAccount(new UserPassword
                {
                    AccountId = dataUserProfile.Id,
                    Password = input.Password,
                    IsActive = true,
                    IsDelete = false,
                    CreateBy = 2
                }));


                _userIpEDM.Insert(new UserIp
                {
                    Ipv4 = IpV4,
                    Ipv6 = IpV6,
                    AccountId = dataUserProfile.Id,
                    UpdateAcount = 0,
                    IsActive = true,
                    IsDelete = false,
                    CreateBy = 2
                });

                _infomationUserEDM.Insert(new InfomationUser
                {
                    FirsName = RanDomBase.RandomString(5),
                    LastName = RanDomBase.RandomString(5),
                    Picture = "album/imageSystem/avatar-default.jpg",
                    Gender = 1,
                    Description = "",
                    IsActive = true,
                    AccountId = dataUserProfile.Id,
                    CreateBy = 2
                });

                //_userStatusEDM.Insert(new UserStatus
                //{
                //  AccountId = dataUserProfile.Id,
                //});

                var dataSubject = new Subject { UserId = dataUserProfile.Id, IsActive = true, CreateBy = 2 };
                await _subjectEDM.Insert(dataSubject);
                var dataSubjectFtResource = new SubjectAssignment { RoleId = 3, SubjectId = dataSubject.Id, IsActive = true, CreateBy = 2 };
                await _subjectEDM.InsertSubjectAssignment(dataSubjectFtResource);
                return true;
            }
        }

    }
}
