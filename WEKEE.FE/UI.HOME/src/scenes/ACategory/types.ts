import { ActionType } from 'typesafe-actions';
import * as actions from './actions';
import { CategoryDtos } from './dtos/categoryDtos';

export interface ACategoryState {
    readonly loading: boolean;
    readonly completed: boolean;
    readonly pageIndex: number;
    readonly pageSize: number;
    readonly totalCount: number;
    readonly totalPages: number;

    readonly categoryDtos:CategoryDtos[]
}

export type ACategoryActions = ActionType<typeof actions>;