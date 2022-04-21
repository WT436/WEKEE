using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Domain.ObjectValues.ConstProperty
{
    /// <summary>
    /// Name Column Search for table CategoryHomePage And Category
    /// </summary>
    public static class CategoryHomePageProperty
    {
        public const string ID = "ID";
        public const string CREATE_BY = "CREATE_BY";
        public const string CREATE_DATE_UTC = "CREATE_DATE_UTC";
        public const string UPDATE_DATE_UTC = "UPDATE_DATE_UTC";

        public const string CATEGORY_ID = "CATEGORY_ID";
        public const string NAME_CATEGORY = "NAME_CATEGORY";
        public const string URL_CATEGORY = "URL_CATEGORY";
        public const string ICON_CATEGORY = "ICON_CATEGORY";
        public const string MAIN_CATEGORY_NAME = "MAIN_CATEGORY_NAME";
        public const string MAIN_CATEGORY = "MAIN_CATEGORY";
        public const string NUMBER_ORDER = "NUMBER_ORDER";
        public const string IS_ENABLED = "IS_ENABLES";
        public const string IS_COMPONENT = "IS_COMPONENT";
    }
    /// <summary>
    /// Type for Component ID
    /// </summary>
    public enum CategoryHomePageComponentTypes
    {
        HOME_NULL = 0,
        HOME_PAGE_MENU = 1,
        COMPONENT_HOME = 2
    }
    /// <summary>
    /// Value for IsComponent Search Table CategoryHomaPage
    /// </summary>
    public static class CategoryHomePageComponentProperty
    {
        public const string HOME_NULL = "HOME_NULL";
        public const string HOME_PAGE_MENU = "HOME_PAGE_MENU";
        public const string COMPONENT_HOME = "COMPONENT_HOME";
    }
    /// <summary>
    /// Convert CategoryHomePage and categoryProduct Join 
    /// </summary>
    public static class ConvertPropertyCategoryHomePage
    {
        /// <summary>
        ///  Con vert text => enum
        /// </summary>
        public static int CONVERT_TYPE_ISCOMPONENT_TEXT_ENUM(string input)
        {
            return input switch
            {
                CategoryHomePageComponentProperty.HOME_PAGE_MENU => (int)CategoryHomePageComponentTypes.HOME_PAGE_MENU,
                CategoryHomePageComponentProperty.COMPONENT_HOME => (int)CategoryHomePageComponentTypes.COMPONENT_HOME,
                _ => (int)CategoryHomePageComponentTypes.HOME_NULL
            };
        }
        /// <summary>
        /// Convert Enum to text
        /// </summary>
        public static string CONVERT_TYPE_ISCOMPONENT_ENUM_TEXT(CategoryHomePageComponentTypes input)
        {
            return input switch
            {
                CategoryHomePageComponentTypes.HOME_PAGE_MENU => CategoryHomePageComponentProperty.HOME_PAGE_MENU,
                CategoryHomePageComponentTypes.COMPONENT_HOME => CategoryHomePageComponentProperty.COMPONENT_HOME,
                _ => CategoryHomePageComponentProperty.HOME_NULL
            };
        }
        /// <summary>
        /// convert key to column sql
        /// </summary>
        public static string CONVERT_PROPERTY_KEY_TO_SQL(string key)
        {
            return key switch
            {
                CategoryHomePageProperty.ID => "Id",
                CategoryHomePageProperty.CREATE_BY => "CreateBy",
                CategoryHomePageProperty.CREATE_DATE_UTC => "CreatedOnUtc",
                CategoryHomePageProperty.UPDATE_DATE_UTC => "UpdatedOnUtc",

                CategoryHomePageProperty.IS_COMPONENT => "isComponent",
                CategoryHomePageProperty.NAME_CATEGORY => "NameCategory",
                CategoryHomePageProperty.URL_CATEGORY => "UrlCategory",
                CategoryHomePageProperty.ICON_CATEGORY => "IconCategory",
                CategoryHomePageProperty.MAIN_CATEGORY => "CategoryMain",

                CategoryHomePageProperty.NUMBER_ORDER => "NumberOrder",
                CategoryHomePageProperty.IS_ENABLED => "IsEnabled",
                _ => "Id",
            };
        }
        /// <summary>
        /// convert key to column sql
        /// </summary>
        public static string CONVERT_PROPERTY_KEY_TO_SQL(string key, string value)
        {
            return key switch
            {
                CategoryHomePageProperty.ID => $"CHP.[id] = {value}",
                CategoryHomePageProperty.CREATE_BY => $"CHP.[CreateBy]  = {value}",
                CategoryHomePageProperty.CREATE_DATE_UTC => $"CHP.[createdOnUtc] = '{value}'",
                CategoryHomePageProperty.UPDATE_DATE_UTC => $"CHP.[updatedOnUtc] = '{value}'",

                CategoryHomePageProperty.IS_COMPONENT => $"CHP.[isComponent] = {ConvertPropertyCategoryHomePage.CONVERT_TYPE_ISCOMPONENT_TEXT_ENUM(value)}",
                CategoryHomePageProperty.NAME_CATEGORY => $"CP.[nameCategory]  LIKE N'%{value}%'",
                CategoryHomePageProperty.URL_CATEGORY => $"CP.[urlCategory]  LIKE N'%{value}%'",
                CategoryHomePageProperty.ICON_CATEGORY => $"CP.[iconCategory] = {value}",
                CategoryHomePageProperty.MAIN_CATEGORY => $"CP.[categoryMain] = {value}",

                CategoryHomePageProperty.NUMBER_ORDER => $"CHP.[numberOrder] = {value}",
                CategoryHomePageProperty.IS_ENABLED => $"CHP.[isEnabled] = {value}",
                _ => "Id",
            };
        }
    }

}
