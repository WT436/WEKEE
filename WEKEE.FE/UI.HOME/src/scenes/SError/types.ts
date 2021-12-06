import { ActionType } from 'typesafe-actions';
import * as actions from './actions';
import { ExceptionDtos } from './dtos/exceptionDtos'

export interface SErrorState {
    readonly loading: boolean;
    readonly completed: boolean;
    readonly pageIndex: number;
    readonly pageSize: number;
    readonly totalCount: number;
    readonly totalPages: number;
    readonly exceptionDtos: ExceptionDtos[]
}

export type SErrorActions = ActionType<typeof actions>;