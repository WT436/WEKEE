using Supplier.Application.Interface;
using Supplier.Domain.Dto;
using Supplier.Infrastructure.MappingExtention;
using Supplier.Infrastructure.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utils.Any;
using Utils.Exceptions;
using Utils.Security;

namespace Supplier.Application.Application
{
    public class ASupplier : ISupplier
    {
        private readonly SupplierQueries _supplierQueries = new SupplierQueries();

        public async Task<SupplierDtos> CheckPassShop(int idAccount, string passShop)
        {
            var dataSupplier = await _supplierQueries.GetSupplierWithAccountID(id: idAccount);
            // check pass

            if (string.IsNullOrEmpty(passShop))
            {
                throw new ClientException(400, "Invalid Account or Password!");
            }
            if (
                RegexProcess.Regex_IsMatch(RegexProcess.SPECIAL_CHAR, passShop) || // không chứa ký tự đặc biệt
                !RegexProcess.Regex_IsMatch(RegexProcess.CHECK_NUMBER, passShop) || // ít nhất một chữ số
                !RegexProcess.Regex_IsMatch(RegexProcess.NUMBER_CHAR, passShop) ||  // số lượng ký tự cần có
                !RegexProcess.Regex_IsMatch(RegexProcess.CHAR_LETTER, passShop)     // số lượng Chữ in hoa cần có
                )
            {
                throw new ClientException(400, "Account Password includes [A-Z],[a-z],[0.9] and Password length 8, have at least one uppercase letter and number !");
            }

            if (dataSupplier != null)
            {
                string pass = dataSupplier.PasswordHashAlgorithm switch
                {
                    "SHA256" => SecurityProcess.SHA256Hash(passShop + dataSupplier.PasswordSalt),
                    "SHA1" => SecurityProcess.SHA1Hash(passShop + dataSupplier.PasswordSalt),
                    _ => SecurityProcess.MD5Hash(passShop + dataSupplier.PasswordSalt),
                };

                if (dataSupplier.PassWordShop != pass)
                {
                    throw new ClientException(400, "Password Incorrect!");
                };

                return MappingData.InitializeAutomapper().Map<SupplierDtos>(dataSupplier);
            }
            else
            {
                throw new ClientException(400, "Password Incorrect!");
            }

        }

        public async Task<SupplierDtos> GetdataSupplier(int idAccount, string numberPhone, string email,
                                                        string password, string haskPass,string passwordHashAlgorithm, string name)
        {
            var dataSupplier = await _supplierQueries.GetSupplierWithAccountID(id: idAccount);
            // check pass

            if (string.IsNullOrEmpty(password))
            {
                throw new ClientException(400, "Invalid Account or Password!");
            }
            if (
                RegexProcess.Regex_IsMatch(RegexProcess.SPECIAL_CHAR, password) || // không chứa ký tự đặc biệt
                !RegexProcess.Regex_IsMatch(RegexProcess.CHECK_NUMBER, password) || // ít nhất một chữ số
                !RegexProcess.Regex_IsMatch(RegexProcess.NUMBER_CHAR, password) ||  // số lượng ký tự cần có
                !RegexProcess.Regex_IsMatch(RegexProcess.CHAR_LETTER, password)     // số lượng Chữ in hoa cần có
                )
            {
                throw new ClientException(400, "Account Password includes [A-Z],[a-z],[0.9] and Password length 8, have at least one uppercase letter and number !");
            }

            if (dataSupplier == null)
            {
                dataSupplier = await _supplierQueries.CreateSupplier(new Domain.Entitys.Supplier
                {
                    NumberPhone = numberPhone,
                    Email = email,
                    PasswordSalt = haskPass,
                    PasswordHashAlgorithm = passwordHashAlgorithm,
                    PassWordShop = password,
                    NameShop = name,
                    LinkShop = "",
                    Adress = "",
                    IsActive = true,
                    UseAccount = idAccount
                });
            }

            return MappingData.InitializeAutomapper().Map<SupplierDtos>(dataSupplier);
        }
    }
}
