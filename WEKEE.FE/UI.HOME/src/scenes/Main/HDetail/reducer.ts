import ActionTypes from "./constants";
import { HDetailState, HDetailActions } from "./types";

declare var abp: any;

export const initialState: HDetailState = {
  loading: false,
  completed: true,
  categoryBreadcrumbDtos: [
    { nameCategory: "", urlCategory: "", levelCategory: 0 },
  ],
  basicProduct: {
    name: '',
    trademark: '',
    fullDescription: '',
    shortDescription: '',
    hasUserAgreement: false,
    orderMinimumQuantity: 0,
    orderMaximumQuantity: 0,
    shipSeparately: false,
    isFreeShipping: false,
    backorderModeId: 0,
    disableWishlistButton: false,
    wishlistNumber: 0,
    markAsNew: false,
    markAsNewStartDateTimeUtc: '',
    markAsNewEndDateTimeUtc: '',
    specificationAttributeDtos: []
  },
  imageForProduct: [],
  featureCartProduct: [],
  featureProductContainer: {
    productReadForCartDto: [],
    keyValuesName: [],
    renderImage: []
  },
  mainFeatureCheck: []
};

function hDetailReducer(
  state: HDetailState = initialState,
  action: HDetailActions
) {
  switch (action.type) {
    //#region MAIN_CHECK_FEATURE_START
    case ActionTypes.MAIN_CHECK_FEATURE_START:
      return {
        ...state,
        mainFeatureCheck: action.payload,
      };
    //#endregion
    //#region GET_FEATURE_CART_PRODUCT_START
    case ActionTypes.GET_FEATURE_CART_PRODUCT_START:
      return {
        ...state,
        loading: true,
      };

    case ActionTypes.GET_FEATURE_CART_PRODUCT_COMPLETED:
      return {
        ...state,
        loading: false,
        featureProductContainer: action.payload
      };

    case ActionTypes.GET_FEATURE_CART_PRODUCT_ERROR:
      return {
        ...state,
        loading: false,
      };
    //#endregion
    //#region GET_IMAGE_PRODUCT_START
    case ActionTypes.GET_IMAGE_PRODUCT_START:
      return {
        ...state,
        loading: true,
      };

    case ActionTypes.GET_IMAGE_PRODUCT_COMPLETED:
      return {
        ...state,
        loading: false,
        imageForProduct: action.payload
      };

    case ActionTypes.GET_IMAGE_PRODUCT_ERROR:
      return {
        ...state,
        loading: false,
      };
    //#endregion
    //#region GET_CATEGORY_BREADCRUMB 
    case ActionTypes.GET_CATEGORY_BREADCRUMB_START:
      return {
        ...state,
        loading: true,
      };
    case ActionTypes.GET_CATEGORY_BREADCRUMB_COMPLETED:
      return {
        ...state,
        loading: false,
        completed: true,
        categoryBreadcrumbDtos: action.payload,
      };
    case ActionTypes.GET_CATEGORY_BREADCRUMB_ERROR:
      return {
        ...state,
        loading: false,
      };
    //#endregion
    //#region GET_BASIC_PRODUCT_CART_START
    case ActionTypes.GET_BASIC_PRODUCT_CART_START:
      return {
        ...state,
        loading: true,
      };

    case ActionTypes.GET_BASIC_PRODUCT_CART_COMPLETED:
      return {
        ...state,
        loading: false,
        basicProduct: action.payload
      };

    case ActionTypes.GET_BASIC_PRODUCT_CART_ERROR:
      return {
        ...state,
        loading: false,
      };
    //#endregion

    default:
      return state;
  }
}

export default hDetailReducer;
