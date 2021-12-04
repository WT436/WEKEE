using Account.Domain.Dto;
using Account.Domain.Entitys;
using Utils.Any;
using Utils.Exceptions;

namespace Account.Domain.CoreDomain
{
    public class CheckAccountDomain
    {
        public void CheckInputAccount(AccountDtos accountDto)
        {
            if (string.IsNullOrEmpty(accountDto.Account) || string.IsNullOrEmpty(accountDto.Password))
            {
                throw new ClientException(400, "Invalid Account or Password!");
            }
            if (RegexProcess.Regex_IsMatch(RegexProcess.SPECIAL_CHAR, accountDto.Account) ||  // không chứa ký tự đặc biệt
                RegexProcess.Regex_IsMatch(RegexProcess.SPECIAL_CHAR, accountDto.Password) || // không chứa ký tự đặc biệt
                !RegexProcess.Regex_IsMatch(RegexProcess.CHECK_NUMBER, accountDto.Password) || // ít nhất một chữ số
                !RegexProcess.Regex_IsMatch(RegexProcess.NUMBER_CHAR, accountDto.Password) ||  // số lượng ký tự cần có
                !RegexProcess.Regex_IsMatch(RegexProcess.CHAR_LETTER, accountDto.Password)     // số lượng Chữ in hoa cần có
                )
            {
                throw new ClientException(400, "Account Password includes [A-Z],[a-z],[0.9] and Password length 8, have at least one uppercase letter and number !");
            }

            if (!RegexProcess.Regex_IsMatch(RegexProcess.CHECK_TYPES_EMAIL, accountDto.Email))
            {
                throw new ClientException(400, "Invalid Email!");
            }

            if (string.IsNullOrEmpty(accountDto.First_name) || string.IsNullOrEmpty(accountDto.First_name) || string.IsNullOrEmpty(accountDto.Full_name))
            {
                throw new ClientException(400, "First name, Last name, Full name must not be omitted!");
            }

            if (accountDto.Number_Phone.Length < 10 || accountDto.Number_Phone.Length > 15)
            {
                throw new ClientException(400, "Invalid phone number!");
            }
        }

        public void CheckLoginAccount(AuthenticationInput loginDtos)
        {
            if (string.IsNullOrEmpty(loginDtos.Account) || string.IsNullOrEmpty(loginDtos.Password))
            {
                throw new ClientException(400, "Invalid Account or Password!");
            }
            if (RegexProcess.Regex_IsMatch(RegexProcess.SPECIAL_CHAR, loginDtos.Account) ||  // không chứa ký tự đặc biệt
                RegexProcess.Regex_IsMatch(RegexProcess.SPECIAL_CHAR, loginDtos.Password) || // không chứa ký tự đặc biệt
                !RegexProcess.Regex_IsMatch(RegexProcess.CHECK_NUMBER, loginDtos.Password) || // ít nhất một chữ số
                !RegexProcess.Regex_IsMatch(RegexProcess.NUMBER_CHAR, loginDtos.Password) ||  // số lượng ký tự cần có
                !RegexProcess.Regex_IsMatch(RegexProcess.CHAR_LETTER, loginDtos.Password)     // số lượng Chữ in hoa cần có
                )
            {
                throw new ClientException(400, "Account Password includes [A-Z],[a-z],[0.9] and Password length 8, have at least one uppercase letter and number !");
            }
        }

        public void CheckPassWord(string passWord)
        {
            if (string.IsNullOrEmpty(passWord))
            {
                throw new ClientException(400, "Invalid Password!");
            }
            if (RegexProcess.Regex_IsMatch(RegexProcess.SPECIAL_CHAR, passWord) || // không chứa ký tự đặc biệt
                !RegexProcess.Regex_IsMatch(RegexProcess.CHECK_NUMBER, passWord) || // ít nhất một chữ số
                !RegexProcess.Regex_IsMatch(RegexProcess.NUMBER_CHAR, passWord) ||  // số lượng ký tự cần có
                !RegexProcess.Regex_IsMatch(RegexProcess.CHAR_LETTER, passWord)     // số lượng Chữ in hoa cần có
                )
            {
                throw new ClientException(400, "Password includes [A-Z],[a-z],[0.9] , Password length 8, have at least one uppercase letter and number !");
            }
        }

        public void CheckAccount(string account)
        {
            if (string.IsNullOrEmpty(account))
            {
                throw new ClientException(400, "Invalid Account or Password!");
            }
            if (RegexProcess.Regex_IsMatch(RegexProcess.SPECIAL_CHAR, account))  // không chứa ký tự đặc biệt
            {
                throw new ClientException(400, "The account does not contain special characters!");
            }
        }

        public void CheckEmail(string email)
        {
            if (!RegexProcess.Regex_IsMatch(RegexProcess.CHECK_TYPES_EMAIL, email))
            {
                throw new ClientException(400, "Invalid Email!");
            }
        }

        public void CheckDataAccount(UserAccount accountDto)
        {
            if(accountDto== null)
            {
                throw new ClientException(400, "Invalid Account or Password!");
            }
        }
    }
}
