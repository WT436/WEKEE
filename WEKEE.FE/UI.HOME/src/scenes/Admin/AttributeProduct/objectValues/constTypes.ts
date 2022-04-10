enum ConstTypes {
    NULL = "",
    ID_PROATTR = "ID_PROATTR",
    NAME_PROATTR = "NAME_PROATTR",
    TYPES_PROATTR = "TYPES_PROATTR",
    CATE_PRO_PROATTR = "CATE_PRO_PROATTR",
    ISDELETE_PROATTR = "ISDELETE_PROATTR",
    CREATEBY_PROATTR = "CREATEBY_PROATTR",
    CREATE_DATE_UTC_PROATTR = "CREATE_DATE_UTC_PROATTR",
    UPDATE_DATE_UTC_PROATTR = "UPDATE_DATE_UTC_PROATTR"
}

export default ConstTypes;

export function confirmTypes_PROATTR(type: ConstTypes) {
    if (type === ConstTypes.ID_PROATTR)
        return "NUMBER";
    else if (type === ConstTypes.NAME_PROATTR)
        return "STRING";
    else if (type === ConstTypes.ISDELETE_PROATTR)
        return "BOOLEAN";
    else if (type === ConstTypes.TYPES_PROATTR
        || type === ConstTypes.CREATEBY_PROATTR
        || type=== ConstTypes.CATE_PRO_PROATTR)
        return "SELECT";
    else if (type === ConstTypes.CREATE_DATE_UTC_PROATTR
        || type === ConstTypes.UPDATE_DATE_UTC_PROATTR)
        return "DATE";
    else
        return ConstTypes.NULL;
}