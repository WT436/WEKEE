using Assessment.Domain.Entitys;
using Assessment.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;
using UnitOfWork.Collections;

namespace Assessment.Infrastructure.Queries
{
    public class EvaluatesProductQuery
    {
        private readonly IUnitOfWork<EvaluatesContext> unitOfWork =
                         new UnitOfWork<EvaluatesContext>(new EvaluatesContext());

        #region insert
        public EvaluatesProduct Create(EvaluatesProduct evaluatesProduct)
        {
            unitOfWork.GetRepository<EvaluatesProduct>().Insert(evaluatesProduct);
            unitOfWork.SaveChanges();
            return evaluatesProduct;
        }

        #endregion

        #region select
        public async Task<int> SumStart(int id, int star)
        {
            return await unitOfWork.GetRepository<EvaluatesProduct>()
                                    .CountAsync(predicate: m => m.Product == id
                                                             && m.StarNumber == star
                                                             && m.LevelEvaluates == 0);
        }

        public IQueryable<EvaluatesProduct> GetAllEvaluatesProduct(int id)
        {
            return unitOfWork.GetRepository<EvaluatesProduct>().GetAll().Where(m => m.Product == id);
        }

        public async Task<IPagedList<EvaluatesProduct>> GetPageListEvaluatesProduct(int product, int page, int[] star)
        {
            return await unitOfWork.GetRepository<EvaluatesProduct>()
                                   .GetPagedListAsync(predicate: m => m.Product == product
                                                              && m.LevelEvaluates == 0
                                                              && m.IdEvaluatesProduct == null
                                                              && m.StarNumber == star[0]
                                                              || m.StarNumber == star[1]
                                                              || m.StarNumber == star[2]
                                                              || m.StarNumber == star[3]
                                                              || m.StarNumber == star[4]
                                                              ,
                                                      //orderBy:m=>m.Or,
                                                      pageSize: 10,
                                                      pageIndex: page
                                                      );
        }

        public async Task<IPagedList<EvaluatesProduct>> GetPageListEvaluatesProduct(int product, int page)
        {
            return await unitOfWork.GetRepository<EvaluatesProduct>()
                                   .GetPagedListAsync(predicate: m => m.Product == product
                                                              && m.LevelEvaluates == 0
                                                              && m.IdEvaluatesProduct == null,
                                                      //orderBy:m=>m.Or,
                                                      pageSize: 10,
                                                      pageIndex: page
                                                      );
        }

        /// <summary>
        /// Lấy 
        /// </summary>
        public async Task<int> GetNumberReviewProduct(int userAccount)
        {
            return await unitOfWork.GetRepository<EvaluatesProduct>()
                                   .CountAsync(m => m.Account == userAccount
                                                 && m.LevelEvaluates == 0);
        }

        public async Task<int> GetNumberReplyReviewProduct(int userAccount)
        {
            return await unitOfWork.GetRepository<EvaluatesProduct>()
                                   .CountAsync(m => m.Account == userAccount
                                                 && m.LevelEvaluates != 0);
        }

        public async Task<int> GetNumberRepReviewProduct(int id, int product, int levelEvaluates)
        {
            return await unitOfWork.GetRepository<EvaluatesProduct>()
                                   .CountAsync(m => m.IdEvaluatesProduct == id
                                                 && m.LevelEvaluates > levelEvaluates
                                                 && m.Product == product);
        }

        public async Task<bool> CheckIdEvaluatesProduct(int id)
        {
            return await unitOfWork.GetRepository<EvaluatesProduct>()
                                   .ExistsAsync(m => m.Id == id);
        }

        public async Task<EvaluatesProduct> GetUnitEvaluatesProduct(int idEvaluatesProduct)
        {
            return await unitOfWork.GetRepository<EvaluatesProduct>()
                                   .GetFirstOrDefaultAsync(predicate: m => m.LevelEvaluates == 1
                                                                        && m.IdEvaluatesProduct == idEvaluatesProduct,
                                                             orderBy: o => o.OrderBy(v => v.CreatedAt)
                                                     );
        }

        public async Task<List<EvaluatesProduct>> GetPageListRepEvaluatesProduct(int level,int idEvaluatesProduct, int page)
        {
            var data =  await unitOfWork.GetRepository<EvaluatesProduct>()
                                        .GetPagedListAsync(predicate: m => m.LevelEvaluates == level
                                                                        && m.IdEvaluatesProduct == idEvaluatesProduct,
                                                             orderBy: o => o.OrderBy(v => v.CreatedAt),
                                                            pageSize: 10,
                                                           pageIndex: page
                                                          );
            return data.Items.ToList();
        }
        #endregion
    }
}
