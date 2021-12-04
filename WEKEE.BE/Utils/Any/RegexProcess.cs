using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Utils.Any
{
    public static class RegexProcess
    {
        public static readonly string SPECIAL_CHAR = "[+=`!#$%*()'\":;<>?]";//kiem tra ky tu dac  biet
        public static readonly string CHECK_NUMBER = "[0-9]{1,}";// kiem tra so it nhat 1
        public static readonly string DOUBLE_NORMAL_CHAR = "[a-z]{1,}";//kiểm tra ký tự thường xuất hiện  2 lần trở lên
        public static readonly string NUMBER_CHAR = ".{8,}";//so luong ky tu can co
        public static readonly string CHAR_LETTER = "[A-Z]{1,}";//ky tu in hoa phai co mot
        public static readonly string CHECK_TYPES_EMAIL = "[a-zA-Z0-9]{0,}([.]?[a-zA-Z0-9]{1,})[@](gmail.com)"; //test gamil
        public static readonly string KT7 = "[+=`!#$%&*()'\":;<>?]";
        public static readonly string KT8 = @" ^[-+]?[0 - 9] *\.?[0-9]+$";
        public static readonly string CHECK_TEN_CHAR = "^.{0,10}$";// co 10 ky tu
        public static readonly string KT10 = "[+`!#$%&*()'\":;<>,?]";
        public static readonly string CHECK_SPACE = "^[^\\s]+$";//khoảng trắng
        public static readonly string KT12 = "[A-Z]{1,}";
        public static readonly string CHECK_URL = "[+`!#$%*()'\":\\;<>]";// kiểm tra ký tự đặc biệt trên url

        public static bool Regex_IsMatch(string Rexge, string str)
        {
            return Regex.IsMatch(str, Rexge);
        }
    }
}
