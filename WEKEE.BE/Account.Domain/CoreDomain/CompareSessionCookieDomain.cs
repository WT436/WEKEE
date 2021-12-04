using Account.Domain.Entitys;
using Utils.Auth.Dtos;

namespace Account.Domain.CoreDomain
{
    public class CompareSessionCookieDomain
    {
        public bool MapData(JwtCustomClaims jwtCustomClaims, UserAccount userAccount)
        {
            return jwtCustomClaims.Id == userAccount.UserProfileId
                && jwtCustomClaims.Email == userAccount.Email
                && jwtCustomClaims.Account_User == userAccount.UserName;
        }
    }
}
