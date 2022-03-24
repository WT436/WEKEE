using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.SettingUrl.Base
{
    public static class ActionRouter
    {
        /// <summary>
        /// lấy thông tin 
        /// </summary>
        public const string GET = "/get"; 
        /// <summary>
        /// truy xuất dung lượng lớn bản ghi
        /// </summary>
        public const string LIST = "/list"; 
        /// <summary>
        /// xem trang
        /// </summary>
        public const string WATCH = "/watch"; 
        /// <summary>
        /// cập nhật thông tin cơ bản
        /// </summary>
        public const string UPDATE = "/update"; 
        /// <summary>
        /// 
        /// </summary>
        public const string PATCH = "/patch";
        /// <summary>
        /// tạo mới bản ghi
        /// </summary>
        public const string CREATE = "/create"; 
        /// <summary>
        /// xóa bản ghi
        /// </summary>
        public const string DELETE = "/delete"; 
        /// <summary>
        /// cập nhật nâng cao , như kích hoạt tài khaonr và khóa tài khoản
        /// </summary>
        public const string EDIT = "/edit"; 
    }
}
