using Account.Domain.ObjectValues.ConstProperty;
using Account.Domain.Shared.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.BoundedContext
{
    public class ProcsssLoginPassword
    {
        public UserProfile ProcessLoginFail(UserProfile input)
        {
            input.LoginFallNumber++;

            if (input.LoginFallNumber == 5)
            {
                input.LockAccountTime = DateTime.Now.AddMinutes(5);
            }

            if (input.LoginFallNumber == 10)
            {
                input.IsStatus = (int)UserProfileStatus.LOGGING_WRONG;
                input.LockAccountTime = DateTime.Now.AddDays(50);
            }

            return input;
        }
        public UserProfile ProsessLoginSussce(UserProfile input)
        {
            input.LoginFallNumber = 0;
            input.LockAccountTime = null;
            return input;
        }
    }
}
