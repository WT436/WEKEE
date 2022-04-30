enum ConstRole {
    NULL = 0,
    ID = 1,
    CREATE_BY = 2,
    CREATE_DATE_UTC = 3,
    UPDATE_DATE_UTC = 4,

    NAME = 5,
    DESCRIPTION = 6,
    LEVEL_ROLE = 7,
    ROLE_MANAGE_ID = 8,
    ROLE_MANAGE_NAME = 9,
    IS_DELETE = 10,
    IS_ACTIVE = 11
}

export default ConstRole;

export function confirmTypesRole(type: number) {
    if (ConstRole[type] === ConstRole[ConstRole.ID]
        || ConstRole[type] === ConstRole[ConstRole.LEVEL_ROLE])
        return "NUMBER";
    else if (ConstRole[type] === ConstRole[ConstRole.DESCRIPTION]
        || ConstRole[type] === ConstRole[ConstRole.NAME])
        return "STRING";
    else if (ConstRole[type] === ConstRole[ConstRole.IS_ACTIVE]
        || ConstRole[type] === ConstRole[ConstRole.IS_DELETE])
        return "BOOLEAN";
    else if (ConstRole[type] === ConstRole[ConstRole.ROLE_MANAGE_ID]
        || ConstRole[type] === ConstRole[ConstRole.CREATE_BY])
        return "SELECT";
    else if (ConstRole[type] === ConstRole[ConstRole.CREATE_DATE_UTC]
        || ConstRole[type] === ConstRole[ConstRole.UPDATE_DATE_UTC])
        return "DATE";
    else
        return ConstRole.NULL;
}