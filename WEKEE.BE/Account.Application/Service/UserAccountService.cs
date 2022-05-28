
using Account.Domain.BoundedContext;
using Account.Domain.CoreDomain;
using Account.Domain.ObjectValues.ConstProperty;
using Account.Domain.Shared.DataTransfer.ResourceDTO;
using Account.Domain.Shared.DataTransfer.UserProfileDTO;
using Account.Domain.Shared.Entitys;
using Account.Infrastructure.ADOQuery;
using Account.Infrastructure.EDMQuery;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Any;
using Utils.Auth;
using Utils.Auth.Dtos;
using Utils.Cache;
using Utils.Exceptions;
using Utils.Security;

namespace Account.Application.Service
{
    public interface IUserAccount
    {
        Task<bool> RegistrationAccount(UserProfileInsertDto input, string IpV4, string IpV6);

        Task<AuthenticationResult> LoginAccount(AuthenticationInput input, List<string> IpV4, List<string> IpV6);

        Task<AuthenticationResult> RefreshTokenAccount(string token, List<string> IpV4, List<string> IpV6);

        Task<AuthenticationResult> LoginOAuthV2(AuthenV2ReadDto input, List<string> IpV4, List<string> IpV6);
    }

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

        public async Task<AuthenticationResult> LoginAccount(AuthenticationInput input, List<string> IpV4, List<string> IpV6)
        {
            // kiểm tra tài khoản và lấy thông tin tài khoản
            var dataAccount = (await _userProfileADO.GetAccountLogin(input.Account)).FirstOrDefault();

            if (dataAccount == null)
            {
                throw new ClientException(404, "ACCOUNT_OR_PASSWORD_NOT_EXIST");
            }

            // Kiểm tra IP
            new IpConvertBC().CheckIp(IpV4: dataAccount.Ipv4, IpV6: dataAccount.Ipv6, IpV4s: IpV4, IpV6s: IpV6);

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

            return new TokenLoginCore().ProcessResultToken(dataAccount: dataAccount, dataPermission: dataPermission);
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
                    IsStatus = (int)UserProfileStatus.SPEED_ACCOUNT,
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
        public async Task<AuthenticationResult> RefreshTokenAccount(string tokenInput, List<string> IpV4, List<string> IpV6)
        {
            var dataToken = new JwtHandler().ReadFullInfomation(tokenInput);

            if (dataToken == null)
            {
                throw new ClientException(404, "YOU_NEED_LOGIN");
            }

            //var _cacheHistory = _cache.Get<List<UserGetPermission>>(dataToken.Id);

            //if (_cacheHistory == null)
            //{
            //    throw new ClientException(404, "YOU_NEED_LOGIN");
            //}

            var dataAccount = (await _userProfileADO.GetAccountLogin(dataToken.UserName)).FirstOrDefault();

            if (dataAccount == null)
            {
                throw new ClientException(404, "ACCOUNT_OR_PASSWORD_NOT_EXIST");
            }

            // Kiểm tra IP
            new IpConvertBC().CheckIp(IpV4: dataAccount.Ipv4, IpV6: dataAccount.Ipv6, IpV4s: IpV4, IpV6s: IpV6);

            // GUID cache 
            string guidCache = Guid.NewGuid().ToString();

            // lấy thông tin tài khoản
            var claims = new JwtCustomClaims
            {
                Id = guidCache,
                UserName = dataAccount.UserName,
                Email = dataAccount.Email
            };

            //if (_cacheHistory == null)
            //{
            //    // get permission
            //    var dataPermission = await _permissionADO.GetPermissionByUserName(dataAccount.UserName);
            //    ICheckRole checkRole = new CheckRoleService();

            //    var roleClient = await checkRole.GetRoleClient(dataPermission);
            //    var roleServer = await checkRole.GetRoleServer(dataPermission);

            //    _cacheHistory = dataPermission;
            //}

            //_cache.Remove(dataToken.Id);
            //_cache.Add<string>(JsonConvert.SerializeObject(_cacheHistory), guidCache);

            // xác thực token
            var token = new JwtHandler().CreateToken(claims);

            var access = new ASE256Process().EncryptAES256ToString(DateTime.Now.ToString(), guidCache);
            // nhả token
            return new AuthenticationResult
            {
                Status = 200,
                Message = String.Empty,
                Data = new Data
                {
                    FullName = dataAccount.FirsName + " " + dataAccount.LastName,
                    Picture = dataAccount.Picture,
                    Tokens = token.Token,
                    Access = access
                }
            };
        }
        public async Task<AuthenticationResult> LoginOAuthV2(AuthenV2ReadDto input, List<string> IpV4, List<string> IpV6)
        {
            // kiểm tra email tồn tại
            var data = (await _userProfileADO.GetAccountLoginByEmail(email: input.Email)).FirstOrDefault();
            // cập nhật or update
            if (data == null)
            {
                await CreateAccountNoPassword(input: input, IpV4: IpV4, IpV6: IpV6);
            }
            else
            {
                await UpdateAccountNoPassword(input: input, IpV4: IpV4, IpV6: IpV6);
            }

            return await LoginAccountNoPassword(input: input, IpV4: IpV4, IpV6: IpV6);
        }

        private async Task<bool> CreateAccountNoPassword(AuthenV2ReadDto input, List<string> IpV4, List<string> IpV6)
        {
            var dataUserProfile = new UserProfile
            {
                UserName = input.Email[..input.Email.IndexOf("@")],
                Email = input.Email,
                NumberPhone = "",
                IsOnline = false,
                IsStatus = (int)UserProfileStatus.SPEED_ACCOUNT,
                LoginFallNumber = 0,
                LockAccountTime = null,
                GoogleId = input.Id,
                CreateBy = 2
            };
            await _userProfileEDM.Insert(dataUserProfile);

            if (dataUserProfile.Id == 0)
            {
                throw new ClientException(404, "ERROR_SYSTEM");
            }

            string ipv4String = string.Empty;
            string ipv6String = string.Empty;

            IpV4.ForEach(n => ipv4String = ipv4String + n.ToString() + "|");
            IpV6.ForEach(n => ipv6String = ipv6String + n.ToString() + "|");

            _userIpEDM.Insert(new UserIp
            {
                Ipv4 = ipv4String,
                Ipv6 = ipv6String,
                AccountId = dataUserProfile.Id,
                UpdateAcount = 0,
                IsActive = true,
                IsDelete = false,
                CreateBy = 2
            });

            _infomationUserEDM.Insert(new InfomationUser
            {
                FirsName = input.FirstName,
                LastName = input.LastName,
                Picture = input.Avatar,
                Gender = 1,
                Description = "",
                IsActive = true,
                AccountId = dataUserProfile.Id,
                CreateBy = 2
            });

            var dataSubject = new Subject { UserId = dataUserProfile.Id, IsActive = true, CreateBy = 2 };
            await _subjectEDM.Insert(dataSubject);
            var dataSubjectFtResource = new SubjectAssignment { RoleId = 3, SubjectId = dataSubject.Id, IsActive = true, CreateBy = 2 };
            await _subjectEDM.InsertSubjectAssignment(dataSubjectFtResource);
            return true;
        }
        private async Task<bool> UpdateAccountNoPassword(AuthenV2ReadDto input, List<string> IpV4, List<string> IpV6)
        {
            return true;
        }
        private async Task<AuthenticationResult> LoginAccountNoPassword(AuthenV2ReadDto input, List<string> IpV4, List<string> IpV6)
        {
            return null;
        }
    }
}
