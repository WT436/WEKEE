using System;
using System.Collections.Generic;
using System.Text;

namespace Utils.Auth.Dtos
{
    public class JwtCustomClaims
    {
        /// <summary>
        /// Id của tài khoản
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Tên tài khoản
        /// </summary>
        public string Account_User { get; set; } 
        /// <summary>
        /// Email của tài khoản
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Ip của tài khoản
        /// </summary>
        public string Ip { get; set; }
    }
}
