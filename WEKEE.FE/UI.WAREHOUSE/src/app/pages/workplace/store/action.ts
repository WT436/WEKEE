import { Action } from '@ngrx/store';

import ToDo from '../dtos/todo';

export enum WorkplaceActionTypes {
  CREATE_TO_DO = '[WORKPLACE] Create to do',

  GET_TO_DO_BEGIN = '[WORKPLACE] Get to do begin',
  GET_TO_DO_SUCCESS = '[WORKPLACE] Get to do success',
  GET_TO_DO_FAIL = '[WORKPLACE] Get to do fail'
}

export class CreateToDoAction implements Action {
  readonly type = WorkplaceActionTypes.CREATE_TO_DO;
  constructor(public payload: ToDo) {}
}

export class GetToDoBeginAction implements Action {
  readonly type = WorkplaceActionTypes.GET_TO_DO_BEGIN;
}
export class GetToDoSuccessAction implements Action {
  readonly type = WorkplaceActionTypes.GET_TO_DO_SUCCESS;
  constructor(public payload: ToDo[]) {}
}
export class GetToDoFailAction implements Action {
  readonly type = WorkplaceActionTypes.GET_TO_DO_FAIL;
  constructor(public payload: any) {}
}

export type WorkplaceAction = CreateToDoAction | GetToDoBeginAction | GetToDoSuccessAction | GetToDoFailAction;