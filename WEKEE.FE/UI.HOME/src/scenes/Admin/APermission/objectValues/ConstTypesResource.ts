enum ConstTypesResource {
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

export default ConstTypesResource;

export function confirmTypesResource(type: number) {
    if (ConstTypesResource[type] === ConstTypesResource[ConstTypesResource.ID])
        return "NUMBER";
    else if (ConstTypesResource[type] === ConstTypesResource[ConstTypesResource.DESCRIPTION] 
        || ConstTypesResource[type] === ConstTypesResource[ConstTypesResource.NAME])
        return "STRING";
    else if (ConstTypesResource[type] === ConstTypesResource[ConstTypesResource.IS_ACTIVE])
        return "BOOLEAN";
    else if (ConstTypesResource[type] === ConstTypesResource[ConstTypesResource.TYPES_RSC] 
        || ConstTypesResource[type] === ConstTypesResource[ConstTypesResource.CREATE_BY])
        return "SELECT";
    else if (ConstTypesResource[type] === ConstTypesResource[ConstTypesResource.CREATE_DATE_UTC ]
        || ConstTypesResource[type] === ConstTypesResource[ConstTypesResource.UPDATE_DATE_UTC])
        return "DATE";
    else
        return ConstTypesResource.NULL;
}