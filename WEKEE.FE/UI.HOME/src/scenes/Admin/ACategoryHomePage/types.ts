import { ActionType } from 'typesafe-actions';
import * as actions from './actions';
import { CategoryHomePageReadDto } from './dto/categoryHomePageReadDto';

export interface ACategoryHomePageState { // day
    readonly loading: boolean;
    readonly completed: boolean;
    readonly pageIndex: number;
    readonly pageSize: number;
    readonly totalCount: number;
    readonly totalPages: number;
    readonly categoryDtos: CategoryHomePageReadDto[]
}

export type ACategoryHomePageActions = ActionType<typeof actions>; // day