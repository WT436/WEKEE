using Account.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Exceptions;

namespace Account.Domain.CoreDomain
{
    public class CheckStatusAccount
    {
        public async Task<bool> StatusAccount(UserAccount userAccount)
        {
            if (userAccount == null)
            {
                throw new ClientException(400, "Account Or Password Incorrect!");
            }

            if (userAccount.LockAccountTime >= DateTime.Now || userAccount.LoginFallNumber >= 20)
            {
                throw new ClientException(400, "Your account will locking until " + userAccount.LockAccountTime?.ToString("hh:mm:ss dd/MM/yyyy") + "because of wrong login " + userAccount.LoginFallNumber + " times!"); ;
            }

            return true;
        }

        public void CheckExitsAccount(bool dataAcount)
        {
            if (dataAcount)
            {
                throw new ClientException(400, "Account already exists!");
            }
        }

        public void CheckExitsEmail(bool dataEmail)
        {
            if (dataEmail)
            {
                throw new ClientException(400, "Email already exists!");
            }
        }

        public void CheckExits(bool dataAcount)
        {
            if (dataAcount)
            {
                throw new ClientException(400, "Account already exists!");
            }
        }
        public bool CheckExistsIpAccount(IList<UserAccountIp> userAccountIps, string ip)
        {
            return userAccountIps.Where(m => m.Ip == ip).Count() == 1;
            //throw new CustomerException(401, "You need to confirm your identity!");
        }

    }
}
