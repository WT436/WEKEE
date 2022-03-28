import { ActionType } from 'typesafe-actions';
import * as actions from './actions';
import { CategoryProductReadDto } from './dtos/CategoryProductReadDto';
import { CategoryProductReadMapDto } from './dtos/CategoryProductReadMapDto';

export interface ACategoryState {
    readonly loading: boolean;
    readonly completed: boolean;
    readonly pageIndex: number;
    readonly pageSize: number;
    readonly totalCount: number;
    readonly totalPages: number;

    readonly categoryDtos: CategoryProductReadDto[]
    readonly optionsCategory: CategoryProductReadMapDto[]
}

export type ACategoryActions = ActionType<typeof actions>;