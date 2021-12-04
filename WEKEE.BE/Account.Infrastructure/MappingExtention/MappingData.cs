using AutoMapper;

namespace Account.Infrastructure.MappingExtention
{
    public static class MappingData
    {
        public static IMapper InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                AccountConfig.CreateMap(cfg);
                PermissionConfig.CreateMap(cfg);
            });
            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}
