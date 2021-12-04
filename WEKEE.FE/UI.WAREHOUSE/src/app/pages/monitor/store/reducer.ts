import { MonitorAction, MonitorActionTypes } from "./actions";

export interface MonitorState {
  loading: boolean,
  error: string | any
}

const initialState: MonitorState = {
  loading: false,
  error: ""
}

export function MonitorReducer(state: MonitorState = initialState, action: MonitorAction) {
  switch(action.type) {
    case MonitorActionTypes.GET_MONITOR:
      return {
        ...state,
        loading: true
      }
    default:
      return state;
  }
}