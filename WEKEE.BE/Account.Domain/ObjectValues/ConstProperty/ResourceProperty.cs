using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.ObjectValues.ConstProperty
{
    public class ResourceProperty
    {
        public const string ID = "ID";
        public const string CREATE_BY = "CREATE_BY";
        public const string CREATE_DATE_UTC = "CREATE_DATE_UTC";
        public const string UPDATE_DATE_UTC = "UPDATE_DATE_UTC";

        public const string NAME = "NAME";
        public const string TYPES_RSC = "TYPES_RSC";
        public const string DESCRIPTION = "DESCRIPTION";
        public const string IS_ACTIVE = "IS_ACTIVE";
    }

    public enum ResourceType
    {
        NULL = 0,
        URL = 1
    }

    public static class ResourceTypesProperty
    {
        public const string NULL = "NULL";
        public const string URL = "URL";
    }

    public static class ResourceTransform
    {
        public static string CONVERT_ENUM_TEXT(ResourceType input)
        {
            return input switch
            {
                ResourceType.NULL => ResourceTypesProperty.NULL,
                ResourceType.URL =>  ResourceTypesProperty.URL  ,
                _ => ResourceTypesProperty.NULL
            };
        }
        public static int CONVERT_TEXT_ENUM(string input)
        {
            return input switch
            {
                ResourceTypesProperty.NULL => (int)ResourceType.NULL,
                ResourceTypesProperty.URL => (int)ResourceType.URL,
                _ => (int)ResourceType.NULL
            };
        }
        public static string CONVERT_SQL(string key)
        {
            return key switch
            {
                ResourceProperty.ID => "id",
                ResourceProperty.CREATE_BY => "create_by",
                ResourceProperty.CREATE_DATE_UTC => "created_at",
                ResourceProperty.UPDATE_DATE_UTC => "updated_at",

                ResourceProperty.NAME => "name",
                ResourceProperty.TYPES_RSC => "types_rsc",
                ResourceProperty.DESCRIPTION => "description",
                ResourceProperty.IS_ACTIVE => "is_active",
                _ => "Id",
            };
        }
        public static string CONVERT_SQL(string key, string value)
        {
            return key switch
            {
                ResourceProperty.ID => $"CHP.[id] = {value}",
                ResourceProperty.CREATE_BY => $"CHP.[CreateBy]  = {value}",
                ResourceProperty.CREATE_DATE_UTC => $"CHP.[createdOnUtc] = '{value}'",
                ResourceProperty.UPDATE_DATE_UTC => $"CHP.[updatedOnUtc] = '{value}'",
                _ => "Id",
            };
        }
    }
}
