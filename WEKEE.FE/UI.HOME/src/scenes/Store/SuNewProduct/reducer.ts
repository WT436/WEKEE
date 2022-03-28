import ActionTypes from "./constants";
import { SuNewProductActions, SuNewProductState } from "./types";

declare var abp: any;

export const initialState: SuNewProductState = {
  loading: false,
  completed: true,
  pageIndex: 0,
  pageSize: 0,
  totalCount: 0,
  totalPages: 0,

  categorySelectDto: [],
  albumProduct: [],
  specificationsCategoryDto: [],
  specificationsCategoryUnitDto: [],
  productDto: {
    id: 0,
    name: "",
    unitProduct: 0,
    fragile: false,
    origin: "",
    trademark: "",
    introduce: "",
    tag: "",
    supplier: 0,
    categoryProduct: 0,
    productAlbum: "",
  },
};

function suNewProductReducer(
  state: SuNewProductState = initialState,
  action: SuNewProductActions
) {
  switch (action.type) {
    // OPEN PAGE
    case ActionTypes.CREATE_PRODUCT_START:
      return {
        ...state,
        loading: true,
      };

    case ActionTypes.CREATE_PRODUCT_COMPLETED:
      return {
        ...state,
        loading: false,
      };

    case ActionTypes.CREATE_PRODUCT_ERROR:
      return {
        ...state,
        loading: false,
      };

    /////////////////////
    case ActionTypes.GET_CATEGORY_MAIN_START:
      return {
        ...state,
        loading: true,
      };

    case ActionTypes.GET_CATEGORY_MAIN_COMPLETED:
      return {
        ...state,
        loading: false,
        categorySelectDto: action.payload,
      };

    case ActionTypes.GET_CATEGORY_MAIN_ERROR:
      return {
        ...state,
        loading: false,
      };

    /////////////////////
    case ActionTypes.READ_FULL_ALBUM_PRODUCT_START:
      return {
        ...state,
        loading: true,
      };

    case ActionTypes.READ_FULL_ALBUM_PRODUCT_COMPLETED:
      return {
        ...state,
        loading: false,
        albumProduct: action.payload,
      };

    case ActionTypes.READ_FULL_ALBUM_PRODUCT_ERROR:
      return {
        ...state,
        loading: false,
      };

    /////////////////////
    case ActionTypes.GET_SPECIFI_CATEGORY_START:
      return {
        ...state,
        loading: true,
      };

    case ActionTypes.GET_SPECIFI_CATEGORY_COMPLETED:
      return {
        ...state,
        loading: false,
        specificationsCategoryDto: action.payload,
      };

    case ActionTypes.GET_SPECIFI_CATEGORY_ERROR:
      return {
        ...state,
        loading: false,
      };

    /////////////////////
    case ActionTypes.GET_SPECIFI_CATEGORY_UNIT_START:
      return {
        ...state,
        loading: true,
      };

    case ActionTypes.GET_SPECIFI_CATEGORY_UNIT_COMPLETED:
      return {
        ...state,
        loading: false,
        specificationsCategoryUnitDto: action.payload,
      };

    case ActionTypes.GET_SPECIFI_CATEGORY_UNIT_ERROR:
      return {
        ...state,
        loading: false,
      };

    case ActionTypes.SET_PRODUCT_DTOS:
      return {
        ...state,
        productDto: action.payload,
      };
    default:
      return state;
  }
}

export default suNewProductReducer;
