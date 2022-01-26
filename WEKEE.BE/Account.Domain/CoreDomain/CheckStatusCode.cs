using Account.Domain.Shared.Entitys;
using System;
using Utils.Exceptions;

namespace Account.Domain.CoreDomain
{
    public class CheckStatusCode
    {
        public bool CheckPerformance(UserAccountStatus userAccountStatus)
        {
            if (userAccountStatus.IsDelete == false)
            {
                // vẫn còn trong khoảng thời gian hiệu lực của token cũ hoặc code cũ
                if (userAccountStatus.IsActive && DateTime.Now < userAccountStatus.UpdatedAt.Add(new TimeSpan(0, 0, 0, (int)userAccountStatus.ReminderExpire)))
                    return true;
                else
                    return false;
            }
            else
            {
                throw new ClientException(400, "Account-does-not-exist!");
            }
        }
    }
}
