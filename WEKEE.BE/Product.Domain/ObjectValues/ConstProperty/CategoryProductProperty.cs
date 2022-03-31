using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Domain.ObjectValues.ConstProperty
{
    public static class CategoryProductProperty
    {
        public const string ID_CATEGORY = "ID_CATEGORY";
        public const string NAME_CATEGORY = "NAME_CATEGORY";
        public const string URL_CATEGORY = "URL_CATEGORY";
        public const string ICON_CATEGORY = "ICON_CATEGORY";
        public const string LEVEL_CATEGORY = "LEVEL_CATEGORY";
        public const string MAIN_CATEGORY = "MAIN_CATEGORY";
        public const string NUMBER_CATEGORY = "NUMBER_CATEGORY";
        public const string ENABLED_CATEGORY = "ENABLED_CATEGORY";
        public const string CREATE_DATE_UTC_CATEGORY = "CREATE_DATE_UTC_CATEGORY";
        public const string UPDATE_DATE_UTC_CATEGORY = "UPDATE_DATE_UTC_CATEGORY";

        public static string CONVERT_PROPERTY_CATEGORY(string key, string value)
        {
            return key switch
            {
                ID_CATEGORY => $"Id  = {value} ",
                NAME_CATEGORY => $"NameCategory LIKE '%{value}%' ",
                URL_CATEGORY => $"UrlCategory LIKE '%{value}%' ",
                ICON_CATEGORY => $"IconCategory LIKE '%{value}%' ",
                LEVEL_CATEGORY => $"LevelCategory = {value} ",
                MAIN_CATEGORY => value == "null" ? $"CategoryMain IS NULL" : $"CategoryMain = {value} ",
                NUMBER_CATEGORY => $"NumberOrder = {value} ",
                ENABLED_CATEGORY => $"IsEnabled = {value} ",
                CREATE_DATE_UTC_CATEGORY => $"CreatedOnUtc = '{value}' ",
                UPDATE_DATE_UTC_CATEGORY => $"UpdatedOnUtc = '{value}' ",
                _ => $"Id = {value}",
            };
        }

        public static string CONVERT_PROPERTY_CATEGORY(string key)
        {
            return key switch
            {
                ID_CATEGORY => "Id",
                NAME_CATEGORY => "NameCategory",
                URL_CATEGORY => "UrlCategory",
                ICON_CATEGORY => "IconCategory",
                LEVEL_CATEGORY => "LevelCategory",
                MAIN_CATEGORY => "CategoryMain",
                NUMBER_CATEGORY => "NumberOrder",
                ENABLED_CATEGORY => "IsEnabled",
                CREATE_DATE_UTC_CATEGORY => "CreatedOnUtc",
                UPDATE_DATE_UTC_CATEGORY => "UpdatedOnUtc",
                _ => "Id",
            };
        }
    }
}
