using Account.Domain.Entitys;
using Account.Domain.ObjectValues;
using Account.Domain.ObjectValues.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Utils.Any;
using Utils.Exceptions;
using Utils.Security;

namespace Account.Domain.CoreDomain
{
    // chỉnh sửa lại dữ liệu trước khi update vào db
    public class ShiningAccount
    {
        public UserLogin SetupAccount(UserLogin userAccount)
        {
            // [password_salt] 
            userAccount.PasswordSalt = RanDomBase.RandomString(10);
            // algorithm
            string pass = "";
            switch (RanDomBase.OnlyNumberRandom(0, 3))
            {
                case Algorithm.SHA256:
                    userAccount.PasswordHashAlgorithm = "SHA256";
                    pass = userAccount.Password + userAccount.PasswordSalt;
                    userAccount.Password = SecurityProcess.SHA256Hash(pass);
                    break;

                case Algorithm.SHA1:
                    userAccount.PasswordHashAlgorithm = "SHA1";
                    pass = userAccount.Password + userAccount.PasswordSalt;
                    userAccount.Password = SecurityProcess.SHA1Hash(pass);
                    break;

                default:
                    userAccount.PasswordHashAlgorithm = "MD5";
                    pass = userAccount.Password + userAccount.PasswordSalt;
                    userAccount.Password = SecurityProcess.MD5Hash(pass);
                    break;
            }

            return userAccount;
        }

        public bool CheckPassword(UserLogin userAccount, string password)
        {
            if (userAccount != null)
            {
                string pass = userAccount.PasswordHashAlgorithm switch
                {
                    "SHA256" => SecurityProcess.SHA256Hash(password + userAccount.PasswordSalt),
                    "SHA1" => SecurityProcess.SHA1Hash(password + userAccount.PasswordSalt),
                    _ => SecurityProcess.MD5Hash(password + userAccount.PasswordSalt),
                };

                if (userAccount.Password != pass)
                {
                    throw new ClientException(400, "Account Or Password Incorrect!");
                };

                return true;
            }
            else
            {
                throw new ClientException(400, "Account Or Password Incorrect!");
            }
        }
    }
}
