import { WorkplaceAction, WorkplaceActionTypes } from "./action";

import ToDo from '../dtos/todo';

export interface WorkplaceState {
  toDos: Array<ToDo>;
}
const initialState: WorkplaceState = {
  toDos: Array<ToDo>()
};

export function WorkplaceReducer(state: WorkplaceState = initialState, action: WorkplaceAction) {
  switch(action.type) {
    case WorkplaceActionTypes.CREATE_TO_DO:
      return {
        ...state,
        toDos:[...state.toDos, action.payload]
      }
    default:
      return state;
  }
}
