using Product.Domain.ObjectValues.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Product.Domain.ObjectValues.ConstProperty;

namespace Product.Domain.CoreDomain
{
    public static class CategoryHomePageCore
    {
        public static SearchOrderPageInput ProcessInputRemoveIsComponent(SearchOrderPageInput input)
        {
            input.PropertySearch =  input.PropertySearch.Where(val => val != CategoryHomePageProperty.IS_COMPONENT).ToArray();
            input.ValuesSearch =  input.ValuesSearch.Where(val => val != CategoryHomePageComponentProperty.HOME_NULL).ToArray();

            //int dataIndex = input.PropertySearch.Select((s, i) => new { i, s })
            //                              .Where(t => t.s == CategoryHomePageProperty.IS_COMPONENT)
            //                              .Select(t => t.i).FirstOrDefault();
            //input.ValuesSearch[dataIndex] = ConvertPropertyCategoryHomePage
            //                                .CONVERT_TYPE_ISCOMPONENT_TEXT_ENUM(input.ValuesSearch[dataIndex])
            //                                .ToString();
            return input;
        }
    }
}
