using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.ObjectValues.ConstProperty
{
    public enum ResourceProperty
    {
        NULL = 0,
        ID = 1,
        CREATE_BY = 2,
        CREATE_DATE_UTC = 3,
        UPDATE_DATE_UTC = 4,

        NAME = 5,
        TYPES_RSC = 6,
        DESCRIPTION = 7,
        IS_ACTIVE = 8
    }

    public enum ResourceType
    {
        NULL = 0,
        URL = 1
    }

    public static class ResourceTransform
    {
        public static string CONVERT_SQL(ResourceProperty key)
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
        public static string CONVERT_SQL(ResourceProperty key, string value)
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
