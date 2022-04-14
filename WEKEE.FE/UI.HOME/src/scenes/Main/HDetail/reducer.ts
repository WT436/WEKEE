import ActionTypes from "./constants";
import { HDetailState, HDetailActions } from "./types";

declare var abp: any;

export const initialState: HDetailState = {
  loading: false,
  completed: true,
  categoryBreadcrumbDtos: [
    { nameCategory: "", urlCategory: "", levelCategory: 0 },
  ],
};

function hDetailReducer(
  state: HDetailState = initialState,
  action: HDetailActions
) {
  switch (action.type) {
    case ActionTypes.GET_CATEGORY_BREADCRUMB_START:
      return {
        ...state,
        loading: true,
      };
    case ActionTypes.GET_CATEGORY_BREADCRUMB_COMPLETED:
      console.log(action.payload)
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
    default:
      return state;
  }
}

export default hDetailReducer;
