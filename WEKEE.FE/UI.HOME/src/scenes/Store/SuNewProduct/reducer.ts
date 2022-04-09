import ActionTypes from "./constants";
import { SuNewProductActions, SuNewProductState } from "./types";

declare var abp: any;

//#region initialState 
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
  productAttributeReadTypesDto: [],
  productAttributeReadTrademarkDto: [],
  productAttributeReadAttributeDto: [],
  productContainer: {
    productInsertDto: {
      name: "",
      fragile: true,
      origin: "",
      unitAttributeId: 0,
      shortDescription: "",
      fullDescription: "",
      isShipEnabled: true,
      isFreeShipping: true,
      shipSeparately: true,
      additionalShippingCharge: 0,
      deliveryDateId: 0,
      productAvailabilityRangeId: 0,
      useMultipleWarehouses: true,
      displayStockAvailability: true,
      displayStockQuantity: true,
      minStockQuantity: 0,
      lowStockActivityId: 0,
      notifyAdminForQuantityBelow: 0,
      backorderModeId: 0,
      allowBackInStockSubscriptions: true,
      orderMinimumQuantity: 0,
      orderMaximumQuantity: 0,
      allowAddingOnlyExistingAttributeCombinations: true,
      notReturnable: true,
      viewReceived: true,
      disableBuyButton: true,
      disableWishlistButton: true,
      hasTierPrices: true,
      hasDiscountsApplied: true,
      productAlbum: "",
      createBy: 0
    },
    productTagDtos: [],
    imageRoot: ["album/await/20527dfb5fcc45bd82754e5084729db7.jpg"
      , "album/await/20527dfb5fcc45bd82754e5084729db7.jpg"
      , "album/await/20527dfb5fcc45bd82754e5084729db7.jpg"
      , "album/await/20527dfb5fcc45bd82754e5084729db7.jpg"
      , "album/await/20527dfb5fcc45bd82754e5084729db7.jpg"
      , "album/await/20527dfb5fcc45bd82754e5084729db7.jpg"
      , "album/await/20527dfb5fcc45bd82754e5084729db7.jpg"
      , "album/await/20527dfb5fcc45bd82754e5084729db7.jpg"
      , "album/await/20527dfb5fcc45bd82754e5084729db7.jpg"],
    specificationProductDtos: [
      {
        customValue: "",
        specificationId: 0,
        attributeTypeId: 0,
        allowFiltering: true
      }
    ],
    categoryProduct: {
      idCategory: [],
      categoryMain: 0
    },
    featureProductInsertDtos: [{
      id: 0,
      productId: 0,
      weightAdjustment: 0,
      lengthAdjustment: 0,
      widthAdjustment: 0,
      heightAdjustment: 0,
      price: 0,
      quantity: 0,
      displayOrder: 0,
      pictureString: "",
      mainProduct: true,
      productAttributeValueInsertDtos: [
        {
          key: 0,
          values: ""
        }
      ]
    }]
  }
};
//#endregion

function suNewProductReducer(
  state: SuNewProductState = initialState,
  action: SuNewProductActions
) {
  switch (action.type) {
    //#region INSERT_PRODUCT_FULL_START
    case ActionTypes.INSERT_PRODUCT_FULL_START:
      return {
        ...state,
        loading: true,
      };

    case ActionTypes.INSERT_PRODUCT_FULL_COMPLETED:
      return {
        ...state,
        loading: false,
      };

    case ActionTypes.INSERT_PRODUCT_FULL_ERROR:
      return {
        ...state,
        loading: false,
      };
    //#endregion
    
    //#region CONTAINER_CREATE_PRODUCT_START
    case ActionTypes.CONTAINER_CREATE_PRODUCT_START:
      console.log(action.payload);
      return {
        ...state,
        productContainer: action.payload,
        loading: true,
      };
    //#endregion

    //#region PRO_ATTR_TYPE_UNIT_START
    case ActionTypes.PRO_ATTR_TYPE_UNIT_START:
      return {
        ...state,
        loading: true,
      };

    case ActionTypes.PRO_ATTR_TYPE_UNIT_COMPLETED:
      return {
        ...state,
        loading: false,
        productAttributeReadTypesDto: action.payload,

      };

    case ActionTypes.PRO_ATTR_TYPE_TRADEMARK_COMPLETED:
      return {
        ...state,
        loading: false,
        productAttributeReadTrademarkDto: action.payload,

      };

    case ActionTypes.PRO_ATTR_TYPE_ATTRIBUTE_COMPLETED:
      console.log(action.payload)
      return {
        ...state,
        loading: false,
        productAttributeReadAttributeDto: action.payload,
      };

    case ActionTypes.PRO_ATTR_TYPE_UNIT_ERROR:
      return {
        ...state,
        loading: false,
      };
    //#endregion

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
