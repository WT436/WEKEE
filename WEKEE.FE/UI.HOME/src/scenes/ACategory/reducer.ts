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

    categoryDtos: []
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

        case ActionTypes.GET_CATEGORY_ADMIN_START:
            return {
                ...state,
                loading: true
            };
        case ActionTypes.GET_CATEGORY_ADMIN_COMPLETED:
            return {
                ...state,
                categoryDtos: action.payload,
                loading: false
            };
        case ActionTypes.GET_CATEGORY_ADMIN_ERROR:
            return {
                ...state,
                loading: false
            };
        default:
            return state;
    }
}

export default aCategoryReducer;