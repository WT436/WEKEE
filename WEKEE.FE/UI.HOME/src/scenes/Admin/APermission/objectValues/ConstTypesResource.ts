enum ConstTypesResource{
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

export default ConstTypesResource;

export function confirmTypes(type: ConstTypesResource) {
    if (type === ConstTypesResource.ID)
        return "NUMBER";
    else if (type === ConstTypesResource.NAME_PROATTR)
        return "STRING";
    else if (type === ConstTypesResource.ISDELETE_PROATTR)
        return "BOOLEAN";
    else if (type === ConstTypesResource.TYPES_PROATTR
        || type === ConstTypesResource.CREATEBY_PROATTR
        || type=== ConstTypesResource.CATE_PRO_PROATTR)
        return "SELECT";
    else if (type === ConstTypesResource.CREATE_DATE_UTC
        || type === ConstTypesResource.UPDATE_DATE_UTC)
        return "DATE";
    else
        return ConstTypesResource.NULL;
}