using Account.Application.Interface;
using Account.Domain.CoreDomain;
using Account.Domain.Shared.DataTransfer.UserProfileDTO;
using Account.Domain.Shared.Entitys;
using Account.Infrastructure.EDMQuery;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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

                //_userStatusEDM.Insert(new UserStatus
                //{
                //  AccountId = dataUserProfile.Id,
                //});

                var dataSubject = new Subject { UserId = dataUserProfile.Id, IsActive = true, CreateBy = 2 };
                await _subjectEDM.Insert(dataSubject);
                var dataSubjectFtResource = new SubjectAssignment { RoleId = 3, SubjectId = dataSubject.Id, IsActive = true, CreateBy = 2 };
                _subjectEDM.InsertSubjectAssignment(dataSubjectFtResource);
                return true;
            }
        }
    }
}
