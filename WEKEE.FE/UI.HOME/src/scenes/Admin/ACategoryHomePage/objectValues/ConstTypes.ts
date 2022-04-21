enum ConstTypes {
    NULL = "",
    ID = "ID",
    CREATE_BY = "CREATE_BY",
    CREATE_DATE_UTC = "CREATE_DATE_UTC",
    UPDATE_DATE_UTC = "UPDATE_DATE_UTC",
    CATEGORY_ID = "CATEGORY_ID",
    NAME_CATEGORY = "NAME_CATEGORY",
    URL_CATEGORY = "URL_CATEGORY",
    ICON_CATEGORY = "ICON_CATEGORY",
    MAIN_CATEGORY = "MAIN_CATEGORY",
    NUMBER_ORDER = "NUMBER_ORDER",
    IS_ENABLED = "IS_ENABLES",
    IS_COMPONENT = "IS_COMPONENT"
}

export default ConstTypes;

export function confirmTypes(type: ConstTypes) {
    if (type === ConstTypes.ID
        || type === ConstTypes.CATEGORY_ID)
        return "NUMBER";
    else if (type === ConstTypes.NAME_CATEGORY
        || type === ConstTypes.URL_CATEGORY)
        return "STRING";
    else if (type === ConstTypes.IS_ENABLED)
        return "BOOLEAN";
    else if (type === ConstTypes.CREATE_BY
        || type === ConstTypes.MAIN_CATEGORY
        || type === ConstTypes.NUMBER_ORDER
        || type === ConstTypes.IS_COMPONENT)
        return "SELECT";
    else if (type === ConstTypes.CREATE_DATE_UTC
        || type === ConstTypes.UPDATE_DATE_UTC)
        return "DATE";
    else
        return ConstTypes.NULL;
}