using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Domain.ObjectValues.ConstProperty
{
    public static class ProductTagProperty
    {
        public const string ID_PROTAG = "ID_PROTAG";
        public const string NAME_PROTAG = "NAME_PROTAG";
        public const string CREATE_DATE_UTC_PROTAG = "CREATE_DATE_UTC_PROTAG";
        public const string UPDATE_DATE_UTC_PROTAG = "UPDATE_DATE_UTC_PROTAG";

        public static string CONVERT_PROPERTY(string key, string value)
        {
            return key switch
            {
                ID_PROTAG => $" [Id]  = {value} ",
                NAME_PROTAG => $" [Name] LIKE '%{value}%' ",
                CREATE_DATE_UTC_PROTAG => $"CreatedOnUtc = '{value}' ",
                UPDATE_DATE_UTC_PROTAG => $"UpdatedOnUtc = '{value}' ",
                _ => $"Id = {value}",
            };
        }

        public static string CONVERT_PROPERTY(string key)
        {
            return key switch
            {
                ID_PROTAG => "Id",
                NAME_PROTAG => "[name]",
                CREATE_DATE_UTC_PROTAG => "CreatedOnUtc",
                UPDATE_DATE_UTC_PROTAG => "UpdatedOnUtc",
                _ => "Id",
            };
        }
    }
}
