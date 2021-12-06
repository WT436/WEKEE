using Assessment.Domain.Entitys;
using Assessment.Infrastructure.DBContext;
using System.Threading.Tasks;
using UnitOfWork;

namespace Assessment.Infrastructure.Queries
{
    public class LikeEvaluatesProductQuery
    {
        private readonly IUnitOfWork<EvaluatesContext> unitOfWork =
                       new UnitOfWork<EvaluatesContext>(new EvaluatesContext());

        #region select
        public async Task<int> CountIsLikeEvaluates(int id)
        {
            return await unitOfWork.GetRepository<LikeEvaluatesProduct>()
                                   .CountAsync(m => m.IdEvaluates == id
                                                 && m.Islike == true
                                                 && m.Isdislike == false);
        }

        public async Task<int> CountIsDisLikeEvaluates(int id)
        {
            return await unitOfWork.GetRepository<LikeEvaluatesProduct>()
                                   .CountAsync(m => m.IdEvaluates == id
                                                 && m.Islike == false
                                                 && m.Isdislike == true);
        }
        public async Task<int> CountIsLikeAccountEvaluates(int account)
        {
            return await unitOfWork.GetRepository<LikeEvaluatesProduct>()
                                   .CountAsync(m => m.Account == account
                                                 && m.Islike == true
                                                 && m.Isdislike == false
                                                 && m.LevelEvaluates==0);
        }

        public async Task<int> CountIsDisLikeAccountEvaluates(int account)
        {
            return await unitOfWork.GetRepository<LikeEvaluatesProduct>()
                                   .CountAsync(m => m.Account == account
                                                 && m.Islike == false
                                                 && m.Isdislike == true
                                                 && m.LevelEvaluates == 0);
        }
        public async Task<LikeEvaluatesProduct> GetUnitLikeEvaluatesProduct(int levelEvaluates, int idEvaluates, int account)
        {
            return await unitOfWork.GetRepository<LikeEvaluatesProduct>()
                              .GetFirstOrDefaultAsync(predicate: m => m.IdEvaluates == idEvaluates
                                                                   && m.Account == account
                                                                   && m.LevelEvaluates == levelEvaluates);
        }

        /// <summary>
        ///  islike = true -> check islike
        /// </summary>
        public async Task<bool> CheckYouLikeEvaluatesProduct(int levelEvaluates, int idEvaluates, int account , bool islike)
        {
            if (account == 0) return false;
            return await unitOfWork.GetRepository<LikeEvaluatesProduct>()
                              .ExistsAsync(m => m.IdEvaluates == idEvaluates
                                             && m.Account == account
                                             && m.LevelEvaluates == levelEvaluates
                                             && m.Islike == islike
                                             && m.Isdislike == !islike);
        }
        #endregion

        #region insert or update
        public async Task Insert(LikeEvaluatesProduct likeEvaluatesProduct)
        {
            unitOfWork.GetRepository<LikeEvaluatesProduct>().Insert(likeEvaluatesProduct);
            unitOfWork.SaveChanges();
        }

        public async Task Update(LikeEvaluatesProduct likeEvaluatesProduct)
        {
            unitOfWork.GetRepository<LikeEvaluatesProduct>().Update(likeEvaluatesProduct);
            unitOfWork.SaveChanges();
        }

        #endregion insert or update
    }
}
