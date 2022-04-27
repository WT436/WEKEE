enum ConstResource {
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

export default ConstResource;

export function confirmTypesResource(type: number) {
    if (ConstResource[type] === ConstResource[ConstResource.ID])
        return "NUMBER";
    else if (ConstResource[type] === ConstResource[ConstResource.DESCRIPTION] 
        || ConstResource[type] === ConstResource[ConstResource.NAME])
        return "STRING";
    else if (ConstResource[type] === ConstResource[ConstResource.IS_ACTIVE])
        return "BOOLEAN";
    else if (ConstResource[type] === ConstResource[ConstResource.TYPES_RSC] 
        || ConstResource[type] === ConstResource[ConstResource.CREATE_BY])
        return "SELECT";
    else if (ConstResource[type] === ConstResource[ConstResource.CREATE_DATE_UTC ]
        || ConstResource[type] === ConstResource[ConstResource.UPDATE_DATE_UTC])
        return "DATE";
    else
        return ConstResource.NULL;
}