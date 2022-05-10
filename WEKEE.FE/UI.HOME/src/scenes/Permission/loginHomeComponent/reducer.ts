import ActionTypes from './constants';
import { LoginHomeComponentActions, LoginHomeComponentState } from './types';

declare var abp: any;

export const initialState: LoginHomeComponentState = {
    loading: false,
    completed: true,
    pageIndex: 0,
    pageSize: 0,
    totalCount: 0,
    totalPages: 0,
};

function loginHomeComponentReducer(
    state: LoginHomeComponentState = initialState,
    action: LoginHomeComponentActions
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

export default loginHomeComponentReducer;