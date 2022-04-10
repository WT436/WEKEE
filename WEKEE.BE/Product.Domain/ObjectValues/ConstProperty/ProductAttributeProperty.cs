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
        public const string CATE_PRO_PROATTR = "CATE_PRO_PROATTR";
        public const string ISDELETE_PROATTR = "ISDELETE_PROATTR";
        public const string CREATEBY_PROATTR = "CREATEBY_PROATTR";
        public const string CREATE_DATE_UTC_PROATTR = "CREATE_DATE_UTC_PROATTR";
        public const string UPDATE_DATE_UTC_PROATTR = "UPDATE_DATE_UTC_PROATTR";

        public static string CONVERT_PROPERTY(string key, string value)
        {
            switch (key)
            {
                case ID_PROATTR:
                    return $" [Id]  = {value} ";
                case NAME_PROATTR:
                    return $" [name] LIKE '%{value}%' ";
                case TYPES_PROATTR:
                    return $" [Types]  = {value} ";
                case CATE_PRO_PROATTR:
                    return $" [CategoryProductId]  = {value} ";
                case ISDELETE_PROATTR:
                    return $" [isDelete]  = {value} ";
                case CREATEBY_PROATTR:
                    return $" [CreateBy]  = {value} ";
                case CREATE_DATE_UTC_PROATTR:
                    var DateEnd = value[(value.IndexOf("|") + 1)..];
                    var DateStart = value[..value.IndexOf("|")];

                    // check thứ tự
                    if (Convert.ToDateTime(DateStart) > Convert.ToDateTime(DateEnd))
                    {
                        var dat = DateStart;
                        DateStart = DateEnd;
                        DateEnd = dat;
                    }
                    // Quá khứ đến Date End
                    if (String.IsNullOrEmpty(DateStart) && !String.IsNullOrEmpty(DateEnd))
                        return $"CP.CreatedOnUtc <=  CONVERT(datetime, '{DateEnd}')";
                    // Từ start đến tương lai 
                    else if (!String.IsNullOrEmpty(DateStart) && String.IsNullOrEmpty(DateEnd))
                        return $"CP.CreatedOnUtc >=  CONVERT(datetime, '{DateStart}')";
                    // Chính xác
                    else if (!String.IsNullOrEmpty(DateStart) && !String.IsNullOrEmpty(DateEnd)
                        && Convert.ToDateTime(DateStart) == Convert.ToDateTime(DateEnd))
                        return $"(CAST(CP.CreatedOnUtc AS Date) =  '{DateStart}')";
                    // từ start đến end
                    else if (!String.IsNullOrEmpty(DateStart) && !String.IsNullOrEmpty(DateEnd))
                        return $"(CP.CreatedOnUtc BETWEEN CONVERT(datetime, '{DateStart}') AND CONVERT(datetime, '{DateEnd}'))";
                    // ko tìm kiếm
                    else
                        return $"CP.CreatedOnUtc IS NOT NULL";
                case UPDATE_DATE_UTC_PROATTR:
                    var DateEndUpdate = value[(value.IndexOf("|") + 1)..];
                    var DateStartUpdate = value[..value.IndexOf("|")];

                    // check thứ tự
                    if (Convert.ToDateTime(DateStartUpdate) > Convert.ToDateTime(DateEndUpdate))
                    {
                        var dat = DateStartUpdate;
                        DateStart = DateEndUpdate;
                        DateEnd = dat;
                    }
                    // Quá khứ đến Date End
                    if (String.IsNullOrEmpty(DateStartUpdate) && !String.IsNullOrEmpty(DateEndUpdate))
                        return $"CP.UpdatedOnUtc <=  CONVERT(datetime, '{DateEndUpdate}')";
                    // Từ start đến tương lai 
                    else if (!String.IsNullOrEmpty(DateStartUpdate) && String.IsNullOrEmpty(DateEndUpdate))
                        return $"CP.UpdatedOnUtc >=  CONVERT(datetime, '{DateStartUpdate}')";
                    // Chính xác
                    else if (!String.IsNullOrEmpty(DateStartUpdate) && !String.IsNullOrEmpty(DateEndUpdate)
                        && Convert.ToDateTime(DateStartUpdate) == Convert.ToDateTime(DateEndUpdate))
                        return $"(CAST(CP.UpdatedOnUtc AS Date) =  '{DateStartUpdate}')";
                    // từ start đến end
                    else if (!String.IsNullOrEmpty(DateStartUpdate) && !String.IsNullOrEmpty(DateEndUpdate))
                        return $"(CP.UpdatedOnUtc BETWEEN CONVERT(datetime, '{DateStartUpdate}') AND CONVERT(datetime, '{DateEndUpdate}'))";
                    // ko tìm kiếm
                    else
                        return $"CP.UpdatedOnUtc IS NOT NULL";
                default:
                    return $"Id = {value}";
            };
        }

        public static string CONVERT_PROPERTY(string key)
        {
            return key switch
            {
                ID_PROATTR => "Id",
                NAME_PROATTR => "[name]",
                CATE_PRO_PROATTR => "[CategoryProductId]",
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
