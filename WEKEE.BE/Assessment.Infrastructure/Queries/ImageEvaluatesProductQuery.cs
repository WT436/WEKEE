using Assessment.Domain.Entitys;
using Assessment.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;

namespace Assessment.Infrastructure.Queries
{
    public class ImageEvaluatesProductQuery
    {
        private readonly IUnitOfWork<EvaluatesContext> unitOfWork =
                        new UnitOfWork<EvaluatesContext>(new EvaluatesContext());

        #region insert
        public ImageEvaluatesProduct InsertImageUnit(ImageEvaluatesProduct imageEvaluatesProduct)
        {
            unitOfWork.GetRepository<ImageEvaluatesProduct>().Insert(imageEvaluatesProduct);
            unitOfWork.SaveChanges();
            return imageEvaluatesProduct;
        }
        public void InsertImageMultiple(List<ImageEvaluatesProduct> imageEvaluatesProduct)
        {
            unitOfWork.GetRepository<ImageEvaluatesProduct>().Insert(imageEvaluatesProduct);
            unitOfWork.SaveChanges();
        }
        #endregion

        #region Select
        public List<ImageEvaluatesProduct> GetAllImageEvaluatesProduct(int id)
        {
            var dataEvaluates = unitOfWork.GetRepository<EvaluatesProduct>()
                                          .GetAll()
                                          .Where(m => m.Product == id
                                                   && m.IdEvaluatesProduct == null
                                                   && m.LevelEvaluates == 0);
            var dataEvaluatesImage = unitOfWork.GetRepository<ImageEvaluatesProduct>()
                                               .GetAll()
                                               .Where(n => n.IsEnabled == true
                                                        && n.Folder == "product"
                                                        && n.TypesImage == false);
            return dataEvaluates.Join(dataEvaluatesImage, m => m.Id, n => n.IdEvaluatesProduct, (m, n) => n).ToList();
        }

        public async Task<IList<ImageEvaluatesProduct>> GetAllImageUserReview(int evaluates)
        {
            return await unitOfWork.GetRepository<ImageEvaluatesProduct>()
                                   .GetAllAsync(predicate: n => n.IsEnabled == true
                                                             && n.Folder == "product"
                                                             && n.TypesImage == false
                                                             && n.IdEvaluatesProduct == evaluates);
        }
        #endregion
    }
}
