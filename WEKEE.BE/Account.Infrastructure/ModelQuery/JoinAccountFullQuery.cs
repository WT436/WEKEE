using Account.Infrastructure.DBContext;
using UnitOfWork;

namespace Account.Infrastructure.ModelQuery
{
    public class JoinAccountFullQuery
    {
        private readonly IUnitOfWork<AuthorizationContext> unitOfWork =
                         new UnitOfWork<AuthorizationContext>(new AuthorizationContext());
    }
}
