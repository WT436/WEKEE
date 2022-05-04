using Account.Domain.ObjectValues.Enum;
using Account.Domain.Shared.Entitys;
using System;
using System.Collections.Generic;
using System.Text;
using Utils.Any;
using Utils.Exceptions;
using Utils.Security;

namespace Account.Domain.CoreDomain
{
    public class ShiningAccount
    {
        public UserPassword SetupAccount(UserPassword userPassword)
        {
            // [password_salt] 
            userPassword.PasswordSalt = RanDomBase.RandomString(10);
            // algorithm
            string pass =String.Empty;
            switch (RanDomBase.OnlyNumberRandom(0, 3))
            {
                case (int)Algorithm.SHA256:
                    userPassword.PasswordHashAlgorithm = "SHA256";
                    pass = userPassword.Password + userPassword.PasswordSalt;
                    userPassword.Password = SecurityProcess.SHA256Hash(pass);
                    break;

                case (int)Algorithm.SHA1:
                    userPassword.PasswordHashAlgorithm = "SHA1";
                    pass = userPassword.Password + userPassword.PasswordSalt;
                    userPassword.Password = SecurityProcess.SHA1Hash(pass);
                    break;

                default:
                    userPassword.PasswordHashAlgorithm = "MD5";
                    pass = userPassword.Password + userPassword.PasswordSalt;
                    userPassword.Password = SecurityProcess.MD5Hash(pass);
                    break;
            }

            return userPassword;
        }

        //public bool CheckPassword(UserLogin userAccount, string password)
        //{
        //    if (userAccount != null)
        //    {
        //        string pass = userAccount.PasswordHashAlgorithm switch
        //        {
        //            "SHA256" => SecurityProcess.SHA256Hash(password + userAccount.PasswordSalt),
        //            "SHA1" => SecurityProcess.SHA1Hash(password + userAccount.PasswordSalt),
        //            _ => SecurityProcess.MD5Hash(password + userAccount.PasswordSalt),
        //        };

        //        if (userAccount.Password != pass)
        //        {
        //            throw new ClientException(400, "Account Or Password Incorrect!");
        //        };

        //        return true;
        //    }
        //    else
        //    {
        //        throw new ClientException(400, "Account Or Password Incorrect!");
        //    }
        //}
    }
}
