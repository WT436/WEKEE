using Product.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils.Exceptions;

namespace Product.Domain.Aggregate
{
    public class ProcessSpecifications
    {
        public void CheckUnit(int? unit, List<SpecificationsCategory> specificationsCategorys, bool trademark = false)
        {
            if (!specificationsCategorys.Any(m => m.Id == unit))
            {
                if (trademark)
                {
                    throw new ClientException(400, "Trademark does not exist!");
                }
                else
                {
                    throw new ClientException(400, "Unit does not exist!");
                }
            }
        }

        public int CheckKeyAndPropertiesSpecifications(string key,
                                                       string properties,
                                                       List<SpecificationsCategory> specificationsCategorys,
                                                       int? category)
        {
            return specificationsCategorys.Where(m => m.Key == key
                                                   && m.ClassifyValues == properties
                                                   && m.IsEnabled == true
                                                   && m.CategoryMain == category)
                                          .FirstOrDefault().Id;
        }

        public int CheckKeyAndNameShowSpecifications(string key,
                                                      string nameShow,
                                                      List<SpecificationsCategory> specificationsCategorys,
                                                      int? category)
        {
            return specificationsCategorys.Where(m => m.Key == key
                                                   && m.NameShow == nameShow
                                                   && m.Classify == 2
                                                   && m.ClassifyValues == null
                                                   && m.IsEnabled == true
                                                   && m.CategoryMain == category)
                                          .FirstOrDefault().Id;
        }

    }
}
