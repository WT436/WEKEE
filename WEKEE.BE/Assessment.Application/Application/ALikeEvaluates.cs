using Assessment.Application.Interface;
using Assessment.Infrastructure.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Application.Application
{
    public class ALikeEvaluates : ILikeEvaluates
    {
        private readonly LikeEvaluatesProductQuery _likeEvaluatesProductQuery = new LikeEvaluatesProductQuery();
        public async Task<bool> DisLikeProcess(int levelEvaluates, int idEvaluates, int account)
        {
            var data = await _likeEvaluatesProductQuery.GetUnitLikeEvaluatesProduct(levelEvaluates: levelEvaluates,
                                                                                    idEvaluates: idEvaluates,
                                                                                    account: account);
            if (data == null)
            {
                await _likeEvaluatesProductQuery.Insert(new Domain.Entitys.LikeEvaluatesProduct
                {
                    Islike = false,
                    Isdislike = true,
                    LevelEvaluates = levelEvaluates,
                    IdEvaluates = idEvaluates,
                    Account = account,
                    DateCreate = DateTime.Now,
                    DateUpdate = DateTime.Now
                });
                return true;
            }
            else
            {
                data.Isdislike = !data.Isdislike;
                data.Islike = false;
                data.DateUpdate = DateTime.Now;
                await _likeEvaluatesProductQuery.Update(data);
                return false;
            }
        }

        public async Task<bool> LikeProcess(int levelEvaluates, int idEvaluates, int account)
        {
            var data = await _likeEvaluatesProductQuery.GetUnitLikeEvaluatesProduct(levelEvaluates: levelEvaluates,
                                                                                     idEvaluates: idEvaluates,
                                                                                     account: account);
            if (data == null)
            {
                await _likeEvaluatesProductQuery.Insert(new Domain.Entitys.LikeEvaluatesProduct
                {
                    Islike = true,
                    Isdislike = false,
                    LevelEvaluates = levelEvaluates,
                    IdEvaluates = idEvaluates,
                    Account = account,
                    DateCreate = DateTime.Now,
                    DateUpdate = DateTime.Now
                });
                return true;
            }
            else
            {
                data.Islike = !data.Islike;
                data.Isdislike = false;
                data.IdEvaluates = idEvaluates;
                data.DateUpdate = DateTime.Now;
                await _likeEvaluatesProductQuery.Update(data);
                return false;
            }
        }
    }
}
