import ActionTypes from './constants';
import { ACategoryHomePageActions, ACategoryHomePageState } from './types';

declare var abp: any;

export const initialState: ACategoryHomePageState = {
    loading: false,
    completed: true,
    pageIndex: 0,
    pageSize: 0,
    totalCount: 0,
    totalPages: 0,
    categoryDtos: []
};

function aCategoryHomePageReducer(
    state: ACategoryHomePageState = initialState, //day
    action: ACategoryHomePageActions // day
) {
    switch (action.type) {
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
        
        default:
            return state;
    }
}

export default aCategoryHomePageReducer;