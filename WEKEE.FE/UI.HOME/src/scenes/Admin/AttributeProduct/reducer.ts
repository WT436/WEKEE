import notification from 'antd/lib/notification';
import ActionTypes from './constants';
import { AttributeProductActions, AttributeProductState } from './types';

declare var abp: any;

export const initialState: AttributeProductState = {
    loading: false,
    completed: true,
    pageIndex: 0,
    pageSize: 0,
    totalCount: 0,
    totalPages: 0,
    productAttributeReadDto: []
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

        //#region GET_DATA_ATTRIBUTE_PRODUCT_START
        case ActionTypes.GET_DATA_ATTRIBUTE_PRODUCT_START:
            return {
                ...state,
                loading: true,
            };

        case ActionTypes.GET_DATA_ATTRIBUTE_PRODUCT_COMPLETED:
            return {
                ...state,
                loading: false,
                productAttributeReadDto: action.payload.items,
                pageIndex: action.payload.pageIndex,
                pageSize: action.payload.pageSize,
                totalCount: action.payload.totalCount,
                totalPages: action.payload.totalPages,
            };

        case ActionTypes.GET_DATA_ATTRIBUTE_PRODUCT_ERROR:
            return {
                ...state,
                loading: false,
            };
        //#endregion

        //#region CREATE_ATTRIBUTE_PRODUCT_START
        case ActionTypes.CREATE_ATTRIBUTE_PRODUCT_START:
            return {
                ...state,
                loading: true,
            };

        case ActionTypes.CREATE_ATTRIBUTE_PRODUCT_COMPLETED:
            if (action.payload == 1) {
                notification.warning({
                    message: "Thành công",
                    description: "Đã thêm " + action.payload.toString() + " dữ liệu!",
                    placement: "bottomRight",
                });
            }
            else {
                notification.warning({
                    message: "Thất Bại",
                    description: "Không thể thêm dữ liệu!",
                    placement: "bottomRight",
                });
            }
            return {
                ...state,
                loading: false,
            };

        case ActionTypes.CREATE_ATTRIBUTE_PRODUCT_ERROR:
            return {
                ...state,
                loading: false,
            };
        //#endregion
        default:
            return state;
    }
}

export default attributeProductReducer;