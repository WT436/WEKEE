enum ConstPermission {
    NULL = 0,
    ID = 1,
    CREATE_BY = 2,
    CREATE_DATE_UTC = 3,
    UPDATE_DATE_UTC = 4,

    NAME = 5,
    DESCRIPTION = 6,
    ATOMIC_ID = 7,
    LEVEL_PERMITION = 8,
    PERMISSION_ID = 9,
    IS_ACTIVE = 10
}

export default ConstPermission;

export function confirmTypesPermission(type: number) {
    if (ConstPermission[type] === ConstPermission[ConstPermission.ID])
        return "NUMBER";
    else if (ConstPermission[type] === ConstPermission[ConstPermission.DESCRIPTION]
        || ConstPermission[type] === ConstPermission[ConstPermission.NAME])
        return "STRING";
    else if (ConstPermission[type] === ConstPermission[ConstPermission.IS_ACTIVE])
        return "BOOLEAN";
    else if (ConstPermission[type] === ConstPermission[ConstPermission.ATOMIC_ID]
        || ConstPermission[type] === ConstPermission[ConstPermission.LEVEL_PERMITION]
        || ConstPermission[type] === ConstPermission[ConstPermission.PERMISSION_ID]
        || ConstPermission[type] === ConstPermission[ConstPermission.CREATE_BY])
        return "SELECT";
    else if (ConstPermission[type] === ConstPermission[ConstPermission.CREATE_DATE_UTC]
        || ConstPermission[type] === ConstPermission[ConstPermission.UPDATE_DATE_UTC])
        return "DATE";
    else
        return ConstPermission.NULL;
}