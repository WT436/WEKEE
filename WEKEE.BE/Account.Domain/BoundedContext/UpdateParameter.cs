using Account.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.BoundedContext
{
    public class UpdateParameter
    {
        public UserAccountStatus UpdateAccountStatus(UserAccountStatus accountStatus)
        {
            accountStatus.UpdatedAt = DateTime.Now;
            accountStatus.ReminderExpire = 5 * 60;
            accountStatus.UpdateCount++;
            return accountStatus;
        }
    }
}
