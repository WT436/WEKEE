import ActionTypes from './constants';
import { BaseActions, BaseState } from './types';

declare var abp: any;

export const initialState: BaseState = { // ddaay
    loading: false,
    completed: true,
    pageIndex: 0,
    pageSize: 0,
    totalCount: 0,
    totalPages: 0,
};

function baseReducer(
    state: BaseState = initialState, //day
    action: BaseActions // day
) 
{
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

        default:
            return state;
    }
}

export default baseReducer;