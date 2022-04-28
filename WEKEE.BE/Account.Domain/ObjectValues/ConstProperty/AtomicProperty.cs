using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.ObjectValues.ConstProperty
{
    public enum AtomicProperty
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

    public enum AtomicTypes
    {
        HTTPREQUEST = 0,

    }

    public class AtomicTransform
    {
        public static string CONVERT_SQL(int key)
        {
            return (AtomicProperty)key switch
            {
                AtomicProperty.ID => "R.[id]",
                AtomicProperty.CREATE_BY => "R.[CreateBy]",
                AtomicProperty.CREATE_DATE_UTC => "R.[CreatedOnUtc]",
                AtomicProperty.UPDATE_DATE_UTC => "R.[UpdatedOnUtc]",

                AtomicProperty.NAME => "name",
                AtomicProperty.TYPES_RSC => "typesRsc",
                AtomicProperty.DESCRIPTION => "description",
                AtomicProperty.IS_ACTIVE => "isActive",
                _ => "Id",
            };
        }
        public static string CONVERT_SQL(int key, string value)
        {
            switch ((AtomicProperty)key)
            {
                case AtomicProperty.ID:
                    return $"R.[id] = {value}";
                case AtomicProperty.CREATE_BY:
                    return $"R.[CreateBy]  = {value}";
                case AtomicProperty.CREATE_DATE_UTC:
                    var DateEnd = value[(value.IndexOf("|") + 1)..];
                    var DateStart = value[..value.IndexOf("|")];

                    // check thứ tự
                    if (Convert.ToDateTime(DateStart) > Convert.ToDateTime(DateEnd))
                    {
                        (DateEnd, DateStart) = (DateStart, DateEnd);
                    }
                    // Quá khứ đến Date End
                    if (String.IsNullOrEmpty(DateStart) && !String.IsNullOrEmpty(DateEnd))
                        return $"R.[CreatedOnUtc] <=  CONVERT(datetime, '{DateEnd}')";
                    // Từ start đến tương lai 
                    else if (!String.IsNullOrEmpty(DateStart) && String.IsNullOrEmpty(DateEnd))
                        return $"R.[CreatedOnUtc] >=  CONVERT(datetime, '{DateStart}')";
                    // Chính xác
                    else if (!String.IsNullOrEmpty(DateStart) && !String.IsNullOrEmpty(DateEnd)
                        && Convert.ToDateTime(DateStart) == Convert.ToDateTime(DateEnd))
                        return $"(CAST(R.[CreatedOnUtc] AS Date) =  '{DateStart}')";
                    // từ start đến end
                    else if (!String.IsNullOrEmpty(DateStart) && !String.IsNullOrEmpty(DateEnd))
                        return $"(R.[CreatedOnUtc] BETWEEN CONVERT(datetime, '{DateStart}') AND CONVERT(datetime, '{DateEnd}'))";
                    // ko tìm kiếm
                    else
                        return $"R.[CreatedOnUtc] IS NOT NULL";
                case AtomicProperty.UPDATE_DATE_UTC:
                    var DateEndUpdate = value[(value.IndexOf("|") + 1)..];
                    var DateStartUpdate = value[..value.IndexOf("|")];

                    // check thứ tự
                    if (Convert.ToDateTime(DateStartUpdate) > Convert.ToDateTime(DateEndUpdate))
                    {
                        (DateEndUpdate, DateStartUpdate) = (DateStartUpdate, DateEndUpdate);
                    }
                    // Quá khứ đến Date End
                    if (String.IsNullOrEmpty(DateStartUpdate) && !String.IsNullOrEmpty(DateEndUpdate))
                        return $"R.[UpdatedOnUtc] <=  CONVERT(datetime, '{DateEndUpdate}')";
                    // Từ start đến tương lai 
                    else if (!String.IsNullOrEmpty(DateStartUpdate) && String.IsNullOrEmpty(DateEndUpdate))
                        return $"R.[UpdatedOnUtc] >=  CONVERT(datetime, '{DateStartUpdate}')";
                    // Chính xác
                    else if (!String.IsNullOrEmpty(DateStartUpdate) && !String.IsNullOrEmpty(DateEndUpdate)
                        && Convert.ToDateTime(DateStartUpdate) == Convert.ToDateTime(DateEndUpdate))
                        return $"(CAST(R.[UpdatedOnUtc] AS Date) =  '{DateStartUpdate}')";
                    // từ start đến end
                    else if (!String.IsNullOrEmpty(DateStartUpdate) && !String.IsNullOrEmpty(DateEndUpdate))
                        return $"(R.[UpdatedOnUtc] BETWEEN CONVERT(datetime, '{DateStartUpdate}') AND CONVERT(datetime, '{DateEndUpdate}'))";
                    // ko tìm kiếm
                    else
                        return $"R.[UpdatedOnUtc] IS NOT NULL";

                case AtomicProperty.NAME:
                    return $"R.[name]  LIKE N'%{value}%'";
                case AtomicProperty.TYPES_RSC:
                    return $"R.[typesRsc] = '{value}'";
                case AtomicProperty.DESCRIPTION:
                    return $"R.[description] LIKE N'%{value}%'";
                case AtomicProperty.IS_ACTIVE:
                    return $"R.[isActive] = {value}";

                default: return $"R.[Id] = {value}";
            };
        }
    }
}
