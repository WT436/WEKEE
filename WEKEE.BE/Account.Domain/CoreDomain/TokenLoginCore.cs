using Account.Domain.BoundedContext;
using Account.Domain.Shared.DataTransfer.ResourceDTO;
using Account.Domain.Shared.DataTransfer.UserProfileDTO;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Utils.Auth;
using Utils.Auth.Dtos;
using Utils.Cache;
using Utils.Security;

namespace Account.Domain.CoreDomain
{
    public class TokenLoginCore
    {
        private readonly static MemoryCache myCache = new MemoryCache(new MemoryCacheOptions());

        private ICacheBase _cache => new CacheMemoryHelper(myCache);

        public AuthenticationResult ProcessResultToken(UserProfileLoginReadDto dataAccount, List<UserGetPermission> dataPermission)
        {
            // GUID cache 
            string guidCache = Guid.NewGuid().ToString();

            // lấy thông tin tài khoản
            var claims = new JwtCustomClaims
            {
                Id = guidCache,
                UserName = dataAccount.UserName,
                Email = dataAccount.Email
            };

            // xác thực token
            var token = new JwtHandler().CreateToken(claims);
            var access = new ASE256Process().EncryptAES256ToString(JsonConvert.SerializeObject(claims), guidCache);

            _cache.Add<string>(JsonConvert.SerializeObject(dataPermission), guidCache);

            // nhả token
            return new AuthenticationResult
            {
                Status = 200,
                Message = String.Empty,
                Data = new Data
                {
                    FullName = dataAccount.FirsName + " " + dataAccount.LastName,
                    Picture = dataAccount.Picture,
                    Tokens = token.Token,
                    Access = access
                }
            };
        }
    }
}
