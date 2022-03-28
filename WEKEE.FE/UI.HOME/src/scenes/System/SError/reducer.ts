import ActionTypes from "./constants";
import { SErrorState, SErrorActions } from "./types";

declare var abp: any;

export const initialState: SErrorState = {
  loading: false,
  completed: true,
  pageIndex: 0,
  pageSize: 0,
  totalCount: 0,
  totalPages: 0,
  exceptionDtos: [],
};

function sErrorReducer(
  state: SErrorState = initialState,
  action: SErrorActions
) {
  switch (action.type) {
    // OPEN PAGE
    case ActionTypes.GET_LIST_ERROR_SYSTEM_START:
      return {
        ...state,
        loading: true,
      };

    case ActionTypes.GET_LIST_ERROR_SYSTEM_COMPLETED:
      return {
        ...state,
        loading: false,
        exceptionDtos: action.payload.items,
        pageIndex: action.payload.pageIndex,
        pageSize: action.payload.pageSize,
        totalCount: action.payload.totalCount,
        totalPages: action.payload.totalPages,
      };

    case ActionTypes.GET_LIST_ERROR_SYSTEM_ERROR:
      return {
        ...state,
        loading: true,
      };

    case ActionTypes.FIX_ERROR_SYSTEM_START:
      return {
        ...state,
        loading: true,
      };

    case ActionTypes.FIX_ERROR_SYSTEM_COMPLETED:
      var objIndex = state.exceptionDtos.findIndex(
        (obj) => obj.id === action.payload
      );
      state.exceptionDtos[objIndex].isFix =
        !state.exceptionDtos[objIndex].isFix;
      return {
        ...state,
        loading: false,
      };

    case ActionTypes.FIX_ERROR_SYSTEM_ERROR:
      return {
        ...state,
        loading: false,
      };
    default:
      return state;
  }
}

export default sErrorReducer;
