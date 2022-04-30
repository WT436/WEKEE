import { notification } from 'antd';
import ActionTypes from './constants';
import { L } from '../../../lib/abpUtility';
import { APermissionActions, APermissionState } from './types';

declare var abp: any;

export const initialState: APermissionState = {
    //#region  User profile 
    userProfile: [],
    //#endregion
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
    atomicReads: [],
    atomicSummaryRead: [],
    //#endregion
    //#region  PERMISSION
    loadingAllPermission: false,
    loadingTablePermission: false,
    completedAllPermission: false,
    loadingButtonPermission: false,
    pageIndexPermission: 0,
    pageSizePermission: 0,
    totalCountPermission: 0,
    totalPagesPermission: 0,
    permissionReads: [],
    permissionSummaryRead: [],
    //#endregion
    //#region  ROLE
    loadingAllRole: false,
    loadingTableRole: false,
    completedAllRole: false,
    loadingButtonRole: false,
    pageIndexRole: 0,
    pageSizeRole: 0,
    totalCountRole: 0,
    totalPagesRole: 0,
    roleReads: [],
    roleSummaryRead: [],
    //#endregion
    //#region  SUBJECT
    loadingAllSubject: false,
    loadingTableSubject: false,
    completedAllSubject: false,
    loadingButtonSubject: false,
    pageIndexSubject: 0,
    pageSizeSubject: 0,
    totalCountSubject: 0,
    totalPagesSubject: 0,
    subjectReads: [],
    //#endregion
};

