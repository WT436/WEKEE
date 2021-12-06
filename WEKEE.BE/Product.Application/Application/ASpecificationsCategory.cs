using Product.Application.Interface;
using Product.Domain.BoundedContext;
using Product.Domain.Dto;
using Product.Domain.Entitys;
using Product.Infrastructure.MappingExtention;
using Product.Infrastructure.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Exceptions;

namespace Product.Application.Application
{
    public class ASpecificationsCategory : ISpecificationsCategory
    {
        private readonly CategoryProductQueries categoryProductQueries = new CategoryProductQueries();
        private readonly SpecificationsCategoryQueries specificationsCategory = new SpecificationsCategoryQueries();
        public async Task<int> Create(SpecificationsCategoryDtos specificationsCategoryDtos)
        {
            // kiểm tra từ khóa
            if (String.IsNullOrWhiteSpace(specificationsCategoryDtos.Key))
            {
                throw new ClientException(400, "Từ khóa không để trống");
            }
            // check ký tự đặc biệt
            CheckData.CheckSpecial(specificationsCategoryDtos.Key);
            CheckData.CheckSpecial(specificationsCategoryDtos.NameShow);
            CheckData.CheckSpecial(specificationsCategoryDtos.ClassifyValues);
            // checked thuộc tính

            //if (specificationsCategoryDtos.Classify == String.IsNullOrEmpty(specificationsCategoryDtos.ClassifyValues))
            //    throw new ClientException(400, "Dạng thông số cần có giá trị! . Dạng chi tiết không có giá trị!");

            // check category
            if (await categoryProductQueries.CheckIdCategory(id: specificationsCategoryDtos.Id))
                throw new ClientException(400, "Category không tồn tại!");

            var dataCreate = MappingData.InitializeAutomapper().Map<SpecificationsCategory>(specificationsCategoryDtos);
            return await specificationsCategory.Create(dataCreate);
        }

        public async Task<List<string>> GetAllKey()
        {
            return await specificationsCategory.GetAllKeyDistinct();
        }

        public List<SpecificationsCategoryDtos> GetData(SpecificationsCategoryDtos specificationsCategoryDtos)
        {
            var data = specificationsCategory.GetListAllData();

            if (!String.IsNullOrEmpty(specificationsCategoryDtos.Key))
            {
                data = data.Where(m => m.Key.ToUpper() == specificationsCategoryDtos.Key.ToUpper());
            }

            if (!String.IsNullOrEmpty(specificationsCategoryDtos.NameShow))
            {
                data = data.Where(m => m.NameShow.ToUpper() == specificationsCategoryDtos.NameShow.ToUpper());
            }

            if (!String.IsNullOrEmpty(specificationsCategoryDtos.ClassifyValues))
            {
                data = data.Where(m => m.ClassifyValues.ToUpper() == specificationsCategoryDtos.ClassifyValues.ToUpper());
            }

            if (specificationsCategoryDtos.CategoryMain != 0)
            {
                data = data.Where(m => m.CategoryMain == specificationsCategoryDtos.CategoryMain);
            }

            var retrunData = data.ToList();
            return retrunData.Select(m => MappingData.InitializeAutomapper().Map<SpecificationsCategoryDtos>(m)).ToList();
        }

        public async Task<List<string>> GetClassifyValues(string key)
        {
            return await specificationsCategory.GetAllClassifyValuesDistinct(key: key);
        }

        public List<SpecificationsCategoryDtos> GetData(string key, string values)
        {
            var data = specificationsCategory.GetListAllData();

            if (!String.IsNullOrEmpty(key))
            {
                data = data.Where(m => m.Key.ToUpper() == key.ToUpper());
            }

            if (!String.IsNullOrEmpty(values))
            {
                data = data.Where(m => m.ClassifyValues.ToUpper() == values.ToUpper());
            }

            var retrunData = data.ToList();
            return retrunData.Select(m => MappingData.InitializeAutomapper().Map<SpecificationsCategoryDtos>(m)).ToList();
        }

        public List<SpecificationsCategoryDtos> GetDataAll(int category)
        {
            var data = specificationsCategory.GetListAllData();
            data = data.Where(m => m.CategoryMain == category && m.IsEnabled == true);
            var retrunData = data.ToList();
            return retrunData.Select(m => MappingData.InitializeAutomapper().Map<SpecificationsCategoryDtos>(m)).ToList();
        }

        public List<SpecificationsCategoryDtos> GetUnitProduct()
        {
            var data = specificationsCategory.GetListAllData();
            data = data.Where(m => m.CategoryMain == null && m.IsEnabled == true && m.Classify == 3);
            var retrunData = data.ToList();
            return retrunData.Select(m => MappingData.InitializeAutomapper().Map<SpecificationsCategoryDtos>(m)).ToList();
        }
    }
}
