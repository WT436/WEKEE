import ActionTypes from "./constants";
import { HomeState, HomeActions } from "./types";

declare var abp: any;

export const initialState: HomeState = {
  loading: false,
  completed: true,
};

function homeReducer(state: HomeState = initialState, action: HomeActions) {
  switch (action.type) {
    // OPEN PAGE
    case ActionTypes.WATCH_PAGE_START:
      return {
        ...state,
        loading: true,
      };

    case ActionTypes.WATCH_PAGE_COMPLETED:
      return {
        ...state,
        loading: true,
        completed: true,
      };

    case ActionTypes.WATCH_PAGE_ERROR:
      return {
        ...state,
        loading: true,
      };

    default:
      return state;
  }
}

export default homeReducer;
