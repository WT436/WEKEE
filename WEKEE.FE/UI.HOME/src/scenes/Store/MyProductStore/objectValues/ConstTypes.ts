enum ConstTypes{
    NULL = "",
    ID = "ID",
    NAME_PROATTR = "NAME_PROATTR",
    TYPES_PROATTR = "TYPES_PROATTR",
    CATE_PRO_PROATTR = "CATE_PRO_PROATTR",
    ISDELETE_PROATTR = "ISDELETE_PROATTR",
    CREATEBY_PROATTR = "CREATEBY_PROATTR",
    CREATE_DATE_UTC = "CREATE_DATE_UTC",
    UPDATE_DATE_UTC = "UPDATE_DATE_UTC"
}

export default ConstTypes;

export function confirmTypes(type: ConstTypes) {
    if (type === ConstTypes.ID)
        return "NUMBER";
    else if (type === ConstTypes.NAME_PROATTR)
        return "STRING";
    else if (type === ConstTypes.ISDELETE_PROATTR)
        return "BOOLEAN";
    else if (type === ConstTypes.TYPES_PROATTR
        || type === ConstTypes.CREATEBY_PROATTR
        || type=== ConstTypes.CATE_PRO_PROATTR)
        return "SELECT";
    else if (type === ConstTypes.CREATE_DATE_UTC
        || type === ConstTypes.UPDATE_DATE_UTC)
        return "DATE";
    else
        return ConstTypes.NULL;
}