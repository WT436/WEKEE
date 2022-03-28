import { notification } from 'antd';
import ActionTypes from './constants';
import { ACategoryActions, ACategoryState } from './types';

declare var abp: any;

export const initialState: ACategoryState = {
    loading: false,
    completed: true,
    pageIndex: 0,
    pageSize: 0,
    totalCount: 0,
    totalPages: 0,

    categoryDtos: [],

    optionsCategory: []
};

function aCategoryReducer(
    state: ACategoryState = initialState,
    action: ACategoryActions
) {
    switch (action.type) {
        // OPEN PAGE
        case ActionTypes.WATCH_PAGE_START:
            return {
                ...state,
                loading: true
            };

        case ActionTypes.WATCH_PAGE_COMPLETED:
            return {
                ...state,
                loading: true,
                completed: true
            };

        case ActionTypes.WATCH_PAGE_ERROR:
            return {
                ...state,
                loading: true
            };
        //#region Create category
        case ActionTypes.CREATE_CATEGORY_ADMIN_START:
            return {
                ...state,
                loading: true
            };
        case ActionTypes.CREATE_CATEGORY_ADMIN_COMPLETED:
            return {
                ...state,
                loading: false
            };
        case ActionTypes.CREATE_CATEGORY_ADMIN_ERROR:
            return {
                ...state,
                loading: false
            };
        //#endregion
        
        //#region get category
        case ActionTypes.GET_CATEGORY_ADMIN_START:
            return {
                ...state,
            };
        case ActionTypes.GET_CATEGORY_ADMIN_COMPLETED:
            return {
                ...state,
                categoryDtos: action.payload.items,
                pageIndex: action.payload.pageIndex,
                pageSize: action.payload.pageSize,
                totalCount: action.payload.totalCount,
                totalPages: action.payload.totalPages,
            };
        case ActionTypes.GET_CATEGORY_ADMIN_ERROR:
            return {
                ...state,
            };
        //#endregion
        
        //#region Category product map
        case ActionTypes.CATEGORY_MAP_START:
            return {
                ...state,
                loading: true
            };
        case ActionTypes.CATEGORY_MAP_COMPLETED:
            console.log(action.payload);
            return {
                ...state,
                optionsCategory: action.payload,
                loading: false
            };
        case ActionTypes.CATEGORY_MAP_ERROR:
            return {
                ...state,
                loading: false
            };
        //#endregion

        default:
            return state;
    }
}

export default aCategoryReducer;