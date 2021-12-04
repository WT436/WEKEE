using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Dto
{
    public class SessionCustom
    {
        /// <summary>
        /// id của session
        /// </summary>
        public string Id_Session { get; set; } = Guid.NewGuid().ToString();
        /// <summary>
        /// Id của tài khoản
        /// </summary>
        public int Id_User { get; set; }
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
        /// <summary>
        /// Quyền của người dùng
        /// </summary>
        public List<RoleAuthDtos> Role { get; set; }
        /// <summary>
        /// Hạn sử dụng của session tối đa là 5h
        /// </summary>
        public DateTime ExpiryDate { get; set; } = DateTime.Now.AddHours(5);
    }
}
