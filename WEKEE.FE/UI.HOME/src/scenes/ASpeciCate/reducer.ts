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
};

function aSpeciCateReducer(
  state: ASpeciCateState = initialState,
  action: ASpeciCateActions
) {
  switch (action.type) {
    ///////////////////
    case ActionTypes.WATCH_PAGE_START:
      return {
        ...state,
        loading: true,
      };

    case ActionTypes.WATCH_PAGE_COMPLETED:
      return {
        ...state,
        loading: false,
        completed: false,
      };

    case ActionTypes.WATCH_PAGE_ERROR:
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
    ///////////////////
    case ActionTypes.GET_NAME_KEY_SPECIFICATIONS_START:
      return {
        ...state,
        loading: true,
      };

    case ActionTypes.GET_NAME_KEY_SPECIFICATIONS_COMPLETED:
      return {
        ...state,
        loading: false,
        nameKey: action.payload,
      };

    case ActionTypes.GET_NAME_KEY_SPECIFICATIONS_ERROR:
      return {
        ...state,
        loading: false,
      };
    //////////////////
    case ActionTypes.GET_NAME_VALUES_SPECIFICATIONS_START:
      return {
        ...state,
      };

    case ActionTypes.GET_NAME_VALUES_SPECIFICATIONS_COMPLETED:
      return {
        ...state,
        classifyValues: action.payload,
      };

    case ActionTypes.GET_NAME_VALUES_SPECIFICATIONS_ERROR:
      return {
        ...state,
      };
    //////////////////
    case ActionTypes.SEARCH_SPECIFICATIONS_START:
      return {
        ...state,
        loading: true,
      };

    case ActionTypes.SEARCH_SPECIFICATIONS_COMPLETED:
      return {
        ...state,
        loading: false,
        specificationsCategoryDto: action.payload,
      };

    case ActionTypes.SEARCH_SPECIFICATIONS_ERROR:
      return {
        ...state,
        loading: false,
      };
    //////////////////
    default:
      return state;
  }
}

export default aSpeciCateReducer;
