using Account.Domain.Shared.DataTransfer;
using Account.Domain.Shared.Entitys;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Infrastructure.MappingExtention
{
    public class AccountConfig
    {
        public static void CreateMap(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<UserProfile, AccountDtos>();
            cfg.CreateMap<AccountDtos, UserProfile>();

            cfg.CreateMap<UserAccountDtos, UserLogin>();
            cfg.CreateMap<UserLogin, UserAccountDtos>();
        }
    }
}
