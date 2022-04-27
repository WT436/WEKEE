import { notification } from 'antd';
import ActionTypes from './constants';
import { L } from '../../../lib/abpUtility';
import { APermissionActions, APermissionState } from './types';

declare var abp: any;

export const initialState: APermissionState = {
    //#region  PROPERTY Resource
    loadingAllResource: false,
    loadingTableResource: false,
    completedAllResource: false,
    loadingButtonResource: false,
    pageIndexResource: 0,
    pageSizeResource: 0,
    totalCountResource: 0,
    totalPagesResource: 0,
    resourceReads: [],
    //#endregion

    //#region  ATOMIC
    loadingAllAtomic: false,
    loadingTableAtomic: false,
    completedAllAtomic: false,
    loadingButtonAtomic: false,
    pageIndexAtomic: 0,
    pageSizeAtomic: 0,
    totalCountAtomic: 0,
    totalPagesAtomic: 0,
    atomicReads: []
    //#endregion
};

function aPermissionReducer(
    state: APermissionState = initialState, //day
    action: APermissionActions // day
) {
    switch (action.type) {
        //#region GET_RESOURCE_START
        case ActionTypes.GET_RESOURCE_START:
            return {
                ...state,
                loadingTableResource: true
            };

        case ActionTypes.GET_RESOURCE_COMPLETED:
            return {
                ...state,
                loadingTableResource: false,
                resourceReads: action.payload.items,
                pageIndexResource: action.payload.pageIndex,
                pageSizeResource: action.payload.pageSize,
                totalCountResource: action.payload.totalCount,
                totalPagesResource: action.payload.totalPages,
            };

        case ActionTypes.GET_RESOURCE_ERROR:
            notification.error({
                message: L("FAILURE", 'COMMON'),
                description: "Server đang cố gắng truy vấn!",
                placement: "bottomRight",
            });
            return {
                ...state,
                loadingTable: true
            };
        //#endregion
        //#region DELETE_RESOURCE_START
        case ActionTypes.DELETE_RESOURCE_START:
            return {
                ...state,
                loadingTableResource: true,
                completedAllResource: true,
            };

        case ActionTypes.DELETE_RESOURCE_COMPLETED:
            notification.success({
                message: "SUCCESS",
                description: L("NUMBER_DELETE_SUCCESS", 'COMMON') + action.payload,
                placement: "bottomRight",
            });

            return {
                ...state,
                loadingTableResource: false,
                completedAllResource: false,
            };

        case ActionTypes.DELETE_RESOURCE_ERROR:
            return {
                ...state,
                loadingTableResource: false,
            };
        //#endregion
        //#region EDIT_STATUS_RESOURCE_START
        case ActionTypes.EDIT_STATUS_RESOURCE_START:
            return {
                ...state,
                loadingTableResource: true,
                completedAllResource: true,
            };

        case ActionTypes.EDIT_STATUS_RESOURCE_COMPLETED:
            notification.success({
                message: "SUCCESS",
                description: L("NUMBER_EDIT_SUCCESS", 'COMMON') + action.payload + L("PLEASE_RESTART_DATA", 'COMMON'),
                placement: "bottomRight",
            });

            return {
                ...state,
                loadingTableResource: false,
                completedAllResource: false,
            };

        case ActionTypes.EDIT_STATUS_RESOURCE_ERROR:
            return {
                ...state,
                loadingTableResource: false,
            };
        //#endregion
        //#region INSERT_OR_UPDATE_RESOURCE_START
        case ActionTypes.INSERT_OR_UPDATE_RESOURCE_START:
            return {
                ...state,
                loadingButtonResource: true,
            };

        case ActionTypes.INSERT_OR_UPDATE_RESOURCE_COMPLETED:
            notification.success({
                message: "SUCCESS",
                description: L("SUCCESS", 'COMMON') + action.payload,
                placement: "bottomRight",
            });
            return {
                ...state,
                loadingButtonResource: false,
            };

        case ActionTypes.INSERT_OR_UPDATE_RESOURCE_ERROR:
            return {
                ...state,
                loadingButtonResource: false,
            };
        //#endregion

        //#region GET_ATOMIC_START
        case ActionTypes.GET_ATOMIC_START:
            return {
                ...state,
                loadingTableAtomic: true
            };

        case ActionTypes.GET_ATOMIC_COMPLETED:
            return {
                ...state,
                loadingTableAtomic: false,
                atomicReads: action.payload.items,
                pageIndexAtomic: action.payload.pageIndex,
                pageSizeAtomic: action.payload.pageSize,
                totalCountAtomic: action.payload.totalCount,
                totalPagesAtomic: action.payload.totalPages,
            };

        case ActionTypes.GET_ATOMIC_ERROR:
            notification.error({
                message: L("FAILURE", 'COMMON'),
                description: "Server đang cố gắng truy vấn!",
                placement: "bottomRight",
            });
            return {
                ...state,
                loadingTable: true
            };
        //#endregion
        //#region DELETE_ATOMIC_START
        case ActionTypes.DELETE_ATOMIC_START:
            return {
                ...state,
                loadingTableAtomic: true,
                completedAllAtomic: true,
            };

        case ActionTypes.DELETE_ATOMIC_COMPLETED:
            notification.success({
                message: "SUCCESS",
                description: L("NUMBER_DELETE_SUCCESS", 'COMMON') + action.payload,
                placement: "bottomRight",
            });

            return {
                ...state,
                loadingTableAtomic: false,
                completedAllAtomic: false,
            };

        case ActionTypes.DELETE_ATOMIC_ERROR:
            return {
                ...state,
                loadingTableAtomic: false,
            };
        //#endregion
        //#region EDIT_STATUS_ATOMIC_START
        case ActionTypes.EDIT_STATUS_ATOMIC_START:
            return {
                ...state,
                loadingTableAtomic: true,
                completedAllAtomic: true,
            };

        case ActionTypes.EDIT_STATUS_ATOMIC_COMPLETED:
            notification.success({
                message: "SUCCESS",
                description: L("NUMBER_EDIT_SUCCESS", 'COMMON') + action.payload + L("PLEASE_RESTART_DATA", 'COMMON'),
                placement: "bottomRight",
            });

            return {
                ...state,
                loadingTableAtomic: false,
                completedAllAtomic: false,
            };

        case ActionTypes.EDIT_STATUS_ATOMIC_ERROR:
            return {
                ...state,
                loadingTableAtomic: false,
            };
        //#endregion
        //#region INSERT_OR_UPDATE_ATOMIC_START
        case ActionTypes.INSERT_OR_UPDATE_ATOMIC_START:
            return {
                ...state,
                loadingButtonAtomic: true,
            };

        case ActionTypes.INSERT_OR_UPDATE_ATOMIC_COMPLETED:
            notification.success({
                message: "SUCCESS",
                description: L("SUCCESS", 'COMMON') + action.payload,
                placement: "bottomRight",
            });
            return {
                ...state,
                loadingButtonAtomic: false,
            };

        case ActionTypes.INSERT_OR_UPDATE_ATOMIC_ERROR:
            return {
                ...state,
                loadingButtonAtomic: false,
            };
        //#endregion

        default:
            return state;
    }
}

export default aPermissionReducer;