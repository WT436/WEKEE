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
    imageRoot: ["album/await/d2b6d2c34f664a59b1d8fcb9bbd199ea.jpg"
      , "album/await/b4a6a25518ed4815b28fba9442829cdb.jpg"
      , "album/await/14597c26dafa45baa785d8a516e77a02.jpg"
      , "album/await/b8b1ea23d247400598aa36119f120267.jpg"
      , "album/await/793cf4e35b634db899ef97fefb003edc.jpg"
      , "album/await/709c6b1705c14c2085aedbc28446f421.jpg"
      , "album/await/8df060b713b04b52accc7e38e3f5bf6f.jpg"
      , "album/await/6bd4202c3fb54a28aa881f01bc6dca1b.jpg"
      , "album/await/a06a8dc6b41c4fc5b663b7f4f4ff63c1.jpg"],
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
    //#region CONTAINER_CREATE_PRODUCT_START
    case ActionTypes.CONTAINER_CREATE_PRODUCT_START:
      console.log(action.payload);
      return {
        ...state,
        productContainer: action.payload,
        loading: true,
      };

    case ActionTypes.CONTAINER_CREATE_PRODUCT_COMPLETED:
      return {
        ...state,
        loading: false,
      };

    case ActionTypes.CONTAINER_CREATE_PRODUCT_ERROR:
      return {
        ...state,
        loading: false,
      };
    //#endregion

    //#region CONTAINER_CREATE_PRODUCT_START
    case ActionTypes.CONTAINER_CREATE_PRODUCT_START:
      return {
        ...state,
        loading: true,
      };

    case ActionTypes.CONTAINER_CREATE_PRODUCT_COMPLETED:
      return {
        ...state,
        loading: false,
      };

    case ActionTypes.CONTAINER_CREATE_PRODUCT_ERROR:
      return {
        ...state,
        loading: false,
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