function aPermissionReducer(
    state: APermissionState = initialState, //day
    action: APermissionActions // day
) {
    switch (action.type) {
        //#region GET_USER_PROFILE_START
        case ActionTypes.GET_USER_PROFILE_START:
            return {
                ...state,
            };

        case ActionTypes.GET_USER_PROFILE_COMPLETED:
            return {
                ...state,
                userProfile: action.payload
            };

        case ActionTypes.GET_USER_PROFILE_ERROR:
            return {
                ...state,
            };
        //#endregion

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
        //#region SUMMARY_ATOMIC_START
        case ActionTypes.SUMMARY_ATOMIC_START:
            return {
                ...state,
            };

        case ActionTypes.SUMMARY_ATOMIC_COMPLETED:
            return {
                ...state,
                atomicSummaryRead: action.payload
            };

        case ActionTypes.SUMMARY_ATOMIC_ERROR:
            return {
                ...state,
            };
        //#endregion

        //#region GET_PERMISSION_START
        case ActionTypes.GET_PERMISSION_START:
            return {
                ...state,
                loadingTablePermission: true
            };

        case ActionTypes.GET_PERMISSION_COMPLETED:
            return {
                ...state,
                loadingTablePermission: false,
                permissionReads: action.payload.items,
                pageIndexPermission: action.payload.pageIndex,
                pageSizePermission: action.payload.pageSize,
                totalCountPermission: action.payload.totalCount,
                totalPagesPermission: action.payload.totalPages,
            };

        case ActionTypes.GET_PERMISSION_ERROR:
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
        //#region DELETE_PERMISSION_START
        case ActionTypes.DELETE_PERMISSION_START:
            return {
                ...state,
                loadingTablePermission: true,
                completedAllPermission: true,
            };

        case ActionTypes.DELETE_PERMISSION_COMPLETED:
            notification.success({
                message: "SUCCESS",
                description: L("NUMBER_DELETE_SUCCESS", 'COMMON') + action.payload,
                placement: "bottomRight",
            });

            return {
                ...state,
                loadingTablePermission: false,
                completedAllPermission: false,
            };

        case ActionTypes.DELETE_PERMISSION_ERROR:
            return {
                ...state,
                loadingTablePermission: false,
            };
        //#endregion
        //#region EDIT_STATUS_PERMISSION_START
        case ActionTypes.EDIT_STATUS_PERMISSION_START:
            return {
                ...state,
                loadingTablePermission: true,
                completedAllPermission: true,
            };

        case ActionTypes.EDIT_STATUS_PERMISSION_COMPLETED:
            notification.success({
                message: "SUCCESS",
                description: L("NUMBER_EDIT_SUCCESS", 'COMMON') + action.payload + L("PLEASE_RESTART_DATA", 'COMMON'),
                placement: "bottomRight",
            });

            return {
                ...state,
                loadingTablePermission: false,
                completedAllPermission: false,
            };

        case ActionTypes.EDIT_STATUS_PERMISSION_ERROR:
            return {
                ...state,
                loadingTablePermission: false,
            };
        //#endregion
        //#region INSERT_OR_UPDATE_PERMISSION_START
        case ActionTypes.INSERT_OR_UPDATE_PERMISSION_START:
            return {
                ...state,
                loadingButtonPermission: true,
            };

        case ActionTypes.INSERT_OR_UPDATE_PERMISSION_COMPLETED:
            notification.success({
                message: "SUCCESS",
                description: L("SUCCESS", 'COMMON') + action.payload,
                placement: "bottomRight",
            });
            return {
                ...state,
                loadingButtonPermission: false,
            };

        case ActionTypes.INSERT_OR_UPDATE_PERMISSION_ERROR:
            return {
                ...state,
                loadingButtonPermission: false,
            };
        //#endregion
        //#region SEARCH_SUMMARY_PERMISSION_START
        case ActionTypes.SEARCH_SUMMARY_PERMISSION_START:
            return {
                ...state,
            };

        case ActionTypes.SEARCH_SUMMARY_PERMISSION_COMPLETED:
            return {
                ...state,
                permissionSummaryRead: action.payload
            };

        case ActionTypes.SEARCH_SUMMARY_PERMISSION_ERROR:
            return {
                ...state,
            };
        //#endregion

        //#region GET_ROLE_START
        case ActionTypes.GET_ROLE_START:
            return {
                ...state,
                loadingTableRole: true
            };

        case ActionTypes.GET_ROLE_COMPLETED:
            return {
                ...state,
                loadingTableRole: false,
                roleReads: action.payload.items,
                pageIndexRole: action.payload.pageIndex,
                pageSizeRole: action.payload.pageSize,
                totalCountRole: action.payload.totalCount,
                totalPagesRole: action.payload.totalPages,
            };

        case ActionTypes.GET_ROLE_ERROR:
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
        //#region DELETE_ROLE_START
        case ActionTypes.DELETE_ROLE_START:
            return {
                ...state,
                loadingTableRole: true,
                completedAllRole: true,
            };

        case ActionTypes.DELETE_ROLE_COMPLETED:
            notification.success({
                message: "SUCCESS",
                description: L("NUMBER_DELETE_SUCCESS", 'COMMON') + action.payload,
                placement: "bottomRight",
            });

            return {
                ...state,
                loadingTableRole: false,
                completedAllRole: false,
            };

        case ActionTypes.DELETE_ROLE_ERROR:
            return {
                ...state,
                loadingTableRole: false,
            };
        //#endregion
        //#region EDIT_STATUS_ROLE_START
        case ActionTypes.EDIT_STATUS_ROLE_START:
            return {
                ...state,
                loadingTableRole: true,
                completedAllRole: true,
            };

        case ActionTypes.EDIT_STATUS_ROLE_COMPLETED:
            notification.success({
                message: "SUCCESS",
                description: L("NUMBER_EDIT_SUCCESS", 'COMMON') + action.payload + L("PLEASE_RESTART_DATA", 'COMMON'),
                placement: "bottomRight",
            });

            return {
                ...state,
                loadingTableRole: false,
                completedAllRole: false,
            };

        case ActionTypes.EDIT_STATUS_ROLE_ERROR:
            return {
                ...state,
                loadingTableRole: false,
            };
        //#endregion
        //#region INSERT_OR_UPDATE_ROLE_START
        case ActionTypes.INSERT_OR_UPDATE_ROLE_START:
            return {
                ...state,
                loadingButtonRole: true,
            };

        case ActionTypes.INSERT_OR_UPDATE_ROLE_COMPLETED:
            notification.success({
                message: "SUCCESS",
                description: L("SUCCESS", 'COMMON') + action.payload,
                placement: "bottomRight",
            });
            return {
                ...state,
                loadingButtonRole: false,
            };

        case ActionTypes.INSERT_OR_UPDATE_ROLE_ERROR:
            return {
                ...state,
                loadingButtonRole: false,
            };
        //#endregion
        //#region SUMMARY_ROLE_START
        case ActionTypes.SEARCH_SUMMARY_ROLE_START:
            return {
                ...state,
            };

        case ActionTypes.SEARCH_SUMMARY_ROLE_COMPLETED:
            console.log(action.payload)
            return {
                ...state,
                roleSummaryRead: action.payload
            };

        case ActionTypes.SEARCH_SUMMARY_ROLE_ERROR:
            return {
                ...state,
            };
        //#endregion

        //#region GET_SUBJECT_START
        case ActionTypes.GET_SUBJECT_START:
            return {
                ...state,
                loadingTableSubject: true
            };

        case ActionTypes.GET_SUBJECT_COMPLETED:
            return {
                ...state,
                loadingTableSubject: false,
                subjectReads: action.payload.items,
                pageIndexSubject: action.payload.pageIndex,
                pageSizeSubject: action.payload.pageSize,
                totalCountSubject: action.payload.totalCount,
                totalPagesSubject: action.payload.totalPages,
            };

        case ActionTypes.GET_SUBJECT_ERROR:
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
        //#region DELETE_SUBJECT_START
        case ActionTypes.DELETE_SUBJECT_START:
            return {
                ...state,
                loadingTableSubject: true,
                completedAllSubject: true,
            };

        case ActionTypes.DELETE_SUBJECT_COMPLETED:
            notification.success({
                message: "SUCCESS",
                description: L("NUMBER_DELETE_SUCCESS", 'COMMON') + action.payload,
                placement: "bottomRight",
            });

            return {
                ...state,
                loadingTableSubject: false,
                completedAllSubject: false,
            };

        case ActionTypes.DELETE_SUBJECT_ERROR:
            return {
                ...state,
                loadingTableSubject: false,
            };
        //#endregion
        //#region EDIT_STATUS_SUBJECT_START
        case ActionTypes.EDIT_STATUS_SUBJECT_START:
            return {
                ...state,
                loadingTableSubject: true,
                completedAllSubject: true,
            };

        case ActionTypes.EDIT_STATUS_SUBJECT_COMPLETED:
            notification.success({
                message: "SUCCESS",
                description: L("NUMBER_EDIT_SUCCESS", 'COMMON') + action.payload + L("PLEASE_RESTART_DATA", 'COMMON'),
                placement: "bottomRight",
            });

            return {
                ...state,
                loadingTableSubject: false,
                completedAllSubject: false,
            };

        case ActionTypes.EDIT_STATUS_SUBJECT_ERROR:
            return {
                ...state,
                loadingTableSubject: false,
            };
        //#endregion
        //#region INSERT_OR_UPDATE_SUBJECT_START
        case ActionTypes.INSERT_OR_UPDATE_SUBJECT_START:
            return {
                ...state,
                loadingButtonSubject: true,
            };

        case ActionTypes.INSERT_OR_UPDATE_SUBJECT_COMPLETED:
            notification.success({
                message: "SUCCESS",
                description: L("SUCCESS", 'COMMON') + action.payload,
                placement: "bottomRight",
            });
            return {
                ...state,
                loadingButtonSubject: false,
            };

        case ActionTypes.INSERT_OR_UPDATE_SUBJECT_ERROR:
            return {
                ...state,
                loadingButtonSubject: false,
            };
        //#endregion

        default:
            return state;
    }
}

export default aPermissionReducer;