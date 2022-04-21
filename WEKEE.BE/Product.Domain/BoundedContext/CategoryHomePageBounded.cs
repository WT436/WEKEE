using Product.Domain.ObjectValues.ConstProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Product.Domain.BoundedContext
{
    public static class CategoryHomePageBounded
    {
        /// <summary>
        ///  if PropertySearch,ValuesSearch null  or count  PropertySearch != ValuesSearch or IS_COMPONENT == NUll or 0
        /// </summary>
        /// <returns>true : Search data category default;<br/> false : search data category Home Page</returns>
        public static bool IsDataDefault(string[] PropertySearch, string[] ValuesSearch)
        {
            bool isSearchSettingCategory = PropertySearch != null && PropertySearch.Any(m => m == CategoryHomePageProperty.IS_COMPONENT);
            bool isValueSearchIsComponent = ValuesSearch != null
                && ValuesSearch.Any(m
                   => (int)CategoryHomePageComponentTypes.HOME_NULL == ConvertPropertyCategoryHomePage
                                                                       .CONVERT_TYPE_ISCOMPONENT_TEXT_ENUM(m));
            bool isLength = PropertySearch.Length == ValuesSearch.Length;
            return (!isLength || (isSearchSettingCategory && isValueSearchIsComponent));
        }
    }
}
