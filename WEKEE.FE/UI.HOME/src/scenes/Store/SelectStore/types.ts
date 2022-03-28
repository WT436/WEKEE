import { ActionType } from 'typesafe-actions';
import * as actions from './actions';

export interface SelectStoreState { // day
    readonly loading: boolean;
    readonly completed: boolean;
    readonly pageIndex: number;
    readonly pageSize: number;
    readonly totalCount: number;
    readonly totalPages: number;
}

export type SelectStoreActions = ActionType<typeof actions>; // day