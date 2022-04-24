import { APermissionActions, APermissionState } from './types';

declare var abp: any;

export const initialState: APermissionState = { // ddaay
    //#region  PROPERTY DEFAULT
    loadingAll: false,
    completedAll: true,
    pageIndex: 0,
    pageSize: 0,
    totalCount: 0,
    totalPages: 0,
    //#endregion
    //#region  Individual
    resourceReads: []
    //#endregion
};

function aPermissionReducer(
    state: APermissionState = initialState, //day
    action: APermissionActions // day
) {
    switch (action.type) {

        default:
            return state;
    }
}

export default aPermissionReducer;