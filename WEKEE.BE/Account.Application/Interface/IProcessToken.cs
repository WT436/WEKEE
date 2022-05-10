using Account.Domain.ObjectValues.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.Interface
{
    public interface IProcessToken
    {
        public ErrorOauth ValidateToken(string token, string validateToken);
        public Task<bool> RefreshToken(string token);
    }
}
