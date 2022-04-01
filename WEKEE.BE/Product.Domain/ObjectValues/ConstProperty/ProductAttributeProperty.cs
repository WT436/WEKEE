using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Domain.ObjectValues.ConstProperty
{
    public static class ProductAttributeProperty
    {
        public const string ID_PROATTR = "ID_PROATTR";
        public const string NAME_PROATTR = "NAME_PROATTR";
        public const string TYPES_PROATTR = "TYPES_PROATTR";
        public const string ISDELETE_PROATTR = "ISDELETE_PROATTR";
        public const string CREATEBY_PROATTR = "CREATEBY_PROATTR";
        public const string CREATE_DATE_UTC_PROATTR = "CREATE_DATE_UTC_PROATTR";
        public const string UPDATE_DATE_UTC_PROATTR = "UPDATE_DATE_UTC_PROATTR";

        public static string CONVERT_PROPERTY(string key, string value)
        {
            return key switch
            {
                ID_PROATTR => $" [Id]  = {value} ",
                NAME_PROATTR => $" [name] LIKE '%{value}%' ",
                TYPES_PROATTR => $" [Types]  = {value} ",
                ISDELETE_PROATTR => $" [isDelete]  = {value} ",
                CREATEBY_PROATTR => $" [CreateBy]  = {value} ",
                CREATE_DATE_UTC_PROATTR => $"CreatedOnUtc = '{value}' ",
                UPDATE_DATE_UTC_PROATTR => $"UpdatedOnUtc = '{value}' ",
                _ => $"Id = {value}",
            };
        }

        public static string CONVERT_PROPERTY(string key)
        {
            return key switch
            {
                ID_PROATTR => "Id",
                NAME_PROATTR => "[name]",
                TYPES_PROATTR => "[Types]",
                ISDELETE_PROATTR => "[isDelete]",
                CREATEBY_PROATTR => "CreateBy",
                CREATE_DATE_UTC_PROATTR => "CreatedOnUtc",
                UPDATE_DATE_UTC_PROATTR => "UpdatedOnUtc",
                _ => "Id",
            };
        }
    }
}
