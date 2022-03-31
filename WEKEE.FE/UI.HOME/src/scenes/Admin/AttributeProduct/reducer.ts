import ActionTypes from './constants';
import { AttributeProductActions, AttributeProductState } from './types';

declare var abp: any;

export const initialState: AttributeProductState = { // ddaay
    loading: false,
    completed: true,
    pageIndex: 0,
    pageSize: 0,
    totalCount: 0,
    totalPages: 0,
};

function attributeProductReducer(
    state: AttributeProductState = initialState, //day
    action: AttributeProductActions // day
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
                loading: false,
                completed: false
            };

        case ActionTypes.WATCH_PAGE_ERROR:
            return {
                ...state,
                loading: false
            };

        default:
            return state;
    }
}

export default attributeProductReducer;