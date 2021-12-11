import { Action } from '@ngrx/store';

import ToDo from '../dtos/todo';
import { ActionTypes } from './constants';
export class CreateToDoAction implements Action {
  readonly type = ActionTypes.CREATE_TO_DO;
  constructor(public payload: ToDo) {}
}

export class GetToDoBeginAction implements Action {
  readonly type = ActionTypes.GET_TO_DO_BEGIN;
}
export class GetToDoSuccessAction implements Action {
  readonly type = ActionTypes.GET_TO_DO_SUCCESS;
  constructor(public payload: ToDo[]) {}
}
export class GetToDoFailAction implements Action {
  readonly type = ActionTypes.GET_TO_DO_FAIL;
  constructor(public payload: any) {}
}

export type WorkplaceAction = CreateToDoAction | GetToDoBeginAction | GetToDoSuccessAction | GetToDoFailAction;
