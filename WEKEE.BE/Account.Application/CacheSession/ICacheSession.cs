using System.Collections.Generic;
using Account.Domain.Dto;
using Account.Domain.ObjectValues;

namespace Account.Application.CacheSession
{
    /// <summary>
    /// [vi] Sử lý session lưu dưới cache 
    /// </summary>
    public interface ICacheSession
    {
        /// <summary>
        /// [vi] Lấy tất cả danh sách session đang tồn tại trong hệ thống.
        /// </summary>
        List<SessionCustom> GetAllSession();
        /// <summary>
        /// [vi] Lấy 1 session.
        /// </summary>
        SessionCustom GetUniqueSession(string account_user);
        /// <summary>
        /// [vi] Cài đặt tất cả session.
        /// </summary>
        void SetAllSession(List<SessionCustom> sessions);
        /// <summary>
        /// [vi] Cài đặt session.
        /// </summary>
        void SetUniqueSession(SessionCustom session);
        /// <summary>
        /// [vi] Xóa tất cả session.
        /// </summary>
        void RemoveAllSession();
        /// <summary>
        /// [vi] Xóa session.
        /// </summary>
        void RemoveUniqueSesion(string id_session);
        /// <summary>
        /// [vi] Cập nhật tất cả session.
        /// </summary>
        List<string> ResertAllSession();
        /// <summary>
        /// [vi] Cập nhật tất cả session.
        /// </summary>
        string ResertUniqueSession(string id_session);
    }
}
