using Assessment.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Application.Interface
{
    public interface  IEvaluates
    {
        public Task<string> CreateEvaluates(EvaluatesProductDto evaluatesProductDto);
        public Task<GetEvaluatesProductDto> OverviewEvaluatesProduct(int id);
        public Task<List<ReviewEvaluatesOutputDto>> GetReviewEvaluatesProduct(ReviewEvaluatesInputDto reviewEvaluatesInputDto, int account);
        public Task<string> CreateRepEvaluates(EvaluatesProductDto evaluatesProductDto);
        public Task<List<RepCommentEvaluatesOutputDto>> GetDataReply(int id, int account, int level, int page);
    }
}
