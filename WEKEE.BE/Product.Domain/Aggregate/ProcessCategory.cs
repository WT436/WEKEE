using Product.Domain.Dto;
using Product.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Product.Domain.Aggregate
{
    public class ProcessCategory
    {
        public List<CategorySelectDto> MapFullCategory(IList<CategoryProduct> dataLv1,
                                                       IList<CategoryProduct> dataLv2,
                                                       IList<CategoryProduct> dataLv3,
                                                       IList<CategoryProduct> dataLv4)
        {
            return dataLv1.Select(lv1 => new CategorySelectDto
            {
                Id = lv1.Id,
                NameCategory = lv1.NameCategory,
                Items = dataLv2.Where(lv2 => lv2.CategoryMain == lv1.Id)
                              .Select(lv2 => new CategorySelectDto
                              {
                                  Id = lv2.Id,
                                  NameCategory = lv2.NameCategory,
                                  Items = dataLv3.Where(lv3 => lv3.CategoryMain == lv2.Id)
                                                 .Select(lv3 => new CategorySelectDto
                                                 {
                                                     Id = lv2.Id,
                                                     NameCategory = lv2.NameCategory,
                                                     Items = dataLv4.Where(lv4 => lv4.CategoryMain == lv3.Id)
                                                                  .Select(lv4 => new CategorySelectDto
                                                                  {
                                                                      Id = lv2.Id,
                                                                      NameCategory = lv2.NameCategory,
                                                                      Items = null
                                                                  }).ToList()
                                                 }).ToList()
                              }).ToList()
            }).ToList();
        }
    }
}
