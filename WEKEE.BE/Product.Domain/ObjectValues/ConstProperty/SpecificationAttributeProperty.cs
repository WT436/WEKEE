using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Domain.ObjectValues.ConstProperty
{
    public static class SpecificationAttributeProperty
    {
        public const string ID_SPEC = "ID_SPEC";
        public const string KEY_SPEC = "KEY_SPEC";
        public const string GROUP_SPEC = "GROUP_SPEC";
        public const string CATE_SPEC = "CATE_SPEC";
        public const string CREATE_SPEC = "CREATE_SPEC";
        public const string CREATE_DATE_UTC_SPEC = "CREATE_DATE_UTC_SPEC";
        public const string UPDATE_DATE_UTC_SPEC = "UPDATE_DATE_UTC_SPEC";

        public static string CONVERT_PROPERTY_SPEC(string key, string value)
        {
            return key switch
            {
                ID_SPEC => $" [Id]  = {value} ",
                KEY_SPEC => $" [key] LIKE '%{value}%' ",
                GROUP_SPEC => $" [GroupSpecification]  LIKE '%{value}%' ",
                CATE_SPEC => $" [CategoryProductId]  = {value} ",
                CREATE_SPEC => $" [CreateBy]  = {value} ",
                CREATE_DATE_UTC_SPEC => $"CreatedOnUtc = '{value}' ",
                UPDATE_DATE_UTC_SPEC => $"UpdatedOnUtc = '{value}' ",
                _ => $"Id = {value}",
            };
        }

        public static string CONVERT_PROPERTY_SPEC(string key)
        {
            return key switch
            {
                ID_SPEC => "Id",
                KEY_SPEC => "key",
                GROUP_SPEC => "GroupSpecification",
                CATE_SPEC => "CategoryProductId",
                CREATE_SPEC => "CreateBy",
                CREATE_DATE_UTC_SPEC => "CreatedOnUtc",
                UPDATE_DATE_UTC_SPEC => "UpdatedOnUtc",
                _ => "Id",
            };
        }
    }
}
