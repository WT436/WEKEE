import ActionTypes from "./constants";
import { ASpeciCateActions, ASpeciCateState } from "./types";

declare var abp: any;

export const initialState: ASpeciCateState = {
  loading: false,
  completed: true,
  pageIndex: 0,
  pageSize: 0,
  totalCount: 0,
  totalPages: 0,

  categorySelectDto: [],
  nameKey: [],
  classifyValues: [],
  specificationsCategoryDto: [],
  optionsCategory: [],
  specificationAttributeReadDto: []
};

function aSpeciCateReducer(
  state: ASpeciCateState = initialState,
  action: ASpeciCateActions
) {
  switch (action.type) {

    //#region CREATE_SPECIFICATIONS_START 
    case ActionTypes.CREATE_SPECIFICATIONS_START:
      return {
        ...state,
        loading: true,
      };

    case ActionTypes.CREATE_SPECIFICATIONS_COMPLETED:
      return {
        ...state,
        loading: false,
      };

    case ActionTypes.CREATE_SPECIFICATIONS_ERROR:
      return {
        ...state,
        loading: false,
      };
    //#endregion

    //#region Category product map
    case ActionTypes.CATEGORY_MAP_START:
      return {
        ...state,
        loading: true
      };
    case ActionTypes.CATEGORY_MAP_COMPLETED:
      console.log(action.payload);
      return {
        ...state,
        optionsCategory: action.payload,
        loading: false
      };
    case ActionTypes.CATEGORY_MAP_ERROR:
      return {
        ...state,
        loading: false
      };
    //#endregion

    //#region SPECIFICATIONS_GET_PAGE_LIST_START
    case ActionTypes.SPECIFICATIONS_GET_PAGE_LIST_START:
      return {
        ...state,
        loading: true,
      };

    case ActionTypes.SPECIFICATIONS_GET_PAGE_LIST_COMPLETED:
      return {
        ...state,
        loading: false,
        specificationAttributeReadDto: action.payload.items,
        pageIndex: action.payload.pageIndex,
        pageSize: action.payload.pageSize,
        totalCount: action.payload.totalCount,
        totalPages: action.payload.totalPages,
      };

    case ActionTypes.SPECIFICATIONS_GET_PAGE_LIST_ERROR:
      return {
        ...state,
        loading: false,
      };
    //#endregion
    
    default:
      return state;
  }
}

export default aSpeciCateReducer;
