import ActionTypes from './constants';
import { SiderStoreActions, SiderStoreState } from './types';

declare var abp: any;

export const initialState: SiderStoreState = { // ddaay
    loading: false,
    completed: true,
    pageIndex: 0,
    pageSize: 0,
    totalCount: 0,
    totalPages: 0,
};

function siderStoreReducer(
    state: SiderStoreState = initialState, //day
    action: SiderStoreActions // day
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

export default siderStoreReducer;