import { ActionType } from 'typesafe-actions';
import * as actions from './actions';

export interface BaseState { // day
    readonly loading: boolean;
    readonly completed: boolean;
    readonly pageIndex: number;
    readonly pageSize: number;
    readonly totalCount: number;
    readonly totalPages: number;
}

export type BaseActions = ActionType<typeof actions>; // day