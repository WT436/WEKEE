import notification from 'antd/lib/notification';
import { getDataAttibuteProductStart } from './actions';
import ActionTypes from './constants';
import ConstTypes from './objectValues/constTypes';
import { AttributeProductActions, AttributeProductState } from './types';

declare var abp: any;

export const initialState: AttributeProductState = {
    loading: false,
    completed: true,
    pageIndex: 0,
    pageSize: 20,
    totalCount: 0,
    totalPages: 0,
    productAttributeReadDto: [],
    cateProReadIdAndNameDto: [],
    optionCreateByCate: []
};

function attributeProductReducer(
    state: AttributeProductState = initialState, //day
    action: AttributeProductActions // day
) {
    switch (action.type) {
        //#region LOAD_CREATE_BY_CATE_START
        case ActionTypes.LOAD_CREATE_BY_CATE_START:
            return {
                ...state,
                loading: true,
            };

        case ActionTypes.LOAD_CREATE_BY_CATE_COMPLETED:
            return {
                ...state,
                loading: false,
                optionCreateByCate: action.payload
            };

        case ActionTypes.LOAD_CREATE_BY_CATE_ERROR:
            return {
                ...state,
                loading: false,
            };
        //#endregion
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
        //#region LOAD_CATE_PRO_START
        case ActionTypes.LOAD_CATE_PRO_START:
            return {
                ...state,
                loading: true,

            };

        case ActionTypes.LOAD_CATE_PRO_COMPLETED:
            return {
                ...state,
                loading: false,
                cateProReadIdAndNameDto: action.payload
            };

        case ActionTypes.LOAD_CATE_PRO_ERROR:
            return {
                ...state,
                loading: false,
            };
        //#endregion

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
            getDataAttibuteProductStart({
                pageIndex: state.pageIndex,
                pageSize: state.pageSize,
                propertyOrder: ConstTypes.NULL,
                valueOrderBy: ConstTypes.NULL,
                propertySearch: [],
                valuesSearch: [],
            })
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