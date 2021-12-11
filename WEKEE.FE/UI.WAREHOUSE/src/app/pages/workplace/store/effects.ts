import { Injectable } from '@angular/core';
import { Actions, Effect, ofType } from '@ngrx/effects';
import { of } from 'rxjs';
import { catchError, map, mergeMap } from 'rxjs/operators';

import {
  GetToDoBeginAction,
  GetToDoSuccessAction,
  GetToDoFailAction
} from './action';
import { WorkplaceService } from './services';
import ToDo from '../dtos/todo';
import { ActionTypes } from './constants';

@Injectable()
export class WorkplaceEffects {
  constructor(private workplaceService: WorkplaceService, private action$: Actions) {}

  @Effect() GetToDos$ = this.action$.pipe(
    ofType<GetToDoBeginAction>(ActionTypes.GET_TO_DO_BEGIN),
    mergeMap(() =>
      this.workplaceService.getToDos().pipe(
        map((data: ToDo[]) => {
          return new GetToDoSuccessAction(data);
        }),
        catchError(error => of(new GetToDoFailAction(error)))
      )
    )
  );

  /*
  CreateToDos$: Observable<Action> = createEffect(() =>
    this.action$.pipe(
      ofType(WorkplaceActions.CreateToDoBegin),
      mergeMap(action =>
        this.workplaceService.createToDos(action.payload).pipe(
          map((data: ToDo) => {
            return WorkplaceActions.CreateToDoSuccess({ payload: data });
          }),
          catchError((error: Error) => {
            return of(WorkplaceActions.WorkplaceActionError(error));
          })
        )
      )
    )
  );
  */
}
