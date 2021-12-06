using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Application.Interface
{
    public interface ILikeEvaluates
    {
        Task<bool> LikeProcess(int levelEvaluates, int idEvaluates,int account);
        Task<bool> DisLikeProcess(int levelEvaluates, int idEvaluates,int account);
    }
}
