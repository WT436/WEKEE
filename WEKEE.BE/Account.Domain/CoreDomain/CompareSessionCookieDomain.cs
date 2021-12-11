using Account.Domain.Entitys;
using Utils.Auth.Dtos;

namespace Account.Domain.CoreDomain
{
    public class CompareSessionCookieDomain
    {
        public bool MapData(JwtCustomClaims jwtCustomClaims, UserLogin userAccount)
        {
            return jwtCustomClaims.Id == userAccount.Id
                && jwtCustomClaims.Email == userAccount.Email
                && jwtCustomClaims.Account_User == userAccount.UserName;
        }
    }
}
