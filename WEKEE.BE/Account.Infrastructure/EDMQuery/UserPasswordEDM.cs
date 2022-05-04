using Account.Domain.Shared.Entitys;
using Account.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Text;
using UnitOfWork;

namespace Account.Infrastructure.EDMQuery
{
    public class UserPasswordEDM
    {
        private readonly IUnitOfWork<AuthorizationDBContext> unitOfWork =
                  new UnitOfWork<AuthorizationDBContext>(new AuthorizationDBContext());

        public void Insert(UserPassword userPassword)
        {
            unitOfWork.GetRepository<UserPassword>().Insert(userPassword);
            unitOfWork.SaveChanges();
        }
    }
}
