enum ConstAtomic {
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

export default ConstAtomic;

export function confirmTypesAtomic(type: number) {
    if (ConstAtomic[type] === ConstAtomic[ConstAtomic.ID])
        return "NUMBER";
    else if (ConstAtomic[type] === ConstAtomic[ConstAtomic.DESCRIPTION]
        || ConstAtomic[type] === ConstAtomic[ConstAtomic.NAME])
        return "STRING";
    else if (ConstAtomic[type] === ConstAtomic[ConstAtomic.IS_ACTIVE])
        return "BOOLEAN";
    else if (ConstAtomic[type] === ConstAtomic[ConstAtomic.TYPES_RSC]
        || ConstAtomic[type] === ConstAtomic[ConstAtomic.CREATE_BY])
        return "SELECT";
    else if (ConstAtomic[type] === ConstAtomic[ConstAtomic.CREATE_DATE_UTC]
        || ConstAtomic[type] === ConstAtomic[ConstAtomic.UPDATE_DATE_UTC])
        return "DATE";
    else
        return ConstAtomic.NULL;
}