using System.Threading.Tasks;
using Album.Application.Domain.Shared.DataTransfer;

namespace Album.Application.Controll.Interface
{
    /// <summary>
    /// Lưu ảnh product
    /// <para>1 Ảnh gốc</para>
    /// <para>8 Ảnh phụ</para>
    /// </summary>
    public interface IProductImage
    {
        /// <summary>
        /// Ảnh chi tiết 
        /// <para>340x340 - 1360x1360 - 80x80</para>
        /// </summary>
        Task<ProductDtos> SaveUrl(string url);
        /// <summary>
        /// Ảnh chi tiết 
        /// <para>340x340 - 1360x1360 - 80x80</para>
        /// </summary>
        Task<ProductDtos> SaveUrl80And340(string url);
        /// <summary>
        /// Ảnh hiển thị chính
        /// <para>220x220</para>
        /// </summary>
        Task<ProductDtos> SaveUrlCover(string url);
    }
}
