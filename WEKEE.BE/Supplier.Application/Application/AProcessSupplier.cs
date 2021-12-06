using Supplier.Application.Interface;
using Supplier.Domain.BoundedContext;
using Supplier.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using Utils.Auth.Dtos;

namespace Supplier.Application.Application
{
    public class AProcessSupplier : IProcessSupplier
    {
        private readonly TokenToJWT tokenToJWT = new TokenToJWT();
        public JwtResponse CreateToken(SupplierDtos userAccount, string ip)
        {
            // thêm vào token ip khi máy có ip như vậy đăng nhập vào hệ thống với đứng tài khoản mật khẩu
            return tokenToJWT.CreateTokenAccountUserJWT(userAccount, ip);
        }
    }
}
