using Account.Application.Interface;
using Account.Domain.BoundedContext;
using Account.Domain.ObjectValues.Enum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utils.Auth;
using Utils.Auth.Dtos;
using Utils.Security;

namespace Account.Application.Service
{
    public class ProcessTokenService : IProcessToken
    {
        private readonly IJwtHandler _jwtHandler = new JwtHandler();
        public Task<bool> RefreshToken(string token)
        {
            throw new NotImplementedException();
        }

        public ErrorOauth ValidateToken(string token, string validateToken)
        {
            if (token == null && validateToken == null) // chưa có token
            {
                return ErrorOauth.NO_TOKEN;
            }

            var result = _jwtHandler.ValidateToken(token);

            if(!result) // token hết hạn
            {
                // read tokenHistory
                var dataToken = _jwtHandler.ReadFullHisTory(token);
                if (dataToken.Id == null)
                {
                    return ErrorOauth.NO_TOKEN;
                }

                var dataVali = JsonConvert.DeserializeObject<JwtCustomClaims>(new ASE256Process().DecryptAES256ToString(validateToken, dataToken.Id));
                if (dataVali == null)
                {
                    return ErrorOauth.NO_VALIDATE;
                }
            }

            return ErrorOauth.SUCCESS;
        }
    }
}
