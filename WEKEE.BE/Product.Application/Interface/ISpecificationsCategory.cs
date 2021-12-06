using Product.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Interface
{
    public interface ISpecificationsCategory
    {
        Task<int> Create(SpecificationsCategoryDtos specificationsCategoryDtos);
        List<SpecificationsCategoryDtos> GetData(SpecificationsCategoryDtos specificationsCategoryDtos);
        Task<List<string>> GetAllKey();
        Task<List<string>> GetClassifyValues(string key);
        List<SpecificationsCategoryDtos> GetData(string key, string values);
        List<SpecificationsCategoryDtos> GetDataAll(int category);
        List<SpecificationsCategoryDtos> GetUnitProduct();
    }
}
