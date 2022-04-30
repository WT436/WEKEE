enum ConstSubject {
    NULL = 0,
    ID = 1,
    CREATE_BY = 2,
    CREATE_DATE_UTC = 3,
    UPDATE_DATE_UTC = 4,

    USER_ID = 5,
    GROUP_ID = 6,
    IS_ACTIVE= 7,
}

export default ConstSubject;

export function confirmTypesSubject(type: number) {
    if (ConstSubject[type] === ConstSubject[ConstSubject.ID])
        return "NUMBER";
    else if (ConstSubject[type] === ConstSubject[ConstSubject.IS_ACTIVE])
        return "BOOLEAN";
    else if (ConstSubject[type] === ConstSubject[ConstSubject.USER_ID]
        || ConstSubject[type] === ConstSubject[ConstSubject.GROUP_ID]
        || ConstSubject[type] === ConstSubject[ConstSubject.CREATE_BY])
        return "SELECT";
    else if (ConstSubject[type] === ConstSubject[ConstSubject.CREATE_DATE_UTC]
        || ConstSubject[type] === ConstSubject[ConstSubject.UPDATE_DATE_UTC])
        return "DATE";
    else
        return ConstSubject.NULL;
}