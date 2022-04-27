import { notification } from 'antd';
import ActionTypes from './constants';
import { L } from '../../../lib/abpUtility';
import { APermissionActions, APermissionState } from './types';

declare var abp: any;

export const initialState: APermissionState = {
    //#region  PROPERTY DEFAULT
    loadingAll: false,
    loadingTable: false,
    completedAll: false,
    loadingButton: false,
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
        //#region GET_RESOURCE_START
        case ActionTypes.GET_RESOURCE_START:
            return {
                ...state,
                loadingTable: true
            };

        case ActionTypes.GET_RESOURCE_COMPLETED:
            return {
                ...state,
                loadingTable: false,
                resourceReads: action.payload.items,
                pageIndex: action.payload.pageIndex,
                pageSize: action.payload.pageSize,
                totalCount: action.payload.totalCount,
                totalPages: action.payload.totalPages,
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
                loadingTable: true,
                completedAll: true,
            };

        case ActionTypes.DELETE_RESOURCE_COMPLETED:
            notification.success({
                message: "SUCCESS",
                description: L("NUMBER_DELETE_SUCCESS", 'COMMON') + action.payload,
                placement: "bottomRight",
            });

            return {
                ...state,
                loadingTable: false,
                completedAll: false,
            };

        case ActionTypes.DELETE_RESOURCE_ERROR:
            return {
                ...state,
                loadingTable: false,
            };
        //#endregion
        //#region EDIT_STATUS_RESOURCE_START
        case ActionTypes.EDIT_STATUS_RESOURCE_START:
            return {
                ...state,
                loadingTable: true,
                completedAll: true,
            };

        case ActionTypes.EDIT_STATUS_RESOURCE_COMPLETED:
            notification.success({
                message: "SUCCESS",
                description: L("NUMBER_EDIT_SUCCESS", 'COMMON') + action.payload + L("PLEASE_RESTART_DATA", 'COMMON'),
                placement: "bottomRight",
            });

            return {
                ...state,
                loadingTable: false,
                completedAll: false,
            };

        case ActionTypes.EDIT_STATUS_RESOURCE_ERROR:
            return {
                ...state,
                loadingTable: false,
            };
        //#endregion
        //#region INSERT_OR_UPDATE_RESOURCE_START
        case ActionTypes.INSERT_OR_UPDATE_RESOURCE_START:
            return {
                ...state,
                loadingButton: true,
            };

        case ActionTypes.INSERT_OR_UPDATE_RESOURCE_COMPLETED:
            notification.success({
                message: "SUCCESS",
                description: L("SUCCESS", 'COMMON') + action.payload,
                placement: "bottomRight",
            });
            return {
                ...state,
                loadingButton: false,
            };

        case ActionTypes.INSERT_OR_UPDATE_RESOURCE_ERROR:
            return {
                ...state,
                loadingButton: false,
            };
        //#endregion
        default:
            return state;
    }
}

export default aPermissionReducer;