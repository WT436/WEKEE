import ActionTypes from './constants';
import { InfoCardHomeActions, InfoCardHomeState } from './types';

declare var abp: any;

export const initialState: InfoCardHomeState = {
    loading: false,
    completed: true,
    pageIndex: 0,
    pageSize: 0,
    totalCount: 0,
    totalPages: 0,
};

function infoCardHomeReducer(
    state: InfoCardHomeState = initialState,
    action: InfoCardHomeActions
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

export default infoCardHomeReducer;