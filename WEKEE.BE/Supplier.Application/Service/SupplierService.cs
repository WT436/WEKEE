using Supplier.Domain.Shared.DataTransfer;
using Supplier.Infrastructure.Queries;
using System.Threading.Tasks;
using Utils.Any;
using Utils.Exceptions;
using Utils.Security;

namespace Supplier.Application.Service
{
    public interface ISupplier
    {
        //Task<SupplierDtos> GetdataSupplier(int idAccount, string numberPhone, string email,
        //                                   string password, string haskPass, string passwordHashAlgorithm, string name);
        //Task<SupplierDtos> CheckPassShop(int idAccount, string passShop);

        Task<bool> CreateBasicStore(SupplierCreateBasicDtos input);
    }

    public class SupplierService : ISupplier
    {
        private readonly SupplierQueries _supplierQueries = new SupplierQueries();
        private readonly SupplierMappingQueries _supplierMappingQueries = new SupplierMappingQueries();

        public async Task<bool> CreateBasicStore(SupplierCreateBasicDtos input)
        {
            if (input.IdAccount == 0)
            {
                throw new ClientException(402, "ACCOUNT_LOGIN");
            }
            // Kiem tra store
            if (await _supplierMappingQueries.CheckStoreByBoss(input.IdAccount))
            {
                throw new ClientException(405, "NOT_CREATE_STORE");
            }
            // convert data
            // check NameShop, LinkShop , NumberPhone ,[Email]
            if (await _supplierQueries.CheckAnyStoreCreate(link: input.Link, name: input.Name,
                                                            phone: input.NumberPhone, email: input.Email))
            {
                throw new ClientException(405, "ANY_STORE");
            }

            // Tạo mới store
            string haskPass = RanDomBase.RandomString(10);
            string pass = SecurityProcess.MD5Hash(input.PassWordShop + haskPass);
            var store = await _supplierQueries.CheckAnyStoreCreate(new Domain.Shared.Entitys.Supplier
            {
                NumberPhone = input.NumberPhone,
                Email = input.Email,
                PassWordShop = pass,
                HaskPass = haskPass,
                NameShop = input.NameShop,
                LinkShop = input.Link,
            });

            if (store.Id == 0)
            {
                throw new ClientException(405, "ANY_STORE");
            }

            // Map store
            await _supplierMappingQueries.CreateMapping(new Domain.Shared.Entitys.SupplierMapping
            {
                SupplierId = store.Id,
                UseAccount = input.IdAccount,
                IsBoss = true,
                Active = true,
                Deleted = false
            });

            // trả về store
            return true;
        }

        //public async Task<SupplierDtos> CheckPassShop(int idAccount, string passShop)
        //{
        //    var dataSupplier = await _supplierQueries.GetSupplierWithAccountID(id: idAccount);
        //    // check pass

        //    if (string.IsNullOrEmpty(passShop))
        //    {
        //        throw new ClientException(400, "Invalid Account or Password!");
        //    }
        //    if (
        //        RegexProcess.Regex_IsMatch(RegexProcess.SPECIAL_CHAR, passShop) || // không chứa ký tự đặc biệt
        //        !RegexProcess.Regex_IsMatch(RegexProcess.CHECK_NUMBER, passShop) || // ít nhất một chữ số
        //        !RegexProcess.Regex_IsMatch(RegexProcess.NUMBER_CHAR, passShop) ||  // số lượng ký tự cần có
        //        !RegexProcess.Regex_IsMatch(RegexProcess.CHAR_LETTER, passShop)     // số lượng Chữ in hoa cần có
        //        )
        //    {
        //        throw new ClientException(400, "Account Password includes [A-Z],[a-z],[0.9] and Password length 8, have at least one uppercase letter and number !");
        //    }

        //    if (dataSupplier != null)
        //    {
        //        string pass = SecurityProcess.MD5Hash(passShop + dataSupplier.HaskPass);

        //        if (dataSupplier.PassWordShop != pass)
        //        {
        //            throw new ClientException(400, "Password Incorrect!");
        //        };

        //        return MappingData.InitializeAutomapper().Map<SupplierDtos>(dataSupplier);
        //    }
        //    else
        //    {
        //        throw new ClientException(400, "Password Incorrect!");
        //    }

        //}

        //public async Task<SupplierDtos> GetdataSupplier(int idAccount, string numberPhone, string email,
        //                                                string password, string haskPass,string passwordHashAlgorithm, string name)
        //{
        //    var dataSupplier = await _supplierQueries.GetSupplierWithAccountID(id: idAccount);
        //    // check pass

        //    if (string.IsNullOrEmpty(password))
        //    {
        //        throw new ClientException(400, "Invalid Account or Password!");
        //    }
        //    if (
        //        RegexProcess.Regex_IsMatch(RegexProcess.SPECIAL_CHAR, password) || // không chứa ký tự đặc biệt
        //        !RegexProcess.Regex_IsMatch(RegexProcess.CHECK_NUMBER, password) || // ít nhất một chữ số
        //        !RegexProcess.Regex_IsMatch(RegexProcess.NUMBER_CHAR, password) ||  // số lượng ký tự cần có
        //        !RegexProcess.Regex_IsMatch(RegexProcess.CHAR_LETTER, password)     // số lượng Chữ in hoa cần có
        //        )
        //    {
        //        throw new ClientException(400, "Account Password includes [A-Z],[a-z],[0.9] and Password length 8, have at least one uppercase letter and number !");
        //    }

        //    if (dataSupplier == null)
        //    {
        //        dataSupplier = await _supplierQueries.CreateSupplier(new Domain.Entitys.Supplier
        //        {
        //            NumberPhone = Convert.ToDecimal(numberPhone),
        //            Email = email,
        //            HaskPass = haskPass,
        //            PassWordShop = password,
        //            NameShop = name,
        //            LinkShop = "",
        //            Adress = "",
        //            IsActive = true
        //        });
        //    }
        //    return MappingData.InitializeAutomapper().Map<SupplierDtos>(dataSupplier);
        //}
    }
}
