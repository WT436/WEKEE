using Account.Application.Interface;
using Account.Domain.BoundedContext;
using Account.Domain.Dto;
using Account.Domain.Entitys;
using Account.Infrastructure.ModelQuery;
using Microsoft.Extensions.Primitives;
using System;
using System.Linq;
using System.Threading.Tasks;
using Utils.Auth.Dtos;

namespace Account.Application.Application
{
    public class ProcessAccount : IProcessAccount
    {
        private readonly UserAccountQuery userAccountQuery = new UserAccountQuery();
        private readonly TokenToJWT tokenToJWT = new TokenToJWT();
        private readonly UserProfileQuery userProfileQuery = new UserProfileQuery();

        public async Task<UserAccount> ProcessTokenAsync(StringValues token, string ip)
        {
            //string tokenProcess = token.FirstOrDefault().Split(" ")[1];
            var dataClaims = token == "" ? null : await tokenToJWT.DecryptionTokenAsync(token);
            // xác nhận token và ip có trong token và csdl
            if (dataClaims != null && dataClaims.Ip == ip /*&& !await userAccountQuery.CheckExitsIP(ip)*/)
                return await userAccountQuery.GetAllInToken(dataClaims);
            else
                return null;
        }

        public JwtCustomClaims ProcessToken(string token)
        {
            return tokenToJWT.DecryptionToken(token);
        }

        public JwtResponse CreateToken(UserAccountDtos userAccount, string ip)
        {
            // thêm vào token ip khi máy có ip như vậy đăng nhập vào hệ thống với đứng tài khoản mật khẩu
            return tokenToJWT.CreateTokenAccountUserJWT(userAccount, ip);
        }

        public Task<JwtResponse> CreateTokenAsync(UserAccount userAccount, string ip)
        {
            throw new System.NotImplementedException();
        }

        public bool CompareSessionCookie(JwtCustomClaims jwtCustomClaims, SessionCustom sessionCustom, string Ip)
        {
            var isAccount_User = jwtCustomClaims.Account_User == sessionCustom.Account_User;
            var isEmail = jwtCustomClaims.Email == sessionCustom.Email;
            var isId = jwtCustomClaims.Id == sessionCustom.Id_User;
            var isIp = jwtCustomClaims.Ip == sessionCustom.Ip && jwtCustomClaims.Ip == Ip && sessionCustom.Ip == Ip;
            return isAccount_User && isEmail && isId && isIp;
        }

        public Task<bool> CompareSessionCookieAsync(JwtCustomClaims jwtCustomClaims, SessionCustom sessionCustom, string Ip)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetNameAccount(int id)
                 =>  (await userProfileQuery.GetUniqueId(idUser: id)).FullName;
    }
}