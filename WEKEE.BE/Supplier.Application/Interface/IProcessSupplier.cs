using Supplier.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using Utils.Auth.Dtos;

namespace Supplier.Application.Interface
{
    public interface IProcessSupplier
    {
        JwtResponse CreateToken(SupplierDtos userAccount, string ip);
    }
}
