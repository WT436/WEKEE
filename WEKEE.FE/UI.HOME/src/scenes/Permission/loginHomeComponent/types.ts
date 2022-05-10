import { ActionType } from 'typesafe-actions';
import * as actions from './actions';

export interface LoginHomeComponentState {
    readonly loading: boolean;
    readonly completed: boolean;
    readonly pageIndex: number;
    readonly pageSize: number;
    readonly totalCount: number;
    readonly totalPages: number;
}

export type LoginHomeComponentActions = ActionType<typeof actions>;