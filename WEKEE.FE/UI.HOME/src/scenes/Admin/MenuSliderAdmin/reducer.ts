import ActionTypes from './constants';
import { MenuSliderAdminActions, MenuSliderAdminState } from './types';

declare var abp: any;

export const initialState: MenuSliderAdminState = { // ddaay
    loading: false,
    completed: true,
    pageIndex: 0,
    pageSize: 0,
    totalCount: 0,
    totalPages: 0,
};

function menuSliderAdminReducer(
    state: MenuSliderAdminState = initialState, //day
    action: MenuSliderAdminActions // day
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

export default menuSliderAdminReducer;