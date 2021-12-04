using Account.Domain.Dto;
using Account.Domain.Entitys;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.IO;
using System.Threading.Tasks;
using Utils.Auth;
using Utils.Auth.Dtos;

namespace Account.Domain.BoundedContext
{
    public class TokenToJWT
    {
        private static IJwtHandler _jwtHandler;
        private static IOptions<ExternalClientJsonConfiguration> options;
        private static readonly ExternalClientJsonConfiguration externalClientJsonConfiguration = new ExternalClientJsonConfiguration();

        public TokenToJWT()
        {
            ReadFileJsonForJWT();
            SettingJWT();
        }
        /// <summary>
        /// Đọc dữ liệu token
        /// </summary>
        /// <param name="Token"></param>
        /// <returns></returns>
        public async Task<JwtCustomClaims> DecryptionTokenAsync(string Token)
        {
            return _jwtHandler.ReadFullInfomation(Token);
        }
        /// <summary>
        /// Đọc dữ liệu token
        /// </summary>
        /// <param name="Token"></param>
        /// <returns></returns>
        public JwtCustomClaims DecryptionToken(string Token)
        {
            return _jwtHandler.ReadFullInfomation(Token);
        }
        /// <summary>
        /// Tạo mới token
        /// </summary>
        /// <param name="userAccount"></param>
        /// <returns></returns>
        public JwtResponse CreateTokenAccountUserJWT(UserAccountDtos userAccount, string ip)
        {
            return _jwtHandler.CreateToken(new JwtCustomClaims()
            {
                Id = userAccount.UserProfileId,
                Account_User = userAccount.UserName,
                Email = userAccount.Email,
                Ip = ip
            });
        }
        /// <summary>
        /// Đọc file json để lấy key cho sự giải nén JWT 
        /// </summary>
        private void ReadFileJsonForJWT()
        {
            if (externalClientJsonConfiguration.Issuer == null)
            {
                var configurationBuilder = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile("appsettings.json")
                     .Build();
                configurationBuilder.GetSection("ExternalClientServer")
                    .Bind(externalClientJsonConfiguration);

                options = Options.Create(externalClientJsonConfiguration);
            }
        }

        /// <summary>
        /// Cài đặt để sử dụng file giải nén JWT
        /// </summary>
        private void SettingJWT()
        {
            if (_jwtHandler == null)
            {
                _jwtHandler = new JwtHandler(options);
            }
        }

    }
}
